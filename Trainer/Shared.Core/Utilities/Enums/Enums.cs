namespace Shared.Core.Utilities.Enums
{
    public enum AttachmentTypesEnum
    {
        Products_Categories,
        Products,
        Articles_Categories,
        Articles,
        Temp,
        Banners
    }
    public enum RatingEntityTypesEnum
    {
        ItemsForReview =1,
        Product = 2
    }

    public enum PredefinedArticlesCategories
    {
        Food = 1,
        News = 2,
        Championships = 3
    }

    public enum EntityDDLEnum
    {
        ProductCategories = 1 ,
        ArticlesCategories
    }

    public enum StatusFilterEnum
    {
        All = 0,
        Active,
        Pending,
        Rejected
    }

    public enum UserRoles
    {
        Admin,
        RegularUser,
        Client,
        ProductOwner,
        ArticleWriter
    }
}
