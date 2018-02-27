function tgAjx(model, url, func) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(model),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: func,
        error: function (xhr, errorType, exception) {
            if (xhr.readyState == 4 && xhr.status == 200) {
                location.reload();
            } else {
                mesajPopup("Hata Verisi : " + this.data, "error");
            }
        }
    });
} function mesajPopup(mesaj, mesajTipi) {
    //tipi : success, error, warning, info
    Command: toastr[mesajTipi](mesaj, "Mesaj")

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "500",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}