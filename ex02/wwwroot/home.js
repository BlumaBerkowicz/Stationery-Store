const login = async () => {
    var email = document.getElementById("LoginUserName").value
    var password = document.getElementById("LoginPassword").value
    var user = { email, password };
    try {
        const response = await fetch(`/api/User/login`,
            {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify(user)
            }
        );
        if (response.status == 204) {
            alert("userName or Password is incorrect,try again.")
            throw new Error("user not found");
            return;
        }
        const resUser = await response.json();

        alert("welcome!");
        sessionStorage.setItem("user", JSON.stringify(resUser));
        window.location.href = "./Products.html";
    }
    catch(er){

    }
    
}

    const register = async () =>
    {
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
    const email = document.getElementById("userName").value
    const password = document.getElementById("password").value
    var user = { email, firstName, lastName, password }

    if (firstName.length < 2) {
        alert("first name is too short")
        return;
    }

    if (firstName.length > 20) {
        alert("first name is too long")
        return;
    }

    if (lastName.length < 2) {
        alert("last name is too short")
        return;
    }

    if (lastName.length > 20) {
        alert("last name is too long")
        return;
        }
        if (!checkCode) {
            alert("password is weak")

            return;

        }
    const Email = document.getElementById("userName").value;
    var em = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!em.test(Email)) {
        alert("your email adress is invalid")
        return;
        }
    try {
        const presponseData = await fetch('api/user', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        const dataPost = await presponseData.json();
        alert(`user ${dataPost.userId} created sucssesfuly. please login now`);
    }
    catch (err) {
        console.log(err, "error")
    }
}


const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("password").value;
    try {
        const res = await fetch('api/user/check', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(Code)
        });
        if (!res.ok)
            throw new Error("error in adding your details to our site")
    const data = await res.json();
    meter.value = data;

    if (data <= 2) {
        alert("your password is weak!! try again")
        return false;
    }
    meter.value = data;
    return true;
}

    catch (er) {
        console.log("error",er)
    }
}
