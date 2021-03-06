﻿using System;
using WebApiTemplate.WebApi.Models;

namespace WebApiTemplate.Tests.Integration.Builders
{
    public class CustomerRequestModelBuilder
    {
        private string _firstName { get; set; }
        private string _surname { get; set; }
        private string _status { get; set; }

        public CustomerRequestModelBuilder WithValidPropertyValues()
        {
            _firstName = "ValidName";
            _surname = "ValidSurname";
            _status = "Gold";
            return this;
        }

        public CustomerRequestModelBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerRequestModelBuilder WithSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public CustomerRequestModelBuilder WithStatus(string status)
        {
            _status = status;
            return this;
        }

        public CustomerRequestModel Build()
        {
            return new CustomerRequestModel(
                _firstName, 
                _surname,
                _status);
        }
    }
}
