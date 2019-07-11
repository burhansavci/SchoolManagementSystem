//datatable new button
$(document).ready(function () {
    $('#dataTable_length').append($(`<label>
                                      <label class=" col-sm-2 col-md-1"></label>
                                      <a href="#" data-target="#addModal" data-toggle="modal" class="btn btn-success btn-icon-split btn-sm">
                                      <span class="icon text-gray-50">
                                      <i class="fas fa-user-plus"></i>
                                      </span>
                                 <span class="text" style="font-size:16px">Yeni Ders Ekle</span>
                                      </a>
                                    </label>`)).html();

    //Mouseover functions
    $('table#dataTable tbody').on('mouseover', 'tr td .btn-warning', function () {
        $(this).attr('title', 'Güncelle');
    });
    $('table#dataTable tbody').on('mouseover', 'tr td .btn-danger', function () {
        $(this).attr('title', 'Sil');
    });

    //Global Variables
    var redirectUrl = location.href;
    var table = $('#dataTable').DataTable();

    //Delete
    $('table#dataTable tbody').on('click', 'tr td .btn-danger', function () {
        currentRow = $(this).closest("tr");
        var lessonName = currentRow.find(".lessonName").html();
        $("#toBeDeletedLesson").html(`${lessonName}`);
    });
    $('#dataTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
    $(".btn-delete").click(function () {
        var lessonId = currentRow.find(".settings").children(".hiddenLessonId").attr("value");
        $.ajax({
            url: "/panel/lesson/delete",
            method: "post",
            data: {
                lessonId: lessonId,
            },
            success: function (res) {
                alert("Silme işlemi başarıyla gerçekleşti.");
                $("#deleteModal").modal("hide");
                table.row('.selected').remove().draw(false);
            }
        });
    });

    //Add
    $(".btn-success").click(function () {
        $("#lessonName").val("");
    });
    $("#addButton").click(function () {
        var lessonName = $("#lessonName").val();
        var data = {
            Name: lessonName,
            RedirectUrl: redirectUrl,
        }
        $.ajax({
            url: "/panel/lesson/post",
            method: "post",
            data: data,
            success: function (res) {
                alert("Ekleme işlemi başarıyla gerçekleşti.");
                location.href = location.href;
            }
        });
    });
    //Update
    $('table#dataTable tbody').on('click', 'tr td .btn-warning', function () {
        currentRow = $(this).closest("tr");
        $("#updateLessonName").val(currentRow.find(".lessonName").html());
        $("#hiddenLessonId").val(currentRow.find(".hiddenLessonId").val());
    });
    $("#updateButton").click(function () {
        var lessonId = $("#hiddenLessonId").val();
        var lessonName = $("#updateLessonName").val();
        var data = {
            LessonId: lessonId,
            Name: lessonName,
            RedirectUrl: redirectUrl
        };
        $.ajax({
            url: "/panel/lesson/update",
            method: "post",
            data: data,
            success: function (res) {
                alert("Güncelleme işlemi başarıyla gerçekleşti.");
                location.href = location.href;
                $("#updateLessonName").val("");
                $("#hiddenLessonId").val("");
            }
        });
    });
});