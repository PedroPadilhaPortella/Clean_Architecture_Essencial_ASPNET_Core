using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanAnrchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "ProductName", "ProductDescription", 19.99m, 100, "product_image.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInValidId_ResultInvalidState()
        {
            Action action = () => new Product(-1, "ProductName", "ProductDescription", 19.99m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Too Short Name")]
        public void CreateProduct_WithTooShortName_ResultInvalidState()
        {
            Action action = () => new Product(1, "Pd", "ProductDescription", 19.99m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Name, Too Short, Minimal is 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidName_ResultInvalidState()
        {
            Action action = () => new Product(1, null, "ProductDescription", 19.99m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Name, the value is required!");
        }

        [Fact(DisplayName = "Create Product With Too Short Description")]
        public void CreateProduct_WithTooShortDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "ProductName", "Desc", 19.99m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, Too Short, Minimal is 5 characters!");
        }

        [Fact (DisplayName = "Create Product With Invalid Description")]
        public void CreateProduct_WithInvalidDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "ProductName", null, 19.99m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, the value is required!");
        }

        [Fact (DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultInvalidState()
        {
            Action action = () => new Product(1, "ProductName", "ProductDescription", -19m, 100, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price value");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock")]
        [InlineData(-19)]
        public void CreateProduct_WithInvalidStock_ResultInvalidState(int value)
        {
            Action action = () => new Product(1, "ProductName", "ProductDescription", 19.99m, value, "product_image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock value");
        }

        [Fact(DisplayName = "Create Product With No Image")]
        public void CreateProduct_WithNoImage_ResultValidState()
        {
            Action action = () => new Product(1, "ProductName", "ProductDescription", 19.99m, 100, null);
            action.Should().NotThrow<DomainExceptionValidation>();
            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact(DisplayName = "Create Product With Invalid Image")]
        public void CreateProduct_WithInvalidImage_ResultInvalidState()
        {
            Action action = () => new Product(1, "ProductName", "ProductDescription", 19.99m, 100, "data:image/gif;base64,R0lGODlhPQBEAPeoAJosM//AwO/AwHVYZ/z595kzAP/s7P+goOXMv8+fhw/v739/f+8PD98fH/8mJl+fn/9ZWb8/PzWlwv///6wWGbImAPgTEMImIN9gUFCEm/gDALULDN8PAD6atYdCTX9gUNKlj8wZAKUsAOzZz+UMAOsJAP/Z2ccMDA8PD/95eX5NWvsJCOVNQPtfX/8zM8+QePLl38MGBr8JCP+zs9myn/8GBqwpAP/GxgwJCPny78lzYLgjAJ8vAP9fX/+MjMUcAN8zM/9wcM8ZGcATEL+QePdZWf/29uc/P9cmJu9MTDImIN+/r7+/vz8/P8VNQGNugV8AAF9fX8swMNgTAFlDOICAgPNSUnNWSMQ5MBAQEJE3QPIGAM9AQMqGcG9vb6MhJsEdGM8vLx8fH98AANIWAMuQeL8fABkTEPPQ0OM5OSYdGFl5jo+Pj");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Image Name, Too Long, maximun 250 characters");
        }
    }
}
