$(function(){
    $("#responsibleId").on("change", function(){
        var responsible_id = $(this).val();
        $.get("responsibles/getresponsibles/" , { "idresponsible " : responsible_id}, function(data) {
            var responsible = $("#responsible");

        });
    })
}