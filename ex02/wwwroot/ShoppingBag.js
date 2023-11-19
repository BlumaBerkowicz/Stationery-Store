async function drowProducts(product) {
    var prod = document.getElementById("temp-row");
    const clone = prod.content.cloneNode(true);
    clone.querySelector("img").src ?= "./Images/" + product.image;
    clone.querySelector("h1").innerText = product.productName;
    clone.querySelector(".price").innerText = product.price + " $";
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("totalColumn").addEventListener('click', () => { deleteProd(product.productId) });
    document.getElementById("items").appendChild(clone);
}

function getProduct() {
    let products = JSON.parse(sessionStorage.getItem("cart"))
    console.log(products)
    if(products)
    for (let i = 0; i < products.length; i++) {
        drowProducts(products[i]);
    }

}
console.log("נסיעה טובה")