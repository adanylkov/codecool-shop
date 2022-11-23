async function getCart() {
    const response = await fetch("shoppingcart/");
    const cart = await response.json();
    return cart;
}

async function addProductsToCart() {
    const cart = await getCart();
    const cartInner = document.getElementById("cart-dropdown");
    cartInner.innerHTML = "";

    if (cart.length == 0) {
        const p = document.createElement("p");
        p.classList.add("dropdown-item")
        p.textContent = "Shopping cart is empty";
        cartInner.appendChild(p);
        return;
    }

    for (var item of cart) {
        const cartElement = createCartElement(item.name, item.price, item.quanity, item.imagePath)
        cartInner.appendChild(cartElement);
    }
}

function createCartElement(name, price, quanity, imgPath) {
    const div = document.createElement("div");
    div.classList.add("dropdown-item", "d-flex", "justify-content-between");

    const img = document.createElement("img");
    img.src = imgPath;
    img.style.width = "40px";
    img.classList.add("me-3");

    const li = document.createElement("li");
    li.textContent = `${name} - ${price}$ x${quanity}`;

    div.appendChild(img);
    div.appendChild(li);

    return div;
}

addProductsToCart();
