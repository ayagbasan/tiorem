var islemService = {

    

    data: function() {
        return {
            
        }
    },

    methods: {

        initialize: () => {

            let url = "https://nabizapp.com/app/v1.3/android_all_categories.php";

            const promise = appCore.aymkReq(url, null, "GET", "Kaynak listesi alınıypr", "XML");

            promise.then((response) => {

                app.dialog.alert("Yedek başarıyla sunucuya yüklenmiştir.");

            }).catch((xhr, textStatus, errorThrown) => {

                if (xhr.responseText)
                    app.dialog.alert(JSON.parse(xhr.responseText).message, "Hata");
                else
                    app.dialog.alert("Bilinmeyen bir hata oluştu", "Hata");
            });


        },

        birOncekiSayfayaGit: () => {


            if (app.view.main.history) {
                console.log(app.view.main.history);

                if (app.view.main.history.length > 1) {
                    let url = app.view.main.history[app.view.main.history.length - 2];
                    app.view.main.history.pop();
                    app.router.navigate(url, {
                        reloadCurrent: true,
                        ignoreCache: true,
                    });
                }

            }

        },



       

     

    },

    on: {

        pageInit: function(e, page) {

            
        },

    }
}


