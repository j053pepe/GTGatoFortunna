$(function () {
    var fortunaFn = {
        init() {
            $('#mainGato').hide();            
            this.GetMeses();
            $('#ulListData').on('click', 'button', this.MostrarGato);
            $('#btnBack').on('click', this.Back);
            $('#btnNuevo').on('click', this.ModalNuevo);
            $('#txtIniciales').on('change', this.GemasIniciales);
            $('#frmGato').on('submit', this.Save);
        },
        GetMeses() {
            var $dropdown = $("#slcMes");
            $dropdown.append($("<option />").val("").text("Selecciona un Mes"));
            UniversalFn.Api("Mes", "Get")
                .done(function (data) {
                    $(data.Resultado).each(function () {
                        $dropdown.append($("<option />").val(this.MesId).text(this.Nombre));
                    });
                    fortunaFn.Get();
                });
        },
        Back() {
            $('#mainLista').show();
            $('#mainGato').hide();
            fortunaFn.Get();
        },
        MostrarGato() {
            $('#mainLista').hide();
            $('#mainGato').show();
            var datalog = $('#' + $(this)[0].parentNode.id).data('item');
            $('#mainGato').data('Item', datalog);

            //Perfil
            document.getElementById('imgProfile')
                .setAttribute(
                    'src', 'data:image/png;base64,' + datalog.ImgProfile
                );
            $('#txtNombre').text('NickName: ' + datalog.Nick);
            $('#txtServer').text('Servidor: ' + datalog.Servidor);

            fortunaFn.PintarTabla(datalog.MesGato);
        },
        PintarTabla(Registros) {
            $("#tblTiros > tbody").html("");
            //Tabla            
            var tabla = '<tbody>';
            $(Registros).each(function () {
                tabla += '<tr><td>' + this.Id + '</td>';
                tabla += '<td>' + this.Año + '</td>';
                tabla += '<td>' + $('#slcMes option[value="' + this.MesId + '"]').text() + '</td>';
                tabla += '<td>' + moment(this.FechaCreacion).format('DD/MM/YYYY, h:mm:ss a') + '</td>';
                tabla += '<td>' + this.InvocacionesBase + '</td>';
                tabla += '<td>' + this.InvocacionesResultado + '</td></tr>';
            });

            tabla += '</tbody>';
            $('#tblTiros').append(tabla);
        },
        ModalNuevo() {
            $('#ModalGato').show();
            $('#frmGato')[0].reset();
            fortunaFn.GetConfig();
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
        },
        GetConfig() {
            $("#divTiros").empty();
            UniversalFn.Api("TirosGato", "Get")
                .done(function (data) {
                    var tiros = '';
                    var lstId = [];

                    $(data.Resultado).each(function () {
                        lstId.push({
                            lblBase: 'txtP' + this.Numero + 'Red',
                            txtResultado: 'txtP' + this.Numero + 'Res',
                            lblGanancia: 'txtP' + this.Numero + 'Gan',
                            txtSubtotal: 'txtP' + this.Numero + 'Sub'
                        });

                        tiros += '<div class="w3-row">' +
                            '<div class="w3-section">' +
                            '<div class="w3-col m3">' +
                            '<label class="w3-text-red"><b>Base ' + this.Nombre + '</b></label>' +
                            '<label class="w3-input w3-border"  id="txtP' + this.Numero + 'Red" data-id="txtP' + (this.Numero + 1) + 'Red">' + this.BaseTiro + '</label>' +
                            '</div>' +
                            '<div class="w3-col m3">' +
                            '<label class="w3-text-blue"><b>Resultado</b></label>' +
                            '<input class="w3-input w3-border" type="number" id="txtP' + this.Numero + 'Res" />' +
                            '</div>' +
                            '<div class="w3-col m3">' +
                            '<label class="w3-text-red"><b>Ganancia</b></label>' +
                            '<label class="w3-input w3-border" type="number" id="txtP' + this.Numero + 'Gan">&nbsp</label>' +
                            '</div>' +
                            '<div class="w3-col m3">' +
                            '<label class="w3-text-red"><b>Subtotal</b></label>' +
                            '<input class="w3-input w3-border" type="number" id="txtP' + this.Numero + 'Sub"></input>' +
                            '</div>' +
                            '</div>' +
                            '</div>';
                    });

                    $("#divTiros").append(tiros);

                    $(lstId).each(function () {
                        $("#" + this.txtResultado).on('change', fortunaFn.ChangeVal);
                        $("#" + this.txtResultado).data('lblGanancia', this.lblGanancia);
                        $("#" + this.txtResultado).data('txtSubtotal', this.txtSubtotal);
                        $("#" + this.txtResultado).data('txtResultado', this.txtResultado);
                        $("#" + this.txtResultado).data('lblBase', this.lblBase);

                        $("#" + this.txtSubtotal).on('change', fortunaFn.ChangeVal);
                        $("#" + this.txtSubtotal).data('lblGanancia', this.lblGanancia);
                        $("#" + this.txtSubtotal).data('txtResultado', this.txtResultado);
                        $("#" + this.txtSubtotal).data('txtSubtotal', this.txtSubtotal);
                        $("#" + this.txtSubtotal).data('lblBase', this.lblBase);
                    });
                });
        },
        GemasIniciales() {
            var resultGato = {};
            $('#frmGato').data('anterior', $(this).val());
            $('#frmGato').data('tiros', resultGato);
        },
        Save(e) {
            e.preventDefault();
            var itemGeneral = $('#mainGato').data('Item');
            var item = $('#frmGato').data('tiros');
            if (item.TirosGato == undefined) {
                alertify.error('Favor de ingresar por lo menos un tiro del gato.');
                return false;
            }

            item.Id = itemGeneral.MesGato.length + 1;
            item.Año = $('#txtAño').val();
            item.MesId = parseInt($('#slcMes').val());
            item.InvocacionesBase = $('#txtIniciales').val();

            itemGeneral.MesGato = [item];

            $('#ModalGato').hide();
            UniversalFn.Api("TirosGato", "Put", itemGeneral)
                .done(function (data) {
                    alertify.notify('Se guardaron los datos correctamente.', 'success', 5, function () { console.log('dismissed'); });
                    fortunaFn.PintarTabla(data.Resultado.MesGato);
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    UniversalFn.LogError("Error al guardar los tiros del gato:", jqXHR, textStatus, errorThrown);
                    alertify.error('Error al guardar.');
                    $('#ModalGato').show();
                });
        },
        ChangeVal() {
            if ($('#txtIniciales').val() > 0) {
                var id = {
                    lblGanancia: $(this).data('lblGanancia'),
                    lblBase: $(this).data('lblBase'),
                    txtSubtotal: $(this).data('txtSubtotal'),
                    txtResultado: $(this).data('txtResultado')
                };

                var idlblBaseSiguiente = document.getElementById(id.lblBase).dataset.id;

                var resultAnterior = $('#' + id.lblBase).data('anterior') === undefined ? parseInt($('#frmGato').data('anterior')) : $('#' + id.lblBase).data('anterior');
                var base = parseInt($('#' + id.lblBase).text());
                var resultado = 0, ganadas = 0;

                if (id.txtSubtotal !== this.id) {
                    resultado = $(this).val();
                    ganadas = resultado - base;
                    $('#' + id.txtSubtotal).val(ganadas + resultAnterior);
                } else {
                    ganadas = $(this).val() - resultAnterior;
                    resultado = base + ganadas;
                    $('#' + id.txtResultado).val(resultado);
                }

                $('#' + id.lblGanancia).text(ganadas);
                $('#' + idlblBaseSiguiente).data('anterior', ganadas + resultAnterior);
                $('#txtGemasTotales').val(ganadas + resultAnterior);
                $('#txtGemasGanadas').val((ganadas + resultAnterior) - parseInt($('#frmGato').data('anterior')));

                var tiros = $('#frmGato').data('tiros');
                tiros.InvocacionesResultado = $('#txtGemasTotales').val();

                tiros.TirosGato = tiros.TirosGato == undefined ? [] : tiros.TirosGato;
                tiros.TirosGato.push({
                    Requerido: base,
                    Obtenido: ganadas,
                    Subtotal: ganadas + resultAnterior
                });
            } else {
                $(this).val('');
                alertify.error('Favor de ingresar Gemas Iniciales.');
                return false;
            }
        }
    };

    fortunaFn.init();
});