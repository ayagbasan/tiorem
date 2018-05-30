routes = [
    {
        path: '/',
        url: './index.html',
    },
    {
        path: '/sozlukler/:tag/',
        async(routeTo, routeFrom, resolve, reject) {
            if (routeTo.params.tag) {
                sozlukService.tag = routeTo.params.tag;
                sozlukService.tmpItemList = appCore.tmpList(sozlukService.tag);
            }
            resolve({ componentUrl: "./pages/sozlukler.html" })
        },
    },
    // Default route (404 page). MUST BE THE LAST
    {
        path: '(.*)',
        url: './pages/404.html',
    },
];
