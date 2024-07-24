document.addEventListener('DOMContentLoaded', function() {
    const header = document.querySelector('header');
    const heroSection = document.querySelector('#hero');
    const heroHeight = heroSection.offsetHeight;

    window.addEventListener('scroll', function() {
        if (window.scrollY > heroHeight) {
            header.classList.add('scrolled');
        } else {
            header.classList.remove('scrolled');
        }
    });
});
