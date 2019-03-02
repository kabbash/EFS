export interface IAppConfig {
    pagination: {
        productsForAny: {
            pageSize: number;
        },
        productsForAdmin: {
            pageSize: number;
        },
        articlesForAny: {
            pageSize: number;
        },
        articlesForAdmin: {
            pageSize: number;
        },
        itemsForReview: {
            pageSize: number;
        },
        usersForAdmin:{
            pageSize:number;
        }
    };
}