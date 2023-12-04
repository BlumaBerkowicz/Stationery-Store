const update = async () => {
    const userFromStorage = sessionStorage.getItem("user")
    const user = JSON.parse(userFromStorage)
    const firstName = document.getElementById("firstName").value ? document.getElementById("lastName").value : user.firstName
    const lastName = document.getElementById("lastName").value ? document.getElementById("lastName").value : user.lastName
    const email = document.getElementById("userName").value ? document.getElementById("userName").value : user.userName
    const password = document.getElementById("password").value ? document.getElementById("password").value : user.password
    const userId = user.userId;
    var updateUser = { firstName, lastName, email, password }
    strength = await checkCode(password);
    if (strength > 2) {
        try {
            const res = await fetch("api/user/" + userId, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(updateUser)
            });
            const response = await res.json();
            console.log(response)
            alert("update succeed");
        }
        catch (error) {
            alert("error", error)
        }
       
    }
    else
        alert("your password is weak, try again")

}
const loadUpdatePage = async () => {

    const userFromStorage = sessionStorage.getItem("user")
    const user = JSON.parse(userFromStorage)
   document.getElementById("firstName").value = user.firstName
    document.getElementById("lastName").value = user.lastName
   document.getElementById("userName").value = user.email
    document.getElementById("password").value = user.password
}

const checkCode = async (password) => {
    console.log("im here")
    const res = await fetch('api/user/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });
    if (!res.ok)
        throw new Error("weak password")
    return await res.json();
}