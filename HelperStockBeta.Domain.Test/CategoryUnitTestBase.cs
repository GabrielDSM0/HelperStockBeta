using FluentAssertions;
using HelperStockBeta.Domain.Entities;
namespace HelperStockBeta.Domain.Test;

public class CategoryUnitTestBase
{
    #region Testes positivos
    [Fact(DisplayName = "Category name is not null.")]
    public void CreateCategory_WithParameters_ResultValid()
    {
        Action action = () => new Category(1, "Category Test");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    [Fact(DisplayName = "Category no present id parameter.")]
    public void CreateCategory_IdParameterLess_ResultValid()
    {
        Action action = () => new Category("Category Test");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    #endregion

    #region Testes negativos
    [Fact(DisplayName = "Id negative exception.")]
    public void CreateCategory_NegativeParameterId_ResultException()
    {
        Action action = () => new Category(-1, "Category Test");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Identification is positive values!");
    }
    [Fact(DisplayName = "Category name is null.")]
    public void CreateCategory_NameIsNull_ResultException()
    {
         Action action = () => new Category(1, null);
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required!");
    }
    [Fact(DisplayName = "Category short name.")]
    public void CreateCategory_NameIsShort_ResultValid()
    {
        Action action = () => new Category(1, "CA");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Name is minimum 3 charecters");
    }
    #endregion
}