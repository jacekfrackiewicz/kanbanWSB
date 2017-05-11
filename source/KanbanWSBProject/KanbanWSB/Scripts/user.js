$(document).ready(function () {
    function submitCredentials() {
        var email = $('#email-input').val();
        var pass = $('#password-input').val();

        if (email && pass) {

            var deferred = $.Deferred();

            var post = $.ajax({
                type: "POST",
                url: document.location.origin + '/User/SubmitCredentials',
                data: { Email: email, Password: pass }
            });

            post.done(function () {
                window.location.href = document.location.origin + "http://stackoverflow.com";
            });
            post.fail(function () {
                $('#error-login-alert').modal();
            });
           
        }
        
    }

    $('#submit-credentials-btn').on('click', submitCredentials);
});