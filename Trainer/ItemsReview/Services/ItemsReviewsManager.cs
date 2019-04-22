using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using ItemsReview.Extensions;
using ItemsReview.Interfaces;
using ItemsReview.Models;
using Mapster;
using Microsoft.Extensions.Logging;
using Rating.Core.Interfaces;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Linq;
using System.Net;

namespace ItemsReview.Services
{
    public class ItemsReviewsManager : IItemsReviewsManager
    {
        protected IUnitOfWork _unitOfWork;
        private readonly IValidator<ItemReviewDto> _validator;
        private readonly IRatingManager<ItemsForReview> _ratingManager;
        private readonly ILogger<ItemsReviewsManager> _logger;
        private readonly IAttachmentsManager _attachmentsManager;

        public ItemsReviewsManager(IUnitOfWork unitOfWork, IValidator<ItemReviewDto> validator, IRatingManager<ItemsForReview> ratingManager, IAttachmentsManager attachmentsManager, ILogger<ItemsReviewsManager> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _ratingManager = ratingManager;
            _attachmentsManager = attachmentsManager;
            _logger = logger;
        }
        public ResultMessage GetAll(ItemsReviewFilter filter)
        {
            try
            {
                PagedResult<ItemReviewDto> result = new PagedResult<ItemReviewDto>();
                result = _unitOfWork.ItemsReviewsRepository.Get().ApplyFilter(filter).OrderBy(c => c.Name).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);

                return new ResultMessage()
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
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
                if (newItemDto.ProfilePictureFile != null)
                    newItemDto.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                    {
                        attachmentType = AttachmentTypesEnum.Products,
                        CanChangeName = true,
                        File = newItemDto.ProfilePictureFile
                    });

                _unitOfWork.ItemsReviewsRepository.Insert(newItemDto.Adapt<ItemsForReview>());
                _unitOfWork.Commit();

                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id, string currentUserId)
        {
            try
            {
                var itemReview = _unitOfWork.ItemsReviewsRepository.GetById(id);
                // itemReview.Reviews.ToList();
                if (itemReview != null)
                {
                    var result = itemReview.Adapt<ItemReviewDto>();
                    result.Reviews = _ratingManager.GetItemRatings(itemReview.Id, RatingEntityTypesEnum.ItemsForReview);

                    if (!string.IsNullOrEmpty(currentUserId))
                        result.Reviews.ForEach(c =>
                        {
                            c.isCurrent = c.CreatedBy == currentUserId;
                        });

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
                _logger.LogError(ex, string.Empty);
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
                    if (itemReviewDto.ProfilePictureFile != null)
                    {
                        itemReviewDto.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                        {
                            attachmentType = AttachmentTypesEnum.Products,
                            CanChangeName = true,
                            File = itemReviewDto.ProfilePictureFile
                        });
                    }

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
                _logger.LogError(ex, string.Empty);
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
                var item = _unitOfWork.ItemsReviewsRepository.GetById(id);
                if (item == null)
                {
                    return new ResultMessage()
                    {
                        Status = HttpStatusCode.NotFound
                    };
                }
                _unitOfWork.ItemsReviewsRepository.Delete(id);
                _attachmentsManager.Delete(item.ProfilePicture);
                _unitOfWork.Commit();
                return new ResultMessage()
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError,
                    ErrorCode = (int)ItemsReviewsErrorsCodeEnum.ItemsDeleteError
                };
            }
        }
    }
}
