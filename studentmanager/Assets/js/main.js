$(function(){
    $("#ResponsibleId").on("change", function(){
        var responsible_id = $(this).val();

        $.get("Lessons/getresponsibles", { id : responsible_id}, function(data) {
            $("#responsible").empty();
            $.each(data, function(index, row){
                $("#responsible").append("<option value='"+ row.Id +"'>"+ row.NameLesson +"</option>");
            });
        });
    });
});