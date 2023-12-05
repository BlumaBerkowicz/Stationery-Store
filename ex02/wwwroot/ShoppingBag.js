let products = JSON.parse(sessionStorage.getItem("cart"))
let count = 0;

async function drowProducts(product) {
    var prod = document.getElementById("temp-row");
    var clone = prod.content.cloneNode(true);
    document.getElementById("totalAmount").innerHTML = count
    document.getElementById("itemCount").innerHTML = products.length
    clone.querySelector("img").src = `./Images/${product.image}`;
    clone.querySelector(".price").innerText = product.price + "¤";
    clone.querySelector(".descriptionColumn").innerText = product.description;
    clone.querySelector(".totalColumn").addEventListener('click', () => { deleteProd(product)});
    document.getElementById("myItem").appendChild(clone);
}
function getProduct() {
    products = JSON.parse(sessionStorage.getItem("cart"))

    document.getElementById("myItem").replaceChildren([])
    count = 0;
    if (products) {

        for (let i = 0; i < products.length; i++) {
            count += products[i].price;
            drowProducts(products[i]);
        }
        document.getElementById("totalAmount").innerHTML = count;
        sessionStorage.setItem("sum", count);

    }
    else {
        alert("your cart is empty!!!" )
    }   
}
function deleteProd(prod) {
    products = products.filter(p => p != prod)
    sessionStorage.setItem("cart", JSON.stringify(products))
    getProduct()
}
async function placeOrder() {
    if (JSON.parse(sessionStorage.getItem("user"))) {
        const TheuserId = JSON.parse(sessionStorage.getItem("user")).userId;
        var order = {
            orderDate: Date.now,
            orderSum: count,
            userId: TheuserId,
            OrderItems: products
        };

        try {
            const res = await fetch('api/Order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            })
            if (!res.ok)
                alert("faild to place your older...try again.")
            else {
                const response = await res.json();
                sessionStorage.removeItem("cart")
                alert(`order number ${response.orderId} recived sucssesfully`);
                window.location.href = "./products.html";

            }
        }
        catch (err) {
            alert("err", err)
        }
    }
    else {
        alert("you have to login");
    window.location.href = "./home.html";
    } 
}