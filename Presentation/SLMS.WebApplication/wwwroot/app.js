const menuBtn = document.getElementById("menuBtn");
const closeBtn = document.getElementById("closeMenu");
const sidebar = document.getElementById("sidebar");
const overlay = document.getElementById("overlay");

function openMenu() {
    sidebar.classList.add("active");
    overlay.classList.add("show");
}

function closeMenu() {
    sidebar.classList.remove("active");
    overlay.classList.remove("show");
}

menuBtn.addEventListener("click", openMenu);
closeBtn.addEventListener("click", closeMenu);
overlay.addEventListener("click", closeMenu);
