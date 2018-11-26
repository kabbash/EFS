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
        'allProducts': {
            'name': 'allProducts',
            'route': '/products/allProducts',
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
