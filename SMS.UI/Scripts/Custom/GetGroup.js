//datatable new button
$(document).ready(function () {
    $('#dataTable_length').append($(`<label>
                                  <label class=" col-sm-2 col-md-1"></label>
                                  <a href="#" data-target="#addModal" data-toggle="modal" class="btn btn-success btn-icon-split btn-sm">
                                  <span class="icon text-gray-50">
                                  <i class="fas fa-user-plus"></i>
                                  </span>
                             <span class="text" style="font-size:16px">Yeni Sınıf Ekle</span>
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
        var groupLevel = currentRow.find(".groupLevel").html();
        var groupName = currentRow.find(".groupName").html();
        $("#toBeDeletedGroup").html(`${groupLevel}-${groupName}`);
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
        var groupId = currentRow.find(".settings").children(".hiddenGroupId").attr("value");
        $.ajax({
            url: "/panel/group/delete",
            method: "post",
            data: {
                groupId: groupId,
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
        $("#groupName").val("");
        $("#groupLevelSelect").val("firstOption");
    });
    $("#addButton").click(function () {

        var groupName = $("#groupName").val();
        var groupLevel = $("#groupLevelSelect").val();

        var data = {
            Name: groupName,
            Level: groupLevel,
            RedirectUrl: redirectUrl,
        }
        $.ajax({
            url: "/panel/group/post",
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
        $("#updateGroupLevelSelect").val(currentRow.find(".groupLevel").html());
        $("#updateGroupName").val(currentRow.find(".groupName").html());
        $("#hiddenGroupId").val(currentRow.find(".hiddenGroupId").val());
    });
    $("#updateButton").click(function () {
        var groupId = $("#hiddenGroupId").val();
        var groupName = $("#updateGroupName").val();
        var groupLevel = $("#updateGroupLevelSelect").val();
        var data = {
            GroupId: groupId,
            Name: groupName,
            Level: groupLevel,
            RedirectUrl: redirectUrl
        };
        $.ajax({
            url: "/panel/group/update",
            method: "post",
            data: data,
            success: function (res) {
                alert("Güncelleme işlemi başarıyla gerçekleşti.");
                location.href = location.href;
                $("#updateGroupLevelSelect").val("firstOption");
                $("#updateGroupName").val("");
                $("#hiddenGroupId").val("");
            }
        });
    });
});