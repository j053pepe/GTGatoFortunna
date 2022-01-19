var UniversalFn = {
    Api(Controller, Accion, Data) {
        var $def = $.Deferred();
        $.ajax({
            cache: false,
            type: Accion,
            url: '/Api/' + Controller,
            data: JSON.stringify(Data),
            contentType: "application/json",
            dataType: "json",
        }).fail(function (jqXHR, textStatus, errorThrown) {
            $def.reject(jqXHR, textStatus, errorThrown);
        }).done(function (data, textStatus, jqXHR) {
            $def.resolve(data);
        });

        return $def.promise();
    },
    ApiFile(Controller, Accion, form) {
        var $def = $.Deferred();
        $.ajax({
            cache: false,
            type: Accion,
            url: '/Api/' + Controller,
            data: form,
            enctype: 'multipart/form-data',
            processData: false,  // tell jQuery not to process the data
            contentType: false,  // tell jQuery not to set contentType
        }).fail(function (jqXHR, textStatus, errorThrown) {
            $def.reject(jqXHR, textStatus, errorThrown);
        }).done(function (data, textStatus, jqXHR) {
            $def.resolve(data);
        });

        return $def.promise();
    },
    LoadHTML(url) {
        var $def = $.Deferred();
        $.ajax({
            cache: false,
            url: url,
            dataType: "html"
        }).fail(function (jqXHR, textStatus, errorThrown) {
            $def.reject(jqXHR, textStatus, errorThrown);
        }).done(function (data, textStatus, jqXHR) {
            $def.resolve(data);
        });

        return $def.promise();
    },
    LogError(Mensaje, jqXHR, textStatus, errorThrown) {
        console.log(Mensaje);
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    },
    Menu: [{
        Pagina: "/Views/Cuenta/Administrar.html",
        JS: "/js/Cuenta/Administrar.js",
        Id: "#1"
    },
    {
        Pagina: "/Views/Fortuna/Agregar.html",
        JS: "/js/Fortuna/Agregar.js",
        Id: "#2"
    },
    {
        Pagina: "/Views/Reportes/Consulta.html",
        JS: "/js/Reportes/Consulta.js",
        Id: "#3"
    },
    {
        Pagina: "/index.html",
        JS: "/index.js",
        Id: "0"
    }]
};