export interface IAppConfig {
    pagination: {
        productsForAny: {
            pageSize: number;
        },
        specialProductsForAny: {
            pageSize: number;
        },
        productsForAdmin: {
            pageSize: number;
        },
        productsForOwners: {
            pageSize: number;
        }
        articlesForAny: {
            pageSize: number;
        },
        articlesForAdmin: {
            pageSize: number;
        },
        articlesForWriters: {
            pageSize: number;
        },
        itemsForReview: {
            pageSize: number;
        },
        usersForAdmin: {
            pageSize: number;
        },
        neutrintsForAdmin: {
            pageSize: number;
        }
    };
}