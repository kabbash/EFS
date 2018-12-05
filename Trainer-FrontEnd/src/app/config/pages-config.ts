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
            'name': 'productRating',
            'route': '/products/productRating',
        }
    },
    'login': {
        'name': 'login',
        'route': 'login',
        'loadChildren': './login/login.module#loginModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'loginPage': {
            'name': 'loginPage',
            'route': '/login/loginPage',
        },
        'register': {
            'name': 'register',
            'route': '/login/register',
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
};
