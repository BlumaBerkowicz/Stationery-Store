
const login = async () => {
    try {
        const response = await fetch(`/api/user/?userName=${document.getElementById("LoginUserName").value}&password=${document.getElementById("Password").value}`)
        if (!response.ok) {
            throw new Error("user not found");
            return;
        }
        const resUser = await response.json();
        alert("success");
        sessionStorage.setItem("user", JSON.stringify(resUser));
        window.location.href = "./update.html";

    }
    catch (error) {

        alert(error, "error")
    }
}
const  register= async()=>
{
const firstName = document.getElementById("firstName").value
const lastName = document.getElementById("lastName").value
const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    var user = { firstName, lastName, userName, password }

    /////////////check
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
    const data = await res.json();
    meter.value = data;
    ///////////////
    console.log("check succssed");
    if (meter.value > 2) {
        try {
            const presponseData = await fetch('api/user', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            const dataPost = await presponseData.json();

            console.log('POST data:', dataPost);
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
    console.log(user);
    const firstName = document.getElementById("firstName").value ? document.getElementById("firstName").value: user.firstName
    const lastName = document.getElementById("lastName").value ? document.getElementById("lastName").value: user.lastName
    const userName = document.getElementById("userName").value ? document.getElementById("userName").value: user.userName
    const password = document.getElementById("password").value ? document.getElementById("password").value: user.password
    var updateUser = { firstName, lastName, userName, password }
    console.log(updateUser);
    const userId = user.userId;
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
    const data = await res.json();
    meter.value = data;
    return meter.value;
}
