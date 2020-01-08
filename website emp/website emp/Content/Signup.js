
        
$('document').ready(function () {
    $('#UserName').on('change keyup keypress',function (e) {
        let dd = arr.find((data) => data.username.toLowerCase() == $('#UserName').val().toLowerCase()) || null;
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
    $('#Name').on("keyup keypress change", function (e) {
        let regex = /[a-zA-Z]/i;
        if ($('#Name').val() == "") $('#Name').attr('invalid', 'true');
        else if ($('#Name').val().length > 0) $('#Name').attr('invalid', 'false');
        if (!regex.test(e.key) && e.key != " " && e.key != 32) {
            console.log('here');
            e.preventDefault();
            //$('#Name').val($('#Name').val().slice(0, $('#Name').val().length-1));
        }

    });
    $('#Password').on("keyup keypress change", function (e) {
        if ($('#Password').val().length<6) $('#Password').attr('invalid', 'true');
        else  $('#Password').attr('invalid', 'false');
    });
    $('#Email').keyup(function (e) {
        let pattern = /[A-Z0-9a-z\_\.]{4,}@[A-Za-z]{3,}\.[A-Za-z]{2,}$/i;
        let dd = arr.find((data) => data.email.toLowerCase() == $('#Email').val().toLowerCase()) || null;
        if (dd != null) {
            $('#Email').css('border-color', 'red');
            $("#Email").attr('invalid', 'true');
            $("#EmailError").removeClass('d-none');
        } else {
            $('#Email').css('border-color', '#ced4da');
            $("#Email").attr('invalid', 'false');
            $("#EmailError").addClass('d-none');
            if (!pattern.test($('#Email').val())) {
                $('#Email').css('border-color', 'red');
                $("#Email").attr('invalid', 'true');
                $("#EmailError").removeClass('d-none');
            }
        }
        
    })
});

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
    if (check)
    {
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
