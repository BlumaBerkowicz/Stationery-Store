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
        if (!response.ok) {
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


const update = async () =>
{
    const userFromStorage = sessionStorage.getItem("user")
    const user = JSON.parse(userFromStorage)
    const firstName = document.getElementById("firstName").value ? document.getElementById("firstName").value: user.firstName
    const lastName = document.getElementById("lastName").value ? document.getElementById("lastName").value: user.lastName
    const userName = document.getElementById("userName").value ? document.getElementById("userName").value: user.userName
    const password = document.getElementById("password").value ? document.getElementById("password").value: user.password
    var updateUser = { firstName, lastName, userName, password }
    const userId = user.userId;
    strength = await checkCode();
    if (strength>2){ 
    try {
        const res = await fetch("api/user/" + userId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUser)
        });
        const response = await res.json();
        aler("update succeed");
    }
    catch (error) {
        alert("error",error)
        }
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
