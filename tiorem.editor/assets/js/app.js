// Dom7
var $$ = Dom7;



Template7.registerHelper('SozlukAdlari', function (value) {
    return parseFloat(value).toFixed(8);
}); 


var app = new Framework7({
    root: '#app',
    id: 'com.aymk.tiorem',
    name: config.appShortName,
    theme: 'auto',
    precompileTemplates: true,
    template7Pages: true,
    cache: false,
    
    dialog: {

        title: config.appShortName,
        buttonOk: 'Tamam',
        buttonCancel: "İptal"
    },
    data: function () {
        return {

            dummy:null,
        };
    },

    methods: {

       

       

    },
    on: {

        pageInit: function (page) {
            

        }
    },


    routes: routes,

});

let homeView = app.views.create('.view-main', {
    url: '/'
});


app.methods = islemService.methods;
app.data = islemService.data;
app.on = islemService.on;

app.methods.initialize();


