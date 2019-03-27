using Articles.Core.Extensions;
using Articles.Core.Interfaces;
using Articles.Core.Models;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using DBModels = Shared.Core.Models;

namespace Articles.Core.Services
{
    public class ArticleService : IArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ArticleAddDto> _addValidator;
        private readonly IValidator<RejectDto> _rejectValidator;
        private readonly IAttachmentsManager _attachmentsManager;
        private readonly ISliderManager<DBModels.ArticlesImages> _sliderManager;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(IUnitOfWork unitOfWork, IValidator<ArticleAddDto> addvalidator, IValidator<RejectDto> rejectvalidator, IAttachmentsManager attachmentsManager, ISliderManager<DBModels.ArticlesImages> sliderManager, ILogger<ArticleService> logger)
        {
            _unitOfWork = unitOfWork;
            _addValidator = addvalidator;
            _rejectValidator = rejectvalidator;
            _attachmentsManager = attachmentsManager;
            _sliderManager = sliderManager;
            _logger = logger;
        }

        public ResultMessage GetAll(ArticlesFilter filter)
        {
            try
            {
                PagedResult<ArticleGetDto> result = new PagedResult<ArticleGetDto>();

                if (filter.CategoryId == (int)PredefinedArticlesCategories.Championships)
                    result = _unitOfWork.ArticlesRepository.Get().ApplyFilter(filter).ApplyChampionshipsFilter().OrderByDescending(c => c.Date.HasValue).ThenBy(c => c.Date).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);
                else
                    result = _unitOfWork.ArticlesRepository.Get().ApplyFilter(filter).OrderByDescending(c => c.CreatedAt).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);

                return new ResultMessage
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
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetById(int id)
        {
            try
            {
                var article = _unitOfWork.ArticlesRepository.GetById(id);

                if (article == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound
                    };
                }
                var articleDto = article.Adapt<ArticleGetDto>();

                if (article.Images != null)
                    articleDto.Images = article.Images.Select(c => new SliderItemDto
                    {
                        Path = c.Path,
                        Description = c.Description,
                        Title = c.Title,
                        Id = c.Id,
                        IsProfilePicture = c.Path == articleDto.ProfilePicture
                    }).ToList();

                return new ResultMessage
                {
                    Data = articleDto,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ArticleAddDto article, IUserDto user)
        {
            var validationResult = _addValidator.Validate(article);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };
            }
            try
            {
                var articleEntity = article.Adapt<DBModels.Articles>();
                articleEntity.CreatedAt = DateTime.Now;
                articleEntity.CreatedBy = user.Id;

                var articleFolderName = Guid.NewGuid().ToString();

                var sliderDto = new SliderDto
                {
                    attachmentType = AttachmentTypesEnum.Articles,
                    Items = article.UpdatedImages,
                    SubFolderName = articleFolderName
                };

                if (sliderDto.Items.Count > 0)
                    articleEntity.ProfilePicture = _sliderManager.GetProfilePicturePath(sliderDto);

                articleEntity.SubFolderName = articleFolderName;
                articleEntity.Images = null;
                articleEntity.IsActive = null;
                _unitOfWork.ArticlesRepository.Insert(articleEntity);
                _unitOfWork.Commit();

                sliderDto.ParentId = articleEntity.Id;
                _sliderManager.Add(sliderDto);

                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ArticleAddDto article, int articleId, IUserDto user)
        {
            var validationResult = _addValidator.Validate(article);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };
            }
            try
            {
                var articleData = _unitOfWork.ArticlesRepository.GetById(articleId);
                if (articleData == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                    };
                }


                if (user.IsAdmin || (user.Id != articleData.CreatedBy && (!articleData.IsActive.HasValue || !articleData.IsActive.Value)))
                {
                    article.Adapt(articleData, typeof(ArticleAddDto), typeof(DBModels.Articles));
                    articleData.UpdatedAt = DateTime.Now;
                    articleData.UpdatedBy = user.Id;

                    var sliderDto = new SliderDto
                    {
                        attachmentType = AttachmentTypesEnum.Articles,
                        Items = article.UpdatedImages ?? new List<SliderItemDto>(),
                        SubFolderName = articleData.SubFolderName,
                        ParentId = articleId
                    };

                    //check profile picture
                    if (sliderDto.Items.Count > 0)
                        articleData.ProfilePicture = _sliderManager.GetProfilePicturePath(sliderDto, article.ProfilePicture);

                    _unitOfWork.ArticlesRepository.Update(articleData);
                    _unitOfWork.Commit();

                    // update files                
                    if (sliderDto.Items.Count > 0)
                        _sliderManager.Update(sliderDto);

                    return new ResultMessage
                    {
                        Status = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Delete(int id, IUserDto user)
        {
            try
            {
                var article = _unitOfWork.ArticlesRepository.GetById(id);
                if (article == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound

                    };
                }

                if (user.IsAdmin || (user.Id == article.CreatedBy && (!article.IsActive.HasValue || !article.IsActive.Value)))
                {
                    var articleFolder = article.SubFolderName;
                    if (!string.IsNullOrEmpty(articleFolder))
                        _attachmentsManager.DeleteFolder(articleFolder, AttachmentTypesEnum.Articles);

                    _unitOfWork.ArticlesRepository.Delete(id);
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
                        Status = HttpStatusCode.Unauthorized
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };

            }
        }
        public ResultMessage Approve(int id)
        {
            try
            {
                var articleData = _unitOfWork.ArticlesRepository.GetById(id);
                if (articleData == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                    };
                }

                articleData.UpdatedAt = DateTime.Now;
                articleData.IsActive = true;
                //articleData.UpdatedBy = userId;
                _unitOfWork.ArticlesRepository.Update(articleData);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };

            }
        }
        public ResultMessage Reject(RejectDto rejectDto, IUserDto user)
        {
            var validationResult = _rejectValidator.Validate(rejectDto);
            if (!validationResult.IsValid)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };
            }
            try
            {
                var articleData = _unitOfWork.ArticlesRepository.GetById(rejectDto.Id);
                if (articleData == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                    };
                }

                articleData.UpdatedAt = DateTime.Now;
                articleData.UpdatedBy = user.Id;
                articleData.RejectReason = rejectDto.RejectReason;
                articleData.IsActive = false;

                _unitOfWork.ArticlesRepository.Update(articleData);
                _unitOfWork.Commit();

                return new ResultMessage
                {
                    Status = HttpStatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
