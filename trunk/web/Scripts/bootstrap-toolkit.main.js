// Wrap IIFE around your code
(function ($, document, window, viewport) {

    var MyForm = document.forms['form1'];
    if (!MyForm) { MyForm = document.form1; }

    // Executes once whole document has been loaded
    $(document).ready(function () {
        if (viewport.is('xs')) {
            MyForm.BootstrapResponsiveMode.value = 'Mobile_XS';
        }

        if (viewport.is('sm')) {
            MyForm.BootstrapResponsiveMode.value = 'Mobile_SM';
        }

        if (viewport.is('md')) {
            MyForm.BootstrapResponsiveMode.value = 'Desktop_MD';
            MyForm.PlayListGridViewPageSize.value = Math.floor(($(window).height() - 222) / 49.2);
            MyForm.SingerListViewPageSize.value = Math.floor(($(window).height() - 292) / 107) * 6;
        }

        if (viewport.is('lg')) {
            MyForm.BootstrapResponsiveMode.value = 'Desktop_LG';
            MyForm.PlayListGridViewPageSize.value = Math.floor(($(window).height() - 222) / 49.2);
            MyForm.SingerListViewPageSize.value = Math.floor(($(window).height() - 292) / 136) * 6;
        }
        
        MyForm.WindowWidth.value = $(window).width();
        document.getElementById("RefreshUpdatePanelButton").click();
    });

    // Execute code each time window size changes
    $(window).resize(
        viewport.changed(function () {
            if (viewport.is('xs')) {
                MyForm.BootstrapResponsiveMode.value = 'Mobile_XS';
            }

            if (viewport.is('sm')) {
                MyForm.BootstrapResponsiveMode.value = 'Mobile_SM';
            }

            if (viewport.is('md')) {
                MyForm.BootstrapResponsiveMode.value = 'Desktop_MD';
                MyForm.PlayListGridViewPageSize.value = Math.floor(($(window).height() - 222) / 49.2);
                MyForm.SingerListViewPageSize.value = Math.floor(($(window).height() - 292) / 107) * 6;
            }

            if (viewport.is('lg')) {
                MyForm.BootstrapResponsiveMode.value = 'Desktop_LG';
                MyForm.PlayListGridViewPageSize.value = Math.floor(($(window).height() - 222) / 49.2);
                MyForm.SingerListViewPageSize.value = Math.floor(($(window).height() - 292) / 136) * 6;
            }

            if (viewport.is('md') || viewport.is('lg')) {
                MyForm.WindowWidth.value = $(window).width();
                document.getElementById("RefreshUpdatePanelButton").click();
            }
            else {
                if (parseInt(MyForm.WindowWidth.value) != $(window).width()) {
                    MyForm.WindowWidth.value = $(window).width();
                    document.getElementById("RefreshUpdatePanelButton").click();
                }
            }
        })
    );
    
})(jQuery, document, window, ResponsiveBootstrapToolkit);