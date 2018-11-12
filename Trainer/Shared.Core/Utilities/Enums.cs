using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities
{
    public enum ErrorsCodeEnum
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
        RatingInsertError,
        AttachmentsUploadError,
        AuthenticationError,
    }

    public enum AttachmentTypesEnum
    {
        Product,
        Category,
        SubCategory
    }

    public enum EntityTypesEnum
    {
        Product = 1
    }
}
