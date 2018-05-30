var ayarlarService = {




    data: function() {
        return {
            ayarlar: app.data.ayarlar
        }
    },

    methods: {

        aymkReq: (serviceUrl, requestData, method, preloaderMessage) => {

            return new Promise((resolve, reject) => {


                app.dialog.progress(preloaderMessage);

                if (method === "POST") {
                    app.request.postJSON(
                        serviceUrl,
                        JSON.stringify(requestData),
                        function(data, textStatus) {

                            app.dialog.close();
                            resolve(data);

                        },
                        function(xhr, textStatus, errorThrown) {
                            app.dialog.close();
                            reject(xhr, textStatus, errorThrown);
                        },
                        "json"

                    );
                } else if (method === "GET") {
                    app.request.json(
                        serviceUrl,
                        requestData,
                        function(data, textStatus) {

                            app.dialog.close();
                            resolve(data);

                        },
                        function(xhr, textStatus, errorThrown) {
                            app.dialog.close();
                            reject(xhr, textStatus, errorThrown);
                        });

                }



            });
        },

        initialize: (selectObject) => {

            app.dialog.alert(selectObject);
        },

        kaydet: () => {

            var formData = app.form.convertToData('#settingsForm');
            formData.CarpanDegeri = parseInt(formData.CarpanDegeri);
            formData.EklemeYontemi = parseInt(formData.EklemeYontemi);
            formData.HesapMakinesiniKapat = parseInt(formData.HesapMakinesiniKapat);
            formData.SozlukAdlari = parseInt(formData.SozlukAdlari);
            formData.SiralamaYontemi = parseInt(formData.SiralamaYontemi);
            formData.ArtaKalanTuru = parseInt(formData.ArtaKalanTuru);


            appCore.saveData(config.localStorageTag.ayarlar, formData);
            app.data.ayarlar = formData;
            app.methods.initialize();

            app.dialog.alert("Ayarlarınız kayıt edildi");
        },
        yedekAl: () => {

            app.dialog.prompt('Yedekleme adı giriniz', function(name) {

                let backUpData = {
                    yedekAdi: name.toLocaleUpperCase("tr-TR").trim(),
                    tarih: new Date().toLocaleString(),
                    ayarlar: app.data.ayarlar,
                    hediyeList: app.data.hediyeList,
                    ziyaretList: app.data.ziyaretList,
                    programlarList: app.data.programlarList
                } 


                let url = "https://api.mlab.com/api/1/databases/hediyeci/collections/hediyeci_backup?apiKey=SmUMfyNUqrOpSvfko7pFiKWoRqxhk0eT";

                const promise = ayarlarService.methods.aymkReq(url, backUpData, "POST", "Hediyeci bilgileri sunucuya gönderiliyor...");

                promise.then((response) => {

                    app.dialog.alert("Yedek başarıyla sunucuya yüklenmiştir.");

                }).catch((xhr, textStatus, errorThrown) => {

                    if (xhr.responseText)
                        app.dialog.alert(JSON.parse(xhr.responseText).message, "Hata");
                    else
                        app.dialog.alert("Bilinmeyen bir hata oluştu", "Hata");
                });

            });

        },

        yedekDosyalariniGoster: () => {

            let data = "f={'tarih': 1,'yedekAdi':1}&s={'tarih':-1}";
            let url = 'https://api.mlab.com/api/1/databases/hediyeci/collections/hediyeci_backup?apiKey=SmUMfyNUqrOpSvfko7pFiKWoRqxhk0eT&' + data;
            const promise = ayarlarService.methods.aymkReq(url, null, "GET", "Yedekleme dosyaları listesi alınıyor");

            promise.then((response) => {

                let listTemplate = $$('script#ayarlarYedekDosyaTemplate').html();
                let compiledListTemplate = Template7.compile(listTemplate);
                let htmlContent = compiledListTemplate(response);
                $$("#yedekDosyaForm").html(htmlContent);


                app.popup.open(".popup-ayarlarYedekDosyalari");



            }).catch((xhr, textStatus, errorThrown) => {

                //if (xhr.responseText)
                //    app.dialog.alert(JSON.parse(xhr.responseText).message, "Hata");
                //else
                //    app.dialog.alert("Bilinmeyen bir hata oluştu", "Hata");

                app.dialog.alert(xhr.responseText, "Hata");
            });

        },

        yedektenYukle: () => {

            var formData = app.form.convertToData('#yedekDosyaForm');

            if (formData.dosyaAdi === "") {
                app.alert.dialog("Yedek dosyası seçiniz");
                return;
            }

            let data = "q={'tarih': '" + formData.dosyaAdi +"'}";
            let url = 'https://api.mlab.com/api/1/databases/hediyeci/collections/hediyeci_backup?apiKey=SmUMfyNUqrOpSvfko7pFiKWoRqxhk0eT&' + data;
            const promise = ayarlarService.methods.aymkReq(url, null, "GET", "Yedekten geri dönülüyor");

            promise.then((response) => {

                if (response.length === 1) {
                    appCore.saveData(config.localStorageTag.ayarlar, response[0].ayarlar);
                    appCore.saveData(config.localStorageTag.hediye, response[0].hediyeList);
                    appCore.saveData(config.localStorageTag.ziyaret, response[0].ziyaretList);
                    appCore.saveData(config.localStorageTag.programlar, response[0].programlarList);

                    app.methods.initialize();
                    app.popup.close(".popup-ayarlarYedekDosyalari");
                    app.dialog.alert("Yedekten geri dönme işlemi tamamlandı");
                } else {
                    app.dialog.alert("Yedek dosyası bulunamadı.");
                }
               

            }).catch((xhr, textStatus, errorThrown) => {

                //if (xhr.responseText)
                //    app.dialog.alert(JSON.parse(xhr.responseText).message, "Hata");
                //else
                //    app.dialog.alert("Bilinmeyen bir hata oluştu", "Hata"); 

                app.dialog.alert(xhr.responseText, "Hata");
            });
             
        }

    },

    on: {

        pageInit: function(e, page) {

            if (page.name === "ayarlar") {



            }
        },

    }
}


