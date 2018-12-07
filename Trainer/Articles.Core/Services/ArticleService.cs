using Articles.Core.Interfaces;
using Articles.Core.Models;
using FluentValidation;
using Mapster;
using Shared.Core;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Articles.Core.Services
{
    public class ArticleService : IArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ArticleAddDto> _Validator;
        public ArticleService(IUnitOfWork unitOfWork, IValidator<ArticleAddDto> validator)
        {
            _unitOfWork = unitOfWork;
            _Validator = validator;
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
        public ResultMessage GetAll()
        {
            try
            {
                IEnumerable<ArticleGetDto> result = new List<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get().Adapt(result);
                return new ResultMessage
                {
                    Data = result.ToList(),
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
        public ResultMessage GetByCategoryId(int id)
        {
            try
            {
                IEnumerable<ArticleGetDto> result = new List<ArticleGetDto>();
                result = _unitOfWork.ArticlesRepository.Get(c => c.CategoryId == id).Adapt(result);
                return new ResultMessage
                {
                    Data = result.ToList(),
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
        public ResultMessage Insert(ArticleAddDto article, string userId)
        {
            var validationResult = _Validator.Validate(article);
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
                articleEntity.CreatedBy = userId;
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
        public ResultMessage Update(ArticleAddDto article, int id, string userId)
        {
            var validationResult = _Validator.Validate(article);
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
                var articleData = _unitOfWork.ArticlesRepository.GetById(id);
                if (articleData == null)
                {
                    return new ResultMessage
                    {
                        Status = HttpStatusCode.NotFound,
                    };
                }

                article.Adapt(articleData, typeof(ArticleAddDto), typeof(Shared.Core.Models.Articles));
                articleData.Id = id;
                articleData.UpdatedAt = DateTime.Now;
                articleData.UpdatedBy = userId;
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
    }
}
