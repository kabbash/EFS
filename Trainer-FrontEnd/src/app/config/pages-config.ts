export let config = {
    'articles': {
        'name': 'articles',
        'route': 'articles',
        'loadChildren': '../app/articles/articles.module#ArticlesModule',
        // 'permissionList': ['Authorized'],
        /** this is capital to match routes for tagging  */
        'allArticles': {
            'name': 'allArticles',
            'route': 'articles/allArticles',
        }
    },
    'notfound': {
        'name': 'notfound',
        'route': 'notfound',
    }
};
