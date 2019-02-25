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
        'championships' : {
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
    }
    }
};
