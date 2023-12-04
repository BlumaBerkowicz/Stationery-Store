var cart = [];
var count = 0;
async function filterProducts() {
    document.getElementById("PoductList").replaceChildren([]);
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const nameSearch = document.getElementById("nameSearch").value;

    try {
        let url = `api/Product?desc=${nameSearch}&minPrice=${minPrice}&maxPrice=${maxPrice}`;
        let checkedCategories = [];
        let allCategories = document.querySelectorAll(".opt");
        for (let i = 0; i < allCategories.length; i++) {
            if (allCategories[i].checked)
                checkedCategories.push(allCategories[i].value)
        }

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
        alert("failed to load products", error)
    }
}
async function getCategories() {
        const res = await fetch(`api/Category`);
        const data = await res.json();
        return data;
}

async function drowProducts(product) {
    const prod  =document.getElementById("temp-card");
    const clone = prod.content.cloneNode(true);
    clone.querySelector("img").src = "./Images/" + product.image;
    clone.querySelector("h1").innerText = product.productName;
    clone.querySelector(".price").innerText = product.price;
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("button").addEventListener('click', () => { addToCart(product)});
    document.getElementById("PoductList").appendChild(clone);
}
async function addToCart(product) {
    cart.push(product);
    sessionStorage.setItem("cart", JSON.stringify(cart));
    document.getElementById("ItemsCountText").innerHTML =JSON.parse(sessionStorage.getItem("cart")).length;
}
async function drowCategory(category) {
    const prod = document.getElementById("temp-category");
    const clone = prod.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.categoryName ;
    clone.querySelector(".opt").value = category.categoryId;
    document.getElementById("categoryList").appendChild(clone);
}
async function showProducts() {
    if (JSON.parse(sessionStorage.getItem("cart")))
    {
        count = JSON.parse(sessionStorage.getItem("cart")).length;
        cart = JSON.parse(sessionStorage.getItem("cart"));
    }
    document.getElementById("ItemsCountText").innerHTML = count
    const data = await filterProducts();
    if (data) {
       for (let i = 0; i < data.length; i++) {
        drowProducts(data[i]);
        }
        len = await data.length;
        document.getElementById("counter").innerText = len;
    }
  
}
async function showCategories() {
    const data = await getCategories();
    for (let i = 0; i < data.length; i++) {
        drowCategory(data[i]);
    }
}



