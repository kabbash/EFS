using FluentValidation;
using Mapster;
using Microsoft.Extensions.Options;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core;
using Shared.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace Products.Core.Services
{
    public class ProductsRatingManager : IProductsRatingManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductsRatingDto> _validator;
        public ProductsRatingManager(IUnitOfWork unitOfWork, IValidator<ProductsRatingDto> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public ResultMessage AddOrUpdate(ProductsRatingDto productRating)
        {
            var validationResult = _validator.Validate(productRating);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                // GET BY USER 
                var oldRating = _unitOfWork.ProductsRatingRepository.Get(c => c.ProductId == productRating.ProductId && c.CreatedBy == "7c654344-ad42-4428-a77a-00a8c1299c3f").SingleOrDefault();
                if (oldRating != null)
                {
                    oldRating.Comment = productRating.Comment;
                    oldRating.Rate = productRating.Rate;
                    _unitOfWork.ProductsRatingRepository.Update(oldRating);
                }
                else
                    _unitOfWork.ProductsRatingRepository.Insert(productRating.Adapt<ProductsRating>());


                // To Be Thread
                var productRatings = _unitOfWork.ProductsRatingRepository.Get(c => c.ProductId == productRating.ProductId).ToList();
                var product = _unitOfWork.ProductsRepository.GetById(productRating.ProductId);
                product.Rate = productRatings.Count > 0 ? productRatings.Sum(c => c.Rate) / productRatings.Count : -1;
                _unitOfWork.ProductsRepository.Update(product);

                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    ErrorCode = ErrorsCodeEnum.ProductsRatingInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }

        //public int Get(int productId)
        //{
        //    var productRatings = _unitOfWork.ProductsRatingRepository.Get(c => c.ProductId == productId).ToList();
        //    return productRatings.Count > 0 ? productRatings.Sum(c => c.Rate) / productRatings.Count : -1;
        //}
    }
}
