//To check password and confirmpassword
function checkPasswordMatch() {
    $("#CheckPasswordMatch").text("");
    $("#CheckPasswordMatch").removeClass("redcolor")
    $("#CheckPasswordMatch").removeClass("Greencolor")

    var password = $("#txtPassword").val();
    var confirmPassword = $("#txtconfirmpassword").val();

    if (password == "" || confirmPassword == "") {
        $("#CheckPasswordMatch").text("");

    }
    else if (password != confirmPassword) {
        $("#CheckPasswordMatch").text("Passwords does not match!").addClass("redcolor");
    }
    else
        $("#CheckPasswordMatch").text("Passwords match.").addClass("Greencolor");
}
//To valiadate email address
function fnemailvalidate() {
    const inpObj = document.getElementById("Email");
    if (!inpObj.checkValidity()) {
        document.getElementById("demo").innerHTML = inpObj.validationMessage;
    } else {
        document.getElementById("demo").innerHTML = "<span style='color:green'>Email is valid</span>";
    }

}
// To show password
function myFunction() {
    var x = document.getElementById("password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}