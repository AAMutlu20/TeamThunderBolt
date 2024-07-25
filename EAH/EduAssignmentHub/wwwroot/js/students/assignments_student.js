$(document).ready(function() {
    let currentCard = null;

    $('#assignmentModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        currentCard = button.closest('.assignment-card'); // Get the closest assignment card
        var course = button.data('course');
        var title = button.data('title');
        var due = button.data('due');
        var description = button.data('description');

        var modal = $(this);
        modal.find('#modal-course').text(course);
        modal.find('#modal-title').text(title);
        modal.find('#modal-due').text(due);
        modal.find('#modal-description').text(description);
        modal.find('#checkmark').addClass('d-none'); // Hide checkmark initially
    });

    $('#submitButton').on('click', function() {
        $('#fileInput').click(); // Trigger file input dialog
    });

    $('#fileInput').on('change', function() {
        var file = this.files[0];
        if (file && file.type === 'application/pdf') {
            if (currentCard) {
                $('#checkmark').removeClass('d-none'); // Show checkmark
                currentCard.find('.due-date').text('Assignment completed').css('color', '#6BCB77'); // Update only the current card
            }
        } else {
            alert('Please upload a PDF file.');
            $('#checkmark').addClass('d-none'); // Hide checkmark if invalid file
        }
    });

    // Ensure that the checkmark remains visible after closing the modal
    $('#assignmentModal').on('hide.bs.modal', function () {
        $('#checkmark').removeClass('d-none'); // Keep checkmark visible
    });
});
