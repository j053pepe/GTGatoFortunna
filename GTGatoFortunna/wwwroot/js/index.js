$(function () {
    var indexFn = {
        init() {
            $('a').on('click', this.ClickMenu);
            this.LoadPage();
        },
        LoadPage() {
            var href = window.location.hash;
            indexFn.ShowHTML(href);
        },
        ClickMenu() {
            var href = event.currentTarget.getAttribute('href');
            indexFn.ShowHTML(href);
        },
        ShowHTML(href) {
            var item = {};

            if (href !== "#" && href !== "") {
                item = UniversalFn.Menu.find(x => x.Id == href);
                UniversalFn.LoadHTML(item.Pagina)
                    .done(function (html) {
                        $('#containerHome').hide();
                        html += "<script src='" + item.JS + "' />";
                        $('#container').html(html);
                        $('#container').show();
                    });
            } else {
                $('#containerHome').show();
                $('#container').html("");
                $('#container').hide();
            }
        }
    };

    indexFn.init();
});