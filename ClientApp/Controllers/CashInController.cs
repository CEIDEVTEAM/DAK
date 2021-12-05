using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace ClientApp.Controllers
{
    public class CashInController : Controller
    {
        public ActionResult CashIn()
        {
            var idPackage = HttpContext.Session.GetString("44");
            LPackageController lgc = new LPackageController();
            PackageDto dto = (PackageDto)lgc.GetById(int.Parse(idPackage));

            return View(dto);
        }

        public ActionResult ProcessPayment(PackageDto dto)
        {
            LCashInController lcc = new LCashInController();
            lcc.PaymentCashProcess(dto);
            this.CreateTrackingNumber(dto);
            return RedirectToAction("New", "Package");
        }
        

        public void CreateTrackingNumber(PackageDto dto)
        {
            LPackageController lgc = new LPackageController();
            lgc.CreateTrackingNumber(dto);
        }



        public ActionResult CreatePdf(int id)
        {
            LPackageController lgc = new LPackageController();
            PackageDto dto = (PackageDto)lgc.GetById(id);

            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            // Must have write permissions to the path folder


            // Header
            Paragraph header = new Paragraph("DAK INC.")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            // New line
            Paragraph newline = new Paragraph(new Text("\n"));

            document.Add(newline);
            document.Add(header);

            // Add sub-header
            Paragraph subheader = new Paragraph($"PAQUETE O CARTA NRO.{dto.Id} ")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Add paragraph1


            // Table
            Table table = new Table(2, false);
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Tipo: " + dto.Id));
            Cell cell12 = new Cell(1, 2)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Remitente: " + dto.IdClient));
            Cell cell13 = new Cell(1, 3)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Fecha: " + dto.Address));
            Cell cell14 = new Cell(1, 4)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Fecha: " + dto.IdCity));

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);

            document.Add(newline);
            document.Add(table);

            Paragraph paragraph2 = new Paragraph("OBSERVACIÓN CIUDADANO: " + dto.IdRecipient);
            document.Add(paragraph2);

            document.Add(newline);


            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format("page" + i + " of " + n)),
                   559, 806, i, TextAlignment.RIGHT,
                   VerticalAlignment.TOP, 0);
            }

            // Close document
            document.Close();

            byte[] bytesStream = stream.ToArray();
            stream = new MemoryStream();
            stream.Write(bytesStream, 0, bytesStream.Length);
            stream.Position = 0;


            return new FileStreamResult(stream, ".pdf");
        }


    }
}
