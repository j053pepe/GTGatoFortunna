$(function () {
    var consultaFn = {
        init() {
            $('#mainGato').hide();
            this.Get();
        },
        Get() {
            $('#ulListData').empty();
            UniversalFn.Api("Cuenta", "Get")
                .done(function (data) {

                    $(data.Resultado).each(function () {
                        $('#ulListData').append(' <li class="w3-bar" id="liItem' + this.CuentaId + '">' +
                            '<button class="btn"><i class="fas fa-dharmachakra fas-2xl"></i> Tiradas</button>' +
                            '<img src="data:image/png;base64,' + this.ImgProfile + '" class="w3-bar-item w3-circle w3-hide-small" style="width:100px;height: 85px;">' +
                            '<div class="w3-bar-item">' +
                            '<span class="w3-large">' + this.Nick + '</span><br>' +
                            '<span>' + this.Servidor + '</span>' +
                            '</div>' +
                            '</li>');

                        $("#liItem" + this.CuentaId).data('item', this);
                    });
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    UniversalFn.LogError("Error en la consulta:", jqXHR, textStatus, errorThrown);
                    alertify.error('Error al consultar.');
                });
        }
    };


    consultaFn.init();
});