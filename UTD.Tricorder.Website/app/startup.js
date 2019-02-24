
confirmBackspaceNavigations();

setBootstrapNotifyDefaults();


$(function () { // page main loading mask
    setTimeout(function () {
        $('#mainloading').remove();
        $('#mainloading-mask').fadeOut({ remove: true });
    }, 10);
});

$("#menu-toggle").click(function (e) { // sidebar toggle
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
    arrangeUI();
});


