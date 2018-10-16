using FluentValidation;
using Mapster;
using Microsoft.Extensions.Options;
using Products.Categories.Core.Interfaces;
using Products.Categories.Core.Models;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;


namespace Products.Categories.Core.Services
{
    public class ProductsCategoriesManager : IProductsCategoriesManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsCategoryDto> _validator;
        private readonly IOptions<ProductsResources> _productsResources;
        public ProductsCategoriesManager(IUnitOfWork unitOfWork, IValidator<ProductsCategoryDto> validator, IOptions<ProductsResources> productsResources)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _productsResources = productsResources;
        }
        public ResultMessage GetAll()
        {
            try
            {
                IEnumerable<ProductsCategoryDto> result = new List<ProductsCategoryDto>();
                result = _unitOfWork.ProductsCategoriesRepository.Get().Adapt(result);

                return new ResultMessage()
                {
                    Data = result,
                    Status = (int)ResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    Message = _productsResources.Value.CategoriesLoadError,
                    Status = (int)ResultStatus.Success
                };
            }
        }
        public ResultMessage Insert(ProductsCategoryDto category)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = (int)ResultStatus.Validation,
                    ValidationMessages = GetErrors(validationResult)
                };
            }

            try
            {
                _unitOfWork.ProductsCategoriesRepository.Insert(category.Adapt<ProductsCategories>());                
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Message = _productsResources.Value.CategoryAddedSuccessfully,
                    Status = (int)ResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    Message = _productsResources.Value.CategoryAddHasError,
                    Status = (int)ResultStatus.Error
                };
            }
        }
        public ResultMessage GetById(byte id)
        {
            try
            {
                var category = _unitOfWork.ProductsCategoriesRepository.GetById(id);
                if(category !=null)
                return new ResultMessage()
                {
                    Data = category.Adapt<ProductsCategoryDto>(),
                    Status = (int) ResultStatus.Success
                };
                else
                    return new ResultMessage()
                    {                        
                        Status = (int)ResultStatus.Error,
                        Message = _productsResources.Value.CategoryCannotBeFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    Message = _productsResources.Value.CategoriesLoadError,
                    Status = (int)ResultStatus.Success
                };
            }
        }
        public ResultMessage Update(ProductsCategoryDto category, byte id)
        {
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = (int)ResultStatus.Validation,
                    ValidationMessages = GetErrors(validationResult)
                };
            }

            try
            {
                var oldCategory = _unitOfWork.ProductsCategoriesRepository.GetById(id);
                if (oldCategory != null)
                {
                    oldCategory.Name = category.Name;
                    oldCategory.ProfilePicture = category.ProfilePicture;
                    _unitOfWork.ProductsCategoriesRepository.Update(oldCategory);
                    _unitOfWork.Commit();
                    return new ResultMessage
                    {
                        Status = (int) ResultStatus.Success,
                        Message = _productsResources.Value.CategoryUpdatedSuccessfully
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Status = (int) ResultStatus.Error,
                        Message = _productsResources.Value.CategoryCannotBeFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = (int) ResultStatus.Error,
                    Message = _productsResources.Value.CategoryUpdateError
                };
            }
        }
        public ResultMessage Delete(byte id)
        {
            try
            {
                _unitOfWork.ProductsCategoriesRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage ()
                {
                    Status = (int) ResultStatus.Success,
                    Message = _productsResources.Value.CategoryDeletedSuccessfully
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = (int) ResultStatus.Error,
                    Message = _productsResources.Value.CategoryDeleteError
                };
            }
        }
        private List<string> GetErrors(FluentValidation.Results.ValidationResult result)
        {
            List<string> errors = new List<string>();
            foreach (var error in result.Errors)
                errors.Add(error.ErrorMessage);
            return errors;
        }
    }
}
