using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IronPdf;

namespace mvc_pdf.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Index(Person p, string creator1, string creator2, string creator3)
        {
            if (creator1 == "creator1")
            {
                var renderer = new HtmlToPdf();

                // tworzymy prosty template oraz ścieżkę zapisu pliku
                string template = "Imię: " + p.Imie + "Nazwisko: " + p.Nazwisko + "Wiek: " + p.Wiek.ToString() + "Kraj: " + p.Kraj + "Miasto: " + p.Miasto;
                var path = "C:/Person.pdf";

                var PDF = renderer.RenderHtmlAsPdf(template);
                PDF.SaveAs(path);
            }
            if (creator2 == "creator2")
            {
                StreamWriter textWriter = new StreamWriter("C:/Person.txt");
                textWriter.Write("Imię: " + p.Imie + "Nazwisko: " + p.Nazwisko + "Wiek: " + p.Wiek.ToString() + "Kraj: " + p.Kraj + "Miasto: " + p.Miasto);
                textWriter.Close();
            }
            if (creator3 == "creator3")
            {
                FileStream fs = new FileStream("C:/Person.dat", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write("Imię: " + p.Imie + "Nazwisko: " + p.Nazwisko + "Wiek: " + p.Wiek.ToString() + "Kraj: " + p.Kraj + "Miasto: " + p.Miasto);
                writer.Close();
            }
            return View(p);
        }
    }
}