const login = async () => {
        var email = document.getElementById("LoginUserName").value
        var password = document.getElementById("LoginPassword").value
        var user = { email, password };
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

    const register = async () =>
    {
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
    const email = document.getElementById("userName").value
    const password = document.getElementById("password").value
        var user = { email, firstName, lastName, password }

     strength = await checkCode();

        if (strength > 2) {
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
                alert(err, "error")
            }
        }
        else {
           alert("your password is weak!! try again")
        }
    }





const checkCode = async () =>
{
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("password").value;
    const res = await fetch('api/user/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(Code)
    });
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    return await res.json();
}
