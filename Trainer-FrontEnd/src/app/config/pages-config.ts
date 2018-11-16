export let config = {
    'articles': {
        'name': 'articles',
        'route': 'articles',
        'loadChildren': './articles/articles.module#ArticlesModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'allArticles': {
            'name': 'allArticles',
            'route': '/articles/allArticles',
        },
        'articlesCategories': {
            'name': 'articlesCategories',
            'route': '/articles/articlesCategories',
        },
        'articleDetails': {
            'name': 'articleDetails',
            'route': '/articles/articleDetails',
        }
    },
    'notfound': {
        'name': 'notfound',
        'route': 'notfound',
    }
};
