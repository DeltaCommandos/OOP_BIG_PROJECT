

document.addEventListener('DOMContentLoaded', function () {
    const hiddenBlock = document.querySelector('.hidden-block');

    function checkIfInView() {
        const rect = hiddenBlock.getBoundingClientRect();
        const windowHeight = window.innerHeight || document.documentElement.clientHeight;

        if (rect.top <= windowHeight) {
            hiddenBlock.classList.add('active');
        }
    }

    window.addEventListener('scroll', checkIfInView);
    checkIfInView(); 
});