async function filterProducts() {
    document.getElementById("PoductList").replaceChildren([]);
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const nameSearch = document.getElementById("nameSearch").value;

    try {

        let checkedCategories = [];
        let allCategories = document.querySelectorAll(".opt");
        for (let i = 0; i < allCategories.length; i++) {
            if (allCategories[i].checked)
                checkedCategories.push(allCategories[i].value)
        }
        let url = `api/Product?desc=${nameSearch}&minPrice=${minPrice}&maxPrice=${maxPrice}`;
        const length = document.querySelectorAll(".opt");
        if (checkedCategories) {
            for (let i = 0; i < checkedCategories.length; i++) {
                url += `&categoryIds=${checkedCategories[i]}`
            }
        }
        const res = await fetch(url);
        const data = await res.json();
        return data;
    }

    catch (error) {
        alert("cdf4rgthg", error)
    }
}
async function getCategories() {
    try {
        const res = await fetch(`api/Category`);
        const data = await res.json();
        return data;
    }
    catch (error) {
        alert("error", error)
    }
}

async function drowProducts(product) {
    const prod  =document.getElementById("temp-card");
    const clone = prod.content.cloneNode(true);
    clone.querySelector("img").src = "./Images/" + product.image;
    clone.querySelector("h1").innerText = product.productName;
    clone.querySelector(".price").innerText = product.price+" $";
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("button").addEventListener('click', () => { addToCart(product) });
    document.getElementById("PoductList").appendChild(clone);
}
const cart = [];
async function addToCart(product) {
    //count++
    cart.push(product);
    sessionStorage.setItem("cart", JSON.stringify(cart));
}
async function drowCategory(category) {
    const prod = document.getElementById("temp-category");
    const clone = prod.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.categoryName ;
    clone.querySelector(".opt").value = category.categoryId;
    document.getElementById("categoryList").appendChild(clone);
}
async function showProducts() {
    console.log("the function is works");
    const data = await filterProducts();
    if (data) {
       for (let i = 0; i < data.length; i++) {
        drowProducts(data[i]);
        }
        len = await data.length;
        console.log(len);
        //document.getElementById("counter").innerText("length:"+len);

    }
  
}
async function showCategories() {
    const data = await getCategories();
    for (let i = 0; i < data.length; i++) {
        drowCategory(data[i]);
    }
}



