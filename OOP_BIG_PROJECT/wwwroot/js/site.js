

//document.addEventListener('DOMContentLoaded', function () {
//    const hiddenBlock = document.querySelector('.hidden-block');

//    function checkIfInView() {
//        const rect = hiddenBlock.getBoundingClientRect();
//        const windowHeight = window.innerHeight || document.documentElement.clientHeight;

//        if (rect.top <= windowHeight) {
//            hiddenBlock.classList.add('active');
//        }
//    }

//    window.addEventListener('scroll', checkIfInView);
//    checkIfInView();
//});

//const popupOverlay = document.getElementById("popup-overlay");
//const popup = document.getElementById("popup");

//function showPopup() {
//    popupOverlay.style.display = "block";
//}
//function hidePopup() {
//    popupOverlay.style.display = "none";
//}
//popupOverlay.addEventListener("click", hidePopup);
//popup.addEventListener("click", (event) =& gt; event.stopPropagation());


const openPopUp = document.getElementById('open_pop_up');
const closePopUp = document.getElementById("pop_up_close");
const popUp = document.getElementById("pop_up");

openPopUp.addEventListener('click', function (e) {
    e.preventDefault();
    popUp.classList.add('active');
    closePoplip.addEventListener("click', () => { popUp.classList.removel 'active")
})