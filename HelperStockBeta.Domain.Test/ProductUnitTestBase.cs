using FluentAssertions;
using HelperStockBeta.Domain.Entities;
namespace HelperStockBeta.Domain.Test;

public class ProductUnitTestBase
{
    #region Testes positivos
    [Fact(DisplayName = "Product Id is not null.")]
    public void CreateProduct_IdParameterLess_ResultValid()
    {
        Action action = () => new Product(1, "Product Test", "Teste", 0, 0, "img");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    [Fact(DisplayName = "Product name is not null.")]
    public void CreateProduct_WithParameters_ResultValid()
    {
        Action action = () => new Product("Product Test", "Teste", 0, 0, "img");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }

    #endregion

    #region Testes negativos
    [Fact(DisplayName = "Id negative exception.")]
    public void CreateProduct_NegativeParameterId_ResultException()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 10, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for id.");
    }
    [Fact(DisplayName = "Name is null")]
    public void CreateProduct_NameIsNull_ResultException()
    {
        Action action = () => new Product(1, null, "Product Description", 10, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
    }
    [Fact(DisplayName = "Product short name.")]
    public void CreateProduct_NameIsShort_ResultValid()
    {
        Action action = () => new Product(1, "CA", "Product Description", 10, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short names, minimum 3 characteres.");
    }
    [Fact(DisplayName = "Description is null")]
    public void CreateProduct_DescriptionIsNull_ResultException()
    {
        Action action = () => new Product(2, "Name Product", null, 10, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, description is required.");
    }
    [Fact(DisplayName = "Product short description.")]
    public void CreateProduct_DescriptionIsShort_ResultValid()
    {
        Action action = () => new Product(1, "Product Name", "De", 10, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short descriptions, minimum 5 characters.");
    }
    [Fact(DisplayName = "Product negative price.")]
    public void CreateProduct_PriceIsNegative_ResultValid()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -5, 1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for price.");
    }
    [Fact(DisplayName = "Product negative stock.")]
    public void CreateProduct_StockIsNegative_ResultValid()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, -1, "imagem1.png");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for stock.");
    }
    [Fact(DisplayName = "Product invalid image.")]
    public void CreateProduct_InvalidImage_ResultValid()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, 1, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz012345678");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid long URL, maximum 250 characteres.");
    }
    #endregion
}
