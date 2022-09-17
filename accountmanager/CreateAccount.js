

function openDialog() {
   
}



function createAccount(addPet) {

    if (document.getElementById("username").value != '' && document.getElementById("password").value != '') {
        var isConfirmed = confirm("Do you want to create an account?");
    }

    if (isConfirmed == true) {
        username = document.getElementById("username").value;
        password = document.getElementById("password").value;
        photo = "test.jpg";
        var mtd = "AccountServices.asmx/CreateAccount";
  
        $.ajax({
            type: "POST",
            url: mtd,
            data: JSON.stringify({ "username": username, "password": password, "photo": photo }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }, function (data, status) {
            alert("Data: " + data + "\nStatus: " + status);
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