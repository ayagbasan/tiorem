let config = {

    appShortName: "TİOREM",
    appFullName: "Haber Editörü Paneli",
    errorCaption: "Hata",
    successCaption: "Başarılı",
 
    localStorageTag: {        
        categories: "Hediye",    
        settings: "Ayarlar"
    },  
   
    envEnums: {
        DEV: { value: 0, name: "Development", code: "D", apiURL: "http://localhost:63025/api/" },
        PROD: { value: 1, name: "Production", code: "P", apiURL: "https://aymkapi.herokuapp.com/" }
    },  
    
   

    toast: (msg, position = "top") => {
        var toastTop = app.toast.create({
            text: msg,
            position: "center",
            closeTimeout: 1000,
            cssClass: "text-align-left",
            icon: '<i class="fa fa-info-circle"></i>'
        }).open();
    },

   
};
