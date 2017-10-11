

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function () {
    $(window).bind("load resize", function () {
        var topOffset = 50;
        var width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        var height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    // var element = $('ul.nav a').filter(function() {
    //     return this.href == url;
    // }).addClass('active').parent().parent().addClass('in').parent();
    var element = $('ul.nav a').filter(function () {
        return this.href == url;
    }).addClass('active').parent();

    while (true) {
        if (element.is('li')) {
            element = element.parent().addClass('in').parent();
        } else {
            break;
        }
    }
});
$("#addMerchant").on("click", function () {
    var merchantId = $("#merchantInputHidden").val();
    var merchantName = $("#merchantInput").val();

    if (merchantId != "") {

        var exist = $('ul li:contains(' + merchantName + ')').length;

        if (exist <= 1) {
            $("#merchant_area").append("<li id='merchant_" + merchantId + "' data-id='" + merchantId + "' class='merchant_label'> <span class='close delete_merchant'><i class='icon-remove-circle'></i></span>" + merchantName + "</li>");
        }
        else {
            alert('Lütfen aynı çiçeği birden çok kez girmeyiniz!');
        }

    } else {
        alert("@Html.Raw("Lütfen çiçek seçiniz!")");
    }

});