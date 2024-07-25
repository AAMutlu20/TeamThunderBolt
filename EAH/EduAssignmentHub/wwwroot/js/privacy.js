document.addEventListener('DOMContentLoaded', function() {
    const header = document.querySelector('header');
    const scrollPoint = 200; // Adjust this value as needed

    window.addEventListener('scroll', function() {
        if (window.scrollY > scrollPoint) {
            header.classList.add('scrolled');
        } else {
            header.classList.remove('scrolled');
        }
    });
});