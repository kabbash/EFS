using FluentValidation;
using ItemsReview.Extensions;
using ItemsReview.Interfaces;
using ItemsReview.Models;
using Mapster;
using Rating.Core.Interfaces;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Net;

namespace ItemsReview.Services
{
    public class ItemsReviewsManager : IItemsReviewsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ItemReviewDto> _validator;
        private readonly IRatingManager<ItemsForReview> _ratingManager;
        public ItemsReviewsManager(IUnitOfWork unitOfWork, IValidator<ItemReviewDto> validator, IRatingManager<ItemsForReview> ratingManager)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _ratingManager = ratingManager;
        }
        public ResultMessage GetAll(ItemsReviewFilter filter)
        {
            try
            {
                PagedResult<ItemReviewDto> result = new PagedResult<ItemReviewDto>();
                result = _unitOfWork.ItemsReviewsRepository.Get().ApplyFilter(filter).GetPaged(filter.PageNo,filter.PageSize).Adapt(result);

                return new ResultMessage()
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ItemReviewDto newItemDto)
        {
            var validationResult = _validator.Validate(newItemDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                _unitOfWork.ItemsReviewsRepository.Insert(newItemDto.Adapt<ItemsForReview>());
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
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
        {
            try
            {
                var itemReview = _unitOfWork.ItemsReviewsRepository.GetById(id);
                // itemReview.Reviews.ToList();
                if (itemReview != null)
                {
                    var result = itemReview.Adapt<ItemReviewDto>();
                    result.Reviews = _ratingManager.GetItemRatings(itemReview.Id, RatingEntityTypesEnum.ItemsForReview);
                    return new ResultMessage()
                    {
                        Data = result,
                        Status = HttpStatusCode.OK
                    };
                }
                    
                else
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsNotFoundError
                    };
            }
            catch (Exception ex)
            {
                //log ex
                return new ResultMessage()
                {
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsGetByIdError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ItemReviewDto itemReviewDto, int id)
        {
            var validationResult = _validator.Validate(itemReviewDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var oldItem = _unitOfWork.ItemsReviewsRepository.GetById(id);
                if (oldItem != null)
                {
                    oldItem.Name = itemReviewDto.Name;
                    oldItem.ProfilePicture = itemReviewDto.ProfilePicture;
                    _unitOfWork.ItemsReviewsRepository.Update(oldItem);
                    _unitOfWork.Commit();
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                        ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsNotFoundError
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsUpdateError
                };
            }
        }
        public ResultMessage Delete(int id)
        {
            try
            {
                _unitOfWork.ItemsReviewsRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsDeleteError
                };
            }
        }
    }
}
