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
        }

        if (viewport.is('lg')) {
            MyForm.BootstrapResponsiveMode.value = 'Desktop_LG';
        }

        if (!document.fullscreenElement && !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {
            MyForm.BrowserScreenMode.value = 'Window';
        } else {
            MyForm.BrowserScreenMode.value = 'Fullscreen';
        }
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
            }

            if (viewport.is('lg')) {
                MyForm.BootstrapResponsiveMode.value = 'Desktop_LG';
            }

            if (!document.fullscreenElement && !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {
                MyForm.BrowserScreenMode.value = 'Window';
            } else {
                MyForm.BrowserScreenMode.value = 'Fullscreen';
            }
            document.getElementById("RefreshUpdatePanelButton").click();
        })
    );
    
})(jQuery, document, window, ResponsiveBootstrapToolkit);