using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot.DA;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Pdfa;
using Pair.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Pair.Services.Pdf
{
    public class ReportService
    {
        private Document _report;

        private Person _person;

        public void Create(string path, Person person)
        {
            PdfWriter writer = new PdfWriter(path);

            PdfDocument pdfDocument = new PdfDocument(writer);

            _report = new Document(pdfDocument);

            _person = person;
        }

        private ReportService AddHeader()
        {
            Paragraph header = new Paragraph($"{_person.Name}")
               .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT)
               .SetFontSize(20)
               .SetBold();

            _report.Add(header);

            return this;
        }

        public ReportService AddInfo()
        {
            Paragraph info = new Paragraph()
               .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT)
               .SetFontSize(14)
               .Add($"{_person.Bio}");

            _report.Add(info);

            return this;
        }

        public ReportService AddTable()
        {
            Table linksTable = new Table(2, false);

            for (int cell = 0; cell < _person.SocialLinks.Count; cell++)
            {
                Cell linksCell = new Cell(1, 1)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                .SetFontSize(14)
                .Add(new Paragraph($"{_person.SocialLinks[cell]}"));

                linksTable.AddCell(linksCell);
            }

            _report.Add(linksTable);

            return this;
        }
    }
}
