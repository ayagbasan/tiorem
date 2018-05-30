var appCore = {

    aymkReq: (serviceUrl, requestData, method, preloaderMessage,format) => {

        return new Promise((resolve, reject) => {

            if (format === null)
                format = "JSON";

            app.dialog.progress(preloaderMessage);

            if (method === "POST" && format==="JSON") {
                app.request.postJSON(
                    serviceUrl,
                    JSON.stringify(requestData),
                    function (data, textStatus) {

                        app.dialog.close();
                        resolve(data);

                    },
                    function (xhr, textStatus, errorThrown) {
                        app.dialog.close();
                        reject(xhr, textStatus, errorThrown);
                    },
                    "json"

                );
            }
            else if (method === "GET" && format === "JSON") {
                app.request.json(
                    serviceUrl,
                    requestData,
                    function (data, textStatus) {

                        app.dialog.close();
                        resolve(data);

                    },
                    function (xhr, textStatus, errorThrown) {
                        app.dialog.close();
                        reject(xhr, textStatus, errorThrown);
                    });

            }
            else if (method === "GET" && format === "XML") {
                app.request.get(
                    serviceUrl,
                    requestData,
                    function (data, textStatus) {

                        app.dialog.close();
                        resolve(data);

                    },
                    function (xhr, textStatus, errorThrown) {
                        app.dialog.close();
                        reject(xhr, textStatus, errorThrown);
                    });

            }




        });
    },
    

    sirala: (key, order = 'asc') => {

        return function(a, b) {
            if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
                return 0;
            }

            const varA = (typeof a[key] === 'string') ?
                a[key].toUpperCase() : a[key];
            const varB = (typeof b[key] === 'string') ?
                b[key].toUpperCase() : b[key];

            let comparison = 0;
            if (varA > varB) {
                comparison = 1;
            } else if (varA < varB) {
                comparison = -1;
            }
            return (
                (order == 'desc') ? (comparison * -1) : comparison
            );

        }


    }




}


