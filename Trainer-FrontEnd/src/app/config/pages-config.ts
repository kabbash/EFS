export let config = {
    'articles': {
        'name': 'articles',
        'route': 'articles',
        'loadChildren': './articles/articles.module#ArticlesModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'articlesList': {
            'name': 'articlesList/:categoryId',
            'route': '/articles/articlesList',
        },
        'articlesCategories': {
            'name': 'articlesCategories',
            'route': '/articles/articlesCategories',
        },
        'articleDetails': {
            'name': 'articleDetails/:articleId',
            'route': '/articles/articleDetails',
        },
        'news': {
            'name': 'news',
            'route': '/articles/news'
        },
        'food': {
            'name': 'food',
            'route': '/articles/food'
        },
        'championships': {
            'name': 'championships',
            'route': '/articles/championships'
        }
    }, 'yourTools': {
        'name': 'yourTools',
        'route': 'yourTools',
        'loadChildren': './your-tools/your-tools.module#YourToolsModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'calculators': {
            'name': 'calculators',
            'route': '/yourTools/calculators',
        }, 'carbCalc': {
            'name': 'carbCalc',
            'route': '/yourTools/carbCalc',
        }, 'protienCalc': {
            'name': 'protienCalc',
            'route': '/yourTools/protienCalc',
        }, 'fatCalc': {
            'name': 'fatCalc',
            'route': '/yourTools/fatCalc',
        }, 'healthyFatCalc': {
            'name': 'healthyFatCalc',
            'route': '/yourTools/healthyFatCalc',
        }, 'perfectWeightCalc': {
            'name': 'perfectWeightCalc',
            'route': '/yourTools/perfectWeightCalc',
        },
        'allCalculators': {
            'name': 'allCalculators',
            'route': '/yourTools/allCalculators',
        },
        'meals': {
            'name': 'meals',
            'route': '/yourTools/meals',
        }
    }, 'contactus': {
        'name': 'contactus',
        'route': 'contactus',
        'loadChildren': './contactus/contactus.module#ContactusModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'form': {
            'name': 'contactusForm',
            'route': '/contactus/contactusForm',
        },
        'bio': {
            'name': 'bio',
            'route': '/contactus/bio',
        }
    },
    'products': {
        'name': 'products',
        'route': 'products',
        'loadChildren': './products/products.module#ProductsModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'productsList': {
            'name': 'productsList/:categoryId',
            'route': '/products/productsList',
        },
        'productsCategories': {
            'name': 'productsCategories',
            'route': '/products/productsCategories',
        },
        'productRating': {
            'name': 'productRating/:productId',
            'route': '/products/productRating',
        },
        'productReviews': {
            'name': 'productReviews',
            'route': '/products/productReviews'
        }
    },
    'userAccount': {
        'name': 'userAccount',
        'route': 'userAccount',
        'loadChildren': './user-account/user-account.module#UserAccountModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'loginPage': {
            'name': 'loginPage',
            'route': '/userAccount/loginPage',
        },
        'register': {
            'name': 'register',
            'route': '/userAccount/register',
        },
        'confirmEmail': {
            'name': 'activateAccount',
            'route': '/userAccount/activateAccount',
        },
        'emailNotConfirmed': {
            'name': 'emailNotConfirmed',
            'route': '/userAccount/emailNotConfirmed',
        },
        'accountRegistered': {
            'name': 'accountRegistered',
            'route': '/userAccount/accountRegistered',
        },
        'resetPassword': {
            'name': 'resetPassword',
            'route': '/userAccount/resetPassword',
        },
        'setResetedPassword': {
            'name': 'setResetedPassword',
            'route': '/userAccount/setResetedPassword',
        },
        'changePassword': {
            'name': 'changePassword',
            'route': '/userAccount/changePassword',
        }
    },
    'notfound': {
        'name': 'notfound',
        'route': 'notfound',
    },
    'demos': {
        'name': 'demos',
        'route': 'demos',
        'loadChildren': './demos/demos.module#DemosModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'allDemos': {
            'name': 'allDemos',
            'route': '/demos/allDemos',
        },
        'forms': {
            'name': 'forms',
            'route': '/demos/forms',
        },
        'dropdowns': {
            'name': 'dropdowns',
            'route': '/demos/dropdowns',
        },
        'pagination': {
            'name': 'pagination',
            'route': '/demos/pagination',
        }
    },
    'home': {
        'name': 'home',
        'route': '/'
    },
    'admin': {
        'name': 'admin',
        'route': 'admin',
        //   'loadChildren': './admin/admin.module#AdminToolsModule',

        'addCategory': {
            'name': 'addCategory',
            'route': '/admin/addCategory'
        },
        'manageArticlesCategories': {
            'name': 'manageArticlesCategories',
            'route': '/admin/manageArticlesCategories'
        },
        'addArticle': {
            'name': 'addArticle',
            'route': '/admin/addArticle'
        },
        'manageArticles': {
            'name': 'manageArticles/:articleId',
            'route': '/admin/manageArticles'
        },
        'articleslist': {
            'name': 'articleslist',
            'route': '/admin/articleslist'
        },
        'manageProductsCategories': {
            'name': 'manageProductsCategories',
            'route': '/admin/manageProductsCategories'
        },
        'addItemForReview': {
            'name': 'addItemForReview',
            'route': '/admin/addItemForReview'
        },
        'itemReviewList': {
            'name': 'itemReviewList',
            'route': '/admin/itemReviewList'
        },
        'manageProducts': {
            'name': 'manageProducts/:productId',
            'route': '/admin/manageProducts'
        },
        'ProductsList': {
            'name': 'ProductList',
            'route': '/admin/ProductList'
        },
        'addBanner': {
            'name': 'addBanner',
            'route': '/admin/addBanner'
        },
        'editBanner': {
            'name': 'editBanner/:bannerId',
            'route': '/admin/editBanner/:bannerId'
        },
        'manageBanners': {
            'name': 'manageBanners',
            'route': '/admin/manageBanners'
        },
        'onlineTraining': {
            'name': 'onlineTraining',
            'route': '/admin/onlineTraining'
        },
        'managePrograms': {
            'name': 'managePrograms/:programId',
            'route': '/admin/managePrograms'
        },
        'users': {
            'name': 'users',
            'route': '/admin/users'
        },
        'neutrintsList': {
            'name': 'neutrintsList',
            'route': '/admin/neutrintsList'
        },
        'manageNeutrints': {
            'name': 'manageNeutrints/:foodItemId',
            'route': '/admin/manageNeutrints'
        }
    },
    'writers': {
        'name': 'writers',
        'route': 'writers',
        'loadChildren': './writers/writers.module#WritersModule',

        'manageArticle': {
            'name': 'manageArticle/:articleId',
            'route': '/writers/manageArticle'
        },
        'articleslist': {
            'name': 'articleslist',
            'route': '/writers/articleslist'
        }
    },
    'users': {
        'name': 'users',
        'route': 'users',
        'loadChildren': './users/users.module#UsersModule',

        'manageproduct': {
            'name': 'manageproduct/:productId',
            'route': '/users/manageproduct'
        },
        'productslist': {
            'name': 'productslist',
            'route': '/users/productslist'
        }
    },
    'onlinetraining': {
        'name': 'onlinetraining',
        'route': 'onlinetraining',
        'loadChildren': './online-training/online-training.module#OnlineTrainingModule',
        // 'onlinetraining': {
        //     'name': 'allDemos',
        //     'route': '/demos/allDemos',
        // },
    },

};
