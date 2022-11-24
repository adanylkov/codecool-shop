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
        const cartElement = createCartElement(item.name, item.price, item.quanity, item.imagePath, item.id)
        cartInner.appendChild(cartElement);
    }
}

function createCartElement(name, price, quanity, imgPath, productId) {
    const div = document.createElement("div");
    div.classList.add("dropdown-item", "d-flex", "justify-content-between");

    const img = document.createElement("img");
    img.src = imgPath;
    img.style.width = "40px";
    img.classList.add("me-3");

    const li = document.createElement("li");
    li.textContent = `${name} - ${price}$ x${quanity}`;
    const input = document.createElement("input");
    input.type = "number";
    input.value = quanity;
    input.classList.add("ms-3");
    input.style.width = "100px";
    input.dataset.productId = productId;
    input.addEventListener("change", changeQuanity);


    div.appendChild(img);
    div.appendChild(li);
    div.appendChild(input);

    return div;
}
function initialize() {
    const buyButtons = document.querySelectorAll(".buy-btn");
    for (var button of buyButtons) {
        button.addEventListener("click", buyProduct);
    }
    addProductsToCart();
}
async function buyProduct(event) {
    const target = event.target;
    const productId = target.dataset.productId;

    await fetch(`shoppingcart/buy?productId=${productId}`)
    await addProductsToCart();
    openCart();
}
function openCart() {
    const cart = document.getElementById("cart-dropdown");
    cart.classList.add("show");
    cart.dataset.bsPopper = "static";
    document.querySelector('button[data-bs-toggle]').classList.add("show");
}

async function changeQuanity(event) {
    const target = event.target;
    const productId = target.dataset.productId;
    const newQuanity = target.value;

    await fetch(`shoppingcart/changequanity?productid=${productId}&newAmount=${newQuanity}`);
    await addProductsToCart();
}

initialize();
