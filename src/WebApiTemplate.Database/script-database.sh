#!/bin/bash

# wait for MSSQL server to start
export STATUS=1
i=0
MIGRATIONS=$(ls migrations/*.sql | sort -V)

while [[ $STATUS -ne 0 ]] && [[ $i -lt 30 ]]; do
	i=$i+1
	/opt/mssql-tools/bin/sqlcmd -t 1 -U sa -P $SA_PASSWORD -Q "select 1" >> /dev/null
	STATUS=$?
done

if [ $STATUS -ne 0 ]; then 
	echo "Error: MSSQL SERVER took more than thirty seconds to start up."
	exit 1
fi

echo "======= MSSQL SERVER STARTED ========" | tee -a ./config.log

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i create-database.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i create-database-user.sql

for f in $MIGRATIONS
do
    echo "Processing migration $f"
	/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i $f
done

echo "======= MSSQL CONFIG COMPLETE =======" | tee -a ./config.log