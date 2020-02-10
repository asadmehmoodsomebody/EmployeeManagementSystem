
        
$('document').ready(function () {
    $('#UserName').on('change keyup keypress', function (e) {
        let dd = arr.find((data) => data.toLowerCase() == $('#UserName').val().toLowerCase()) || null;
        if (dd != null) {
            $('#UserName').css('border-color', 'red');
            $("#UserName").attr('invalid', 'true');
            $("#UserNameError").removeClass('d-none');
        }
        else {
            $('#UserName').css('border-color', '#ced4da');
            $("#UserName").attr('invalid', 'false');
            $("#UserNameError").addClass('d-none');
            if ($('#UserName').val().length == 0) {
                $("#UserName").attr('invalid', 'true');
            }
        }
    });
    $('#FirstName').on("keyup keypress change", function (e) {
        let regex = /[a-zA-Z]/i;
        if ($('#FirstName').val() == "") $('#FirstName').attr('invalid', 'true');
        else if ($('#FirstName').val().length > 0) $('#FirstName').attr('invalid', 'false');
        if (!regex.test(e.key) && e.key != " " && e.key != 32) {
            console.log('here');
            e.preventDefault();
            //$('#Name').val($('#Name').val().slice(0, $('#Name').val().length-1));
        }

    });
    $('#Password').on("keyup keypress change", function (e) {
        if ($('#Password').val().length < 6) $('#Password').attr('invalid', 'true');
        else $('#Password').attr('invalid', 'false');
    });
    //$('#EmailAddress').keyup(function (e) {
    //    let pattern = /[A-Z0-9a-z\_\.]{4,}@[A-Za-z]{3,}\.[A-Za-z]{2,}$/i;
    //    if (!pattern.test($('#Email').val())) {
    //        $('#EmailAddress').css('border-color', 'red');
    //        $("#EmailAddress").attr('invalid', 'true');
    //        $("#EmailError").removeClass('d-none');
    //    } else {
    //        $('#EmailAddress').css('border-color', '#ced4da');
    //        $("#EmailAddress").attr('invalid', 'false');
    //        $("#EmailError").addClass('d-none');
    //    }
    //});

    $('#Register').click(function (e) {
        let check = false;
        $.each($('.required'), function (e) {
            if ($(this).attr('invalid') == "true") {
                $(this).css('border-color', 'red');
                check = true;
            } else {
                $(this).css('border-color', '#ced4da');
            }
        })
        if (check) {
            if ($('#Password').attr('invalid') == 'true') {
                $('#c_password').css('border-color', '#ced4da');
                $('#PasswordError').addClass('d-none')
            }

            e.preventDefault();
        } else {
            if ($('#Password').val() != $('#c_password').val()) {
                e.preventDefault();
                $('#c_password').css('border-color', 'red');
                $('#PasswordError').removeClass('d-none')
            } else {
                $('#c_password').css('border-color', '#ced4da');
                $('#PasswordError').addClass('d-none')
            }
        }
    })
});