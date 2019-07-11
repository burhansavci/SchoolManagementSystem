$(document).ready(function () {
    //datatable new button
    $('#dataTable_length').append($(`<label>
                                  <label class=" col-sm-2 col-md-1"></label>
                                  <a href="#" data-target="#addUpdateModal" data-toggle="modal" class="btn btn-success btn-icon-split btn-sm">
                                  <span class="icon text-gray-50">
                                  <i class="fas fa-user-plus"></i>
                                  </span>
                             <span class="text" style="font-size:16px">Yeni Öğrenci Ekle</span>
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
    //Add
    $(".btn-success").click(function () {
        $(".btn-submit").html("Ekle");
        $(".btn-submit").attr("id", "0");
        $("#addUpdateModalTitle").html("Yeni Öğrenci Ekle");
        $("#userName").val("");
        $("#firstName").val("");
        $("#lastName").val("");
        $("#phoneNumber").val("");
        $("#email").val("");
        $("#tcNo").val("");
        $("#password").val("");
        var startingOption = $("<option hidden disabled selected value=" + " firstOption" + "> -- Bir Sınıf Seçiniz -- </option>")
        $("#groupSelect").append(startingOption);

    });
    //Delete
    $('table#dataTable tbody').on('click', 'tr td .btn-danger', function () {
        currentRow = $(this).closest("tr");
        var username = currentRow.find(".userName").html();
        $("#toBeDeletedUser").html(username);
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
        var userId = currentRow.find(".settings").children(".hiddenUserId").attr("value");
        $.ajax({
            url: "/panel/student/delete",
            method: "post",
            data: {
                userId: userId,
            },
            success: function (res) {
                alert("Silme işlemi başarıyla gerçekleşti.");
                $("#deleteModal").modal("hide");
                table.row('.selected').remove().draw(false);
            }
        });
    });

    //Update
    $('table#dataTable tbody').on('click', 'tr td .btn-warning', function () {
        currentRow = $(this).closest("tr");
        $(".btn-submit").attr("id", "1");
        $("#userName").val(currentRow.find(".userName").html());
        $("#firstName").val(currentRow.find(".firstName").html());
        $("#lastName").val(currentRow.find(".lastName").html());
        $("#phoneNumber").val(currentRow.find(".phoneNumber").html());
        $("#email").val(currentRow.find(".email").html());
        $("#tcNo").val(currentRow.find(".tcNo").html());
        $("#hiddenUserId").val(currentRow.find(".hiddenUserId").val());
        $("#hiddenGroupId").val(currentRow.find(".hiddenGroupId").val());
        $("#groupSelect").val(currentRow.find(".hiddenGroupId").val());
        $(".btn-submit").html("Güncelle");
        $("#addUpdateModalTitle").html("Öğrenci Güncelle");
    });
    // Add and Update Submit Button
    $(".btn-submit").click(function () {
        var userName = $("#userName").val();
        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
        var parentPhoneNumber = $("#phoneNumber").val();
        var email = $("#email").val();
        var tcNo = $("#tcNo").val();
        var password = $("#password").val();
        var userId = $("#hiddenUserId").val();
        var groupId = $("#hiddenGroupId").val();
        var selectedGroup = selectedOption.text();
        var arr = selectedGroup.split('-');
        if ($(this).attr("id") == "0") {
            var data = {
                UserName: userName,
                FirstName: firstName,
                LastName: lastName,
                ParentPhoneNumber: parentPhoneNumber,
                Email: email,
                TcNo: tcNo,
                Password: password,
                GroupLevel: arr[0],
                GroupName: arr[1],
                RedirectUrl: redirectUrl
            }
        }
        else {
            var data = {
                UserName: userName,
                FirstName: firstName,
                LastName: lastName,
                ParentPhoneNumber: parentPhoneNumber,
                Email: email,
                TcNo: tcNo,
                Password: password,
                GroupLevel: arr[0],
                GroupName: arr[1],
                GroupId: groupId,
                StudentId: userId,
                RedirectUrl: redirectUrl
            };
        }
        if ($(this).attr("id") == "0") {
            $.ajax({
                url: "/panel/student/post",
                method: "post",
                data: data,
                success: function (res) {
                    alert("Ekleme işlemi başarıyla gerçekleşti.");
                    location.href = location.href;
                    $("#userName").val("");
                    $("#firstName").val("");
                    $("#lastName").val("");
                    $("#parentPhoneNumber").val("");
                    $("#email").val("");
                    $("#tcNo").val("");
                    $("#password").val("");
                }
            });
        }
        else {
            $.ajax({
                url: "/panel/student/update",
                method: "post",
                data: data,
                success: function (res) {
                    alert("Güncelleme işlemi başarıyla gerçekleşti.");
                    location.href = location.href;
                    $("#userName").val("");
                    $("#firstName").val("");
                    $("#lastName").val("");
                    $("#parentPhoneNumber").val("");
                    $("#email").val("");
                    $("#tcNo").val("");
                    $("#password").val("");
                }
            });
        }

    });
});