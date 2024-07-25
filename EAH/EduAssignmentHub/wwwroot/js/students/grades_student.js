document.addEventListener('DOMContentLoaded', function() {
    // Update modal with grade details
    const gradeElements = document.querySelectorAll('.grade');
    gradeElements.forEach(function(element) {
        element.addEventListener('click', function() {
            const course = element.getAttribute('data-course');
            const assignment = element.getAttribute('data-assignment');
            const grade = element.getAttribute('data-grade');
            const date = element.getAttribute('data-date');
            const description = element.getAttribute('data-description');

            document.getElementById('modal-course').textContent = course;
            document.getElementById('modal-assignment').textContent = assignment;
            document.getElementById('modal-grade').textContent = grade;
            document.getElementById('modal-date').textContent = date;
            document.getElementById('modal-description').textContent = description;
        });
    });

    // Print button event handler
    document.getElementById('print-button').addEventListener('click', function() {
        // Create a new document instance
        const doc = new docx4js.Document();

        // Add title and content
        doc.addParagraph(new docx4js.Paragraph("Grades Overview").heading(docx4js.HeadingLevel.HEADING_1));

        Array.from(document.querySelectorAll('.class-row')).forEach(classRow => {
            const className = classRow.querySelector('h3').textContent;
            const grades = Array.from(classRow.querySelectorAll('.grade')).map(grade => {
                const assignment = grade.getAttribute('data-assignment');
                const gradeValue = grade.getAttribute('data-grade');
                const date = grade.getAttribute('data-date');
                const description = grade.getAttribute('data-description');
                return new docx4js.Paragraph(`Assignment: ${assignment}\nGrade: ${gradeValue}\nDate: ${date}\nDescription: ${description}`);
            });
            doc.addSection(new docx4js.Section({
                children: [
                    new docx4js.Paragraph(className).heading(docx4js.HeadingLevel.HEADING_2),
                    ...grades
                ]
            }));
        });

        // Export document
        doc.export().then(blob => {
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = 'grades-overview.docx';
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        }).catch(error => {
            console.error('Error creating DOCX file:', error);
        });
    });
});
