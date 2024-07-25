using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;

namespace EduAssignmentHub.Controllers
{
    public class DashboardController : Controller
    {
        // GET
        public IActionResult StudentDashboard()
        {
            return View();
        }

        public IActionResult StudentGrades()
        {
            return View();
        }
        
        public IActionResult StudentNotifications()
        {
            return View();
        }
        
        public IActionResult StudentAssignments()
        {
            return View();
        }

        [HttpGet("api/generate-word")]
        public IActionResult GenerateWord()
        {
            using (var ms = new MemoryStream())
            {
                // Create a Wordprocessing document.
                using (var wordDoc = WordprocessingDocument.Create(ms,
                           DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                {
                    // Add a main document part.
                    var mainPart = wordDoc.AddMainDocumentPart();

                    // Create the document structure and add some text.
                    mainPart.Document = new Document();
                    var body = new Body();
                    mainPart.Document.Append(body);

                    body.Append(new Paragraph(new Run(new Text("Grades Overview"))
                        { RunProperties = new RunProperties(new Bold(), new FontSize() { Val = "48" }) }));

                    // Add grades information
                    body.Append(new Paragraph(new Run(new Text("Mathematics:"))));
                    body.Append(new Paragraph(new Run(new Text("Algebra Homework: 5"))));
                    body.Append(new Paragraph(new Run(new Text("Geometry Quiz: 4"))));
                    body.Append(new Paragraph(new Run(new Text("Calculus Exam: 3"))));
                    body.Append(new Paragraph(new Run(new Text("Statistics Project: 6"))));
                    body.Append(new Paragraph(new Run(new Text("Linear Algebra Test: 2"))));

                    body.Append(new Paragraph(new Run(new Text("History:"))));
                    body.Append(new Paragraph(new Run(new Text("World War II Essay: 6"))));
                    body.Append(new Paragraph(new Run(new Text("Civil War Project: 5"))));
                    body.Append(new Paragraph(new Run(new Text("Ancient Egypt Report: 4"))));

                    body.Append(new Paragraph(new Run(new Text("Science:"))));
                    body.Append(new Paragraph(new Run(new Text("Chemistry Lab: 3"))));
                    body.Append(new Paragraph(new Run(new Text("Physics Final: 6"))));
                    body.Append(new Paragraph(new Run(new Text("Biology Project: 4"))));
                    body.Append(new Paragraph(new Run(new Text("Earth Science Quiz: 5"))));

                    body.Append(new Paragraph(new Run(new Text("Literature:"))));
                    body.Append(new Paragraph(new Run(new Text("Shakespeare Essay: 4"))));
                    body.Append(new Paragraph(new Run(new Text("Poetry Analysis: 5"))));

                    body.Append(new Paragraph(new Run(new Text("Art:"))));
                    body.Append(new Paragraph(new Run(new Text("Painting Project: 6"))));
                }

                var fileName = "GradesOverview.docx";
                var content = ms.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    fileName);
            }

        }
    }
}
