using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities.Enums
{
    public enum ProductsErrorsCodeEnum
    {
        ProductsCategoriesGetAllError,
        ProductsCategoriesInsertError,
        ProductsCategoriesNotFoundError,
        ProductsCategoriesGetByIdError,
        ProductsCategoriesUpdateError,
        ProductsCategoriesDeleteError,
        ProductsGetAllError,
        ProductsInsertError,
        ProductsNotFoundError,
        ProductsGetByIdError,
        ProductsUpdateError,
        ProductsDeleteError,
        ProductsSubCategoriesGetAllError,
        ProductsSubCategoriesInsertError,
        ProductsSubCategoriesNotFoundError,
        ProductsSubCategoriesGetByIdError,
        ProductsSubCategoriesUpdateError,
        ProductsSubCategoriesDeleteError,
    }
    public enum AttachmentsErrorsCodeEnum
    {
        AttachmentsUploadError
    }
    public enum AuthenticationErrorsCodeEnum
    {
        AuthenticationError,
        EmailNotConfirmed,
        UserDoesNotExist,
        OldPasswordMismatch,
        UserBlocked,
        RoleDoesNotExist,
        UserRoleError
    }
    public enum RatingErrorsCodeEnum
    {
        RatingInsertError
    }
    public enum ItemsReviewsErrorsCodeEnum
    {
        ItemsGetAllError,
        ItemsInsertError,
        ItemsNotFoundError,
        ItemsGetByIdError,
        ItemsUpdateError,
        ItemsDeleteError
    }

    public enum BannersErrorsCodeEnum
    {
        GetAllError,
        AddError,
        NotFoundError,
        GetByIdError,
        UpdateError,
        DeleteError
    }
    public enum FoodItemsErrorsCodeEnum
    {
        GetAllError,
        AddError,
        NotFoundError,
        GetByIdError,
        UpdateError,
        DeleteError
    }
}
