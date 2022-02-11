$(function () {
    var administrarFn = {
        imgBase64: '',
        init() {
            $('#btnCuenta').on('click', this.ModalNuevo);
            $('#frmCuenta').on('submit', this.Save);
            this.Get();
        },
        Get() {
            $('#ulListData').empty();
            UniversalFn.Api("Cuenta", "Get")
                .done(function (data) {
                    $(data.Resultado).each(function () {
                        $('#ulListData').append(' <li class="w3-bar">' +
                            '<img src="data:image/png;base64,' + this.ImgProfile + '" class="w3-bar-item w3-circle w3-hide-small" style="width:85px">' +
                            '<div class="w3-bar-item">' +
                            '<span class="w3-large">' + this.Nick + '</span><br>' +
                            '<span>' + this.Servidor + '</span>' +
                            '</div>' +
                            '</li>');
                    });
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    UniversalFn.LogError("Error en la consulta:", jqXHR);
                });
        },
        ModalNuevo() {
            $('#ModalNuevo').show();
            $('#frmCuenta')[0].reset();
        },
        Save(event) {
            event.preventDefault();
            var formData = new FormData();
            formData.append('file', document.getElementById("fileImg").files[0]);

            var Cuenta = {
                CuentaId: $('#ulListData li').length +1 ,
                Nick: $("#txtNick").val(),
                Servidor: $("#txtServer").val()
            };

            formData.append('ItemCuenta', JSON.stringify(Cuenta));

            UniversalFn.ApiFile("Cuenta", "Put", formData)
                .done(function (data) {
                    alertify.notify('Se guardaron los datos correctamente.', 'success', 5, function () { console.log('dismissed'); });
                    $('#ModalNuevo').hide();
                    administrarFn.Get();
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    UniversalFn.LogError("Error al guardar el perfil:", jqXHR);
                });


        }
    };

    administrarFn.init();
});