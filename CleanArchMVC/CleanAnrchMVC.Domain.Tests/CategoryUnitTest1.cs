using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanAnrchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "CategoryName");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInValidId_ResultInvalidState()
        {
            Action action = () => new Category(-1, "CategoryName");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Too Short Name")]
        public void CreateCategory_WithTooShortName_ResultInvalidState()
        {
            Action action = () => new Category(1, "Ct");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Name, Too Short, Minimal is 3 characters!");
        }

        [Fact(DisplayName = "Create Category With Invalid Name")]
        public void CreateCategory_WithInvalidName_ResultInvalidState()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Name, the value is required!");
        }
    }
}
