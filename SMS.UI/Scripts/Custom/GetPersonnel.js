$(document).ready(function () {
    //datatable new button
    $('#dataTable_length').append($(`<label>
                     <label class=" col-sm-2 col-md-1"></label>
                     <a href="#" data-target="#addModal" data-toggle="modal" class="btn btn-success btn-icon-split btn-sm">
                        <span class="icon text-gray-50">
                       <i class="fas fa-user-plus">
                       </i>
                     </span>
                      <span class="text" style="font-size:16px">Yeni Personel Ekle
                     </span>
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
        $("#addUserName").val("");
        $("#addFirstName").val("");
        $("#addLastName").val("");
        $("#addPhoneNumber").val("");
        $("#addEmail").val("");
        $("#addTcNo").val("");
        $("#addPassword").val("");
    });
    $("#addButton").click(function () {
        var userName = $("#addUserName").val();
        var firstName = $("#addFirstName").val();
        var lastName = $("#addLastName").val();
        var phoneNumber = $("#addPhoneNumber").val();
        var email = $("#addEmail").val();
        var tcNo = $("#addTcNo").val();
        var password = $("#addPassword").val();
        var data = {
            UserName: userName,
            FirstName: firstName,
            LastName: lastName,
            PhoneNumber: phoneNumber,
            Email: email,
            TcNo: tcNo,
            Password: password,
            RedirectUrl: redirectUrl
        }
        $.ajax({
            url: "/panel/personnel/post",
            method: "post",
            data: data,
            success: function (res) {
                alert("Ekleme işlemi başarıyla gerçekleşti.");
                location.href = location.href;
                $("#addUserName").val("");
                $("#addFirstName").val("");
                $("#addLastName").val("");
                $("#addPhoneNumber").val("");
                $("#addEmail").val("");
                $("#addTcNo").val("");
                $("#addPassword").val("");
            }
        });
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
            url: "/panel/teacher/delete",
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
        $("#updateUserName").val(currentRow.find(".userName").html());
        $("#updateFirstName").val(currentRow.find(".firstName").html());
        $("#updateLastName").val(currentRow.find(".lastName").html());
        $("#updatePhoneNumber").val(currentRow.find(".phoneNumber").html());
        $("#updateEmail").val(currentRow.find(".email").html());
        $("#updateTcNo").val(currentRow.find(".tcNo").html());
        $("#hiddenUserId").val(currentRow.find(".hiddenUserId").val());
    });
    $("#updateButton").click(function () {
        var userId = $("#hiddenUserId").val();
        var userName = $("#updateUserName").val();
        var firstName = $("#updateFirstName").val();
        var lastName = $("#updateLastName").val();
        var phoneNumber = $("#updatePhoneNumber").val();
        var email = $("#updateEmail").val();
        var tcNo = $("#updateTcNo").val();
        var password = $("#updatePassword").val();
        var data = {
            UserName: userName,
            FirstName: firstName,
            LastName: lastName,
            PhoneNumber: phoneNumber,
            Email: email,
            TcNo: tcNo,
            Password: password,
            PersonnelId: userId,
            RedirectUrl: redirectUrl
        };
        $.ajax({
            url: "/panel/personnel/update",
            method: "post",
            data: data,
            success: function (res) {
                alert("Güncelleme işlemi başarıyla gerçekleşti.");
                location.href = location.href;
                $("#updateUserName").val("");
                $("#updateFirstName").val("");
                $("#updateLastName").val("");
                $("#updatePhoneNumber").val("");
                $("#updateEmail").val("");
                $("#updateTcNo").val("");
                $("#updatePassword").val("");
            }
        });
    });
});