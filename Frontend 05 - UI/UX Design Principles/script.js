// Modal functionality for Portfolio project details
const modalButtons = document.querySelectorAll('.view-details');
const modals = document.querySelectorAll('.modal');
const closeButtons = document.querySelectorAll('.close');

modalButtons.forEach(btn => {
    btn.addEventListener('click', () => {
        const modalId = btn.getAttribute('data-modal');
        document.getElementById(modalId).classList.add('active');
    });
});
closeButtons.forEach(btn => {
    btn.addEventListener('click', () => {
        const modalId = btn.getAttribute('data-close');
        document.getElementById(modalId).classList.remove('active');
    });
});
window.addEventListener('click', (e) => {
    modals.forEach(modal => {
        if (e.target === modal) {
            modal.classList.remove('active');
        }
    });
});
// Accessibility: close modal with Escape key
window.addEventListener('keydown', (e) => {
    if (e.key === 'Escape') {
        modals.forEach(modal => modal.classList.remove('active'));
    }
});
