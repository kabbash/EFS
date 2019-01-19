using Articles.Core.Extensions;
using Articles.Core.Interfaces;
using Articles.Core.Models;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Mapster;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Articles.Core.Services
{
    public class ArticleService : IArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ArticleAddDto> _addValidator;
        private readonly IValidator<RejectDto> _rejectValidator;
        private readonly IAttachmentsManager _attachmentsManager;

        public ArticleService(IUnitOfWork unitOfWork, IValidator<ArticleAddDto> addvalidator, IValidator<RejectDto> rejectvalidator, IAttachmentsManager attachmentsManager)
        {
            _unitOfWork = unitOfWork;
            _addValidator = addvalidator;
            _rejectValidator = rejectvalidator;
            _attachmentsManager = attachmentsManager;
        }
        public ResultMessage Delete(int id)
        {
            try
            {
                _unitOfWork.ArticlesRepository.Delete(id);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
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
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };

            }
        }
        public ResultMessage GetAll(int pageNo, int pageSize, ArticlesFilter filter = null)
        {
            try
            {
                PagedResult<ArticleGetDto> result = new PagedResult<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get().ApplyFilter(filter).GetPaged(pageNo, pageSize).Adapt(result);
                return new ResultMessage
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetPendingApprovalItems(ArticlesFilter filter = null)
        {
            try
            {
                IEnumerable<ArticleGetDto> result = new List<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get().ApplyFilter(filter).Adapt(result);
                return new ResultMessage
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetByCategoryId(int id, int pageNo, int pageSize)
        {
            try
            {
                PagedResult<ArticleGetDto> result = new PagedResult<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get(c => c.CategoryId == id).GetPaged(pageNo, pageSize).Adapt(result);
                return new ResultMessage
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetByPredefinedCategoryKey(int id, int pageNo, int pageSize)
        {
            try
            {
                PagedResult<ArticleGetDto> result = new PagedResult<ArticleGetDto>();
                var categoryId = _unitOfWork.ArticlesCategoriesRepository.Get(c => c.PredefinedKey == id).SingleOrDefault().Id;
                result = _unitOfWork.ArticlesRepository.Get(c => c.CategoryId == categoryId).GetPaged(pageNo, pageSize).Adapt(result);
                return new ResultMessage
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

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
                    articleDto.Images = article.Images.Select(c => new ImageWithTextDto
                    {
                        Path = c.Path,
                        Text = c.Text,
                        Title = c.Title
                    }).ToList();

                return new ResultMessage
                {
                    Data = articleDto,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Insert(ArticleAddDto article)
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
                var articleEntity = article.Adapt<Shared.Core.Models.Articles>();
                articleEntity.CreatedAt = DateTime.Now;
                articleEntity.CreatedBy = article.UserId;

                //var articleFolderName = Guid.NewGuid().ToString();
                //articleEntity.ProfilePicture = _attachmentsManager.Save(new SavedFileDto
                //{
                //    attachmentType = AttachmentTypesEnum.Articles,
                //    CanChangeName = false,
                //    File = article.ProfilePictureFile,
                //    SubFolderName = articleFolderName
                //});

                //foreach (var image in article.ImagesLstFiles)
                //{
                //    articleEntity.Images.Add(new ArticlesImages
                //    {
                //        ArticleId = articleEntity.Id,
                //        Path = _attachmentsManager.Save(new SavedFileDto
                //        {
                //            attachmentType = AttachmentTypesEnum.Articles,
                //            CanChangeName = false,
                //            File = image,
                //            SubFolderName = articleFolderName
                //        }),
                //        Title = image.Name
                //    });
                //}

                _unitOfWork.ArticlesRepository.Insert(articleEntity);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsInsertError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Update(ArticleAddDto article, int articleId)
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

                article.Adapt(articleData, typeof(ArticleAddDto), typeof(Shared.Core.Models.Articles));
                articleData.UpdatedAt = DateTime.Now;
                articleData.UpdatedBy = article.UserId;

                _unitOfWork.ArticlesRepository.Update(articleData);
                _unitOfWork.Commit();
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage Reject(RejectDto rejectDto)
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
                articleData.UpdatedBy = rejectDto.UserId;
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
                return new ResultMessage
                {
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public ResultMessage GetFilteredData(ArticlesFilter filter)
        {
            try
            {
                PagedResult<ArticleGetDto> result = new PagedResult<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get().ApplyFilter(filter).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);
                return new ResultMessage
                {
                    Data = result,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new ResultMessage()
                {
                    ErrorCode = (int)ProductsErrorsCodeEnum.ProductsGetAllError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
