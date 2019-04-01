namespace Shared.Core.Utilities.Enums
{
    public enum ProductsErrorsCodeEnum
    {
        ProductsCategoriesGetAllError = 1 ,
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
        ValidationProductNameRequired,
        ValidationPriceRequired,
        ValidationProductCategoryRequired,
        ValidationProductExpDateRequired,
        ValidationProductImageRequired
    }
    public enum ArticlesErrorsCodeEnum
    {
        ArticlesCategoriesGetAllError =1,
        ArticlesCategoriesInsertError,
        ArticlesCategoriesNotFoundError,
        ArticlesCategoriesGetByIdError,
        ArticlesCategoriesUpdateError,
        ArticlesCategoriesDeleteError,
        ArticlesGetAllError,
        ArticlesInsertError,
        ArticlesNotFoundError,
        ArticlesGetByIdError,
        ArticlesUpdateError,
        ArticlesDeleteError,
        ArticlesSubCategoriesGetAllError,
        ArticlesSubCategoriesInsertError,
        ArticlesSubCategoriesNotFoundError,
        ArticlesSubCategoriesGetByIdError,
        ArticlesSubCategoriesUpdateError,
        ArticlesSubCategoriesDeleteError,
        ValidationsArticleNameRequired,
        ValidationsArticleDescRequired,
        ValidationsCategoryNameRequired
    }
    public enum AttachmentsErrorsCodeEnum
    {
        AttachmentsUploadError=1,
        ValidationFileEmpty,
        ValidationFileNameRequired
    }
    public enum AuthenticationErrorsCodeEnum
    {
        AuthenticationError =1,
        EmailNotConfirmed,
        UserDoesNotExist,
        OldPasswordMismatch,
        UserBlocked,
        RoleDoesNotExist,
        UserRoleError,
        ValidationEmailRequired,
        ValidationEmailInvalid,
        ValidationFullNameRequired,
        ValidationPasswordRequired
    }
    public enum RatingErrorsCodeEnum
    {
        RatingInsertError=1,
        ValidationRateRequired,
        ValidationEntityIdRequired,
        ValidationEntityTypeRequired
    }
    public enum OTrainingErrorsCodeEnum
    {
        ValidationDescriptionRequired=1,
        ValidationForJoinRequired,
        ValidationProgramFeaturesRequired,
        ValidationProgramNameRequired
    }
    public enum ItemsReviewsErrorsCodeEnum
    {
        ItemsGetAllError =1,
        ItemsInsertError,
        ItemsNotFoundError,
        ItemsGetByIdError,
        ItemsUpdateError,
        ItemsDeleteError,
        ValidationNameRequired
    }

    public enum BannersErrorsCodeEnum
    {
        GetAllError =1,
        AddError,
        NotFoundError,
        GetByIdError,
        UpdateError,
        DeleteError,
        ValidationTitleRequired,
        ValidationImageRequired,
        ValidationButtonTextRequired,
        ValidationButtonURLRequired
    }
    public enum FoodItemsErrorsCodeEnum
    {
        GetAllError =1,
        AddError,
        NotFoundError,
        GetByIdError,
        UpdateError,
        DeleteError
    }

    public enum HomeErrorsCodeEnum
    {
        ContactUs =1,
        ValidationEmailRequired,
        ValidationEmailInvalid,
        ValidationNameRequired,
        ValidationDetailsRequired,
        ValidationPhoneNumRequired
    }

    public enum SharedErrorsCodeEnum
    {
        ValidationRejectIdRequired =1,
        ValidationRejectReasonRequired
    }
}
