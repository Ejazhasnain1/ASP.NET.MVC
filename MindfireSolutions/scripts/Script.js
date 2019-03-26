var cloneCount = 1;
$(document).ready(function () {

    $("#editDetails").click(function () {
        $("#myModal").show();
    });

    $("#closeButton").click(function () {
        $("#myModal").hide();
    });

    $("#editAdminDetails").click(function () {
        $("#myAdminModal").show();
    });

    $("#closeAdminButton").click(function () {
        $("#myAdminModal").hide();
    });

    $("#closeUserButton").click(function () {
        $("#myUsersModal").hide();
    });

    // Appending text box for adding multiple contacts      
    $("#addContactField").click(function () {
        $("#cloneItem").clone().append('<div><input type="text" class="fields-value" id="ContactNumber' + cloneCount + '" placeholder="Enter your Number" required="true" name="ContactNumber" oninput="validate.isContactValid(cloneCount)"</input><div class="error" id="errorContactInfo' + cloneCount + '"></div></div>').insertBefore("#addItem");
        cloneCount++;
    });

    //To check that the entered email is unique
    $(".email-check").keyup(function () {
        var email = $(".email-check").val();
        $.ajax({
            type: "POST",
            url: "UsernameAvailablity",
            data: '{userEmail:"' + email + '"}',
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (result) {
                var message = $("#emailAvailabilty");
                if (result) {
                    if ($(".email-check").val() === "") {
                        message.html("");
                    }
                    else {
                        message.html("*Email ID is available.");
                        message.css("color", "green");
                    }
                }
                else {
                    message.html("*This Email ID is already in Use");
                    message.css("color", "#e87e03");
                }
            }

        });
    });

    //Client side validation for image upload
    $('input[type=file]').change(function () {
        var val = $(this).val().toLowerCase(), regex = new RegExp("(.*?)\.(jpg|jpeg|png)$");
        if (!(regex.test(val)) || this.files[0].size >= 512000) {
            $(this).val('');
            $("#errorFile").html("*Uploaded file should be of Image type and size should be below 500kb");
        }
    });

    //Saving User Updated details 
    $("#saveDetails").click(function () {
        var myFormData = $("#editForm").serialize();
        $.ajax({
            type: "POST",
            url: "/Details/EditUserDetails",
            data: myFormData,
            success: function (value) {
                if (value["success"] == true) {
                    $("#myModal").hide();
                    alert("Changes Saved Successfully");
                    location.reload();
                } else {
                    alert("Fill the form correctly");
                }
            },
            error: function (value) {
                alert("Error in Updation");
            }
        })
    });   
});



//Method to get the User details from database
function editUsersDetails(idValue) {
    $.ajax({
        type: "GET",
        url: "/Admin/EditUsersDetails/" + idValue,
        success: function (result) {
            console.log(result);
            $("#fname").val(result["Firstname"]);
            $("#lname").val(result["Lastname"]);
            $("#permanentAddress").val(result["Address"]);
            $("#hiddenId").val(result["EmployeeId"]);
            $("#myUsersModal").show();
        }
    });
    $("#saveUsersDetails").click(function () {
        var myData = $("#editUsersForm").serialize();
        $.ajax({
            type: "POST",
            url: "/Admin/EditDetails",
            data: myData,
            success: function (value) {
                if (value["success"] == true) {
                    $("#myUsersModal").hide();
                    alert("Changes Saved Successfully");
                    location.reload();
                } else {
                    alert("Fill the form correctly");
                }
            },
            error: function (value) {
                alert("Error in Updation");
            }
        })
    });
};
