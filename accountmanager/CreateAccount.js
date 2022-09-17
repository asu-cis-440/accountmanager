

function openDialog() {
   
}



function createAccount(addPet) {

    if (document.getElementById("username").value != ''
        && document.getElementById("password").value != ''
        && document.getElementById("phone").value != '') {
        var isConfirmed = confirm("Do you want to create an account?");
    }

    if (isConfirmed == true) {
        username = document.getElementById("username").value;
        phone = document.getElementById("phone").value;
        password = document.getElementById("password").value;
        photo = "test.jpg";
        var mtd = "AccountServices.asmx/CreateAccount";
  
        $.ajax({
            type: "POST",
            url: mtd,
            data: JSON.stringify({ "username": username, "password": password, "phone": phone, "photo": photo }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }, function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
        });
        clear();
    } else {
        clear();
    }
}


function clear() {
    document.getElementById("username").value = "";
    document.getElementById("password").innerHTML = "";
}