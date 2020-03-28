using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Print;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using WalkOut.Common;
using WalkOut.Droid.PrintService;
using WalkOut.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(PrintPDFService))]
namespace WalkOut.Droid.PrintService
{
    public class PrintPDFService : IPrinterService
    {
        public void GeneratePDF(FormModel form)
        {
            string file = CommonData._folderPath + "declaratie.pdf";

            string fontFile = CommonData._folderPath + "calibri.ttf";

            if (new Java.IO.File(file).Exists())
            {
                new Java.IO.File(file).Delete();
            }

             GenerateDocument(form, file, fontFile);
        }

        private void GenerateDocument(FormModel form, string file, string fontFile)
        {
            try
            {
                Document document = new Document();

                PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));

                document.Open();

                document.SetPageSize(PageSize.A4);
                document.SetMargins(0f, 0f, 0f, 0f);
                document.AddCreationDate();
                document.AddCreator("WalkOut");

                iTextSharp.text.Color fontColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                BaseFont fontName = BaseFont.CreateFont(fontFile, "UTF-8", BaseFont.EMBEDDED);

                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(fontName, 10.0f, iTextSharp.text.Font.BOLD, fontColor);
                iTextSharp.text.Font standardFont = new iTextSharp.text.Font(fontName, 10.0f, iTextSharp.text.Font.NORMAL, fontColor);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(fontName, 16.0f, iTextSharp.text.Font.NORMAL, fontColor);
                iTextSharp.text.Font paragraphFont = new iTextSharp.text.Font(fontName, 10.0f, iTextSharp.text.Font.NORMAL, fontColor);
                iTextSharp.text.Font spaceFont = new iTextSharp.text.Font(fontName, 6.0f, iTextSharp.text.Font.NORMAL, fontColor);

                AddNewItem(document, "DECLARATIE PE PROPRIE RASPUNDERE", iTextSharp.text.Element.ALIGN_CENTER, titleFont);

                AddSpace(document, paragraphFont);

                AddNewItem(document, "Nume, prenume: " + form.NumePrenume, iTextSharp.text.Element.ALIGN_LEFT, paragraphFont);

                AddNewItem(document, "Data nasterii: " + form.DataNasterii, iTextSharp.text.Element.ALIGN_LEFT, paragraphFont);

                AddNewItem(document, "Adresa locuintei: " + form.Adresa, iTextSharp.text.Element.ALIGN_LEFT, paragraphFont);

                AddNewItem(document, "Locul/locurile deplasarii: " + form.LocDeplasare, iTextSharp.text.Element.ALIGN_LEFT, paragraphFont);

                AddSpace(document, paragraphFont);

                AddNewItem(document, "Motivul deplasarii:", iTextSharp.text.Element.ALIGN_LEFT, boldFont);

                if (form.InteresProfesional)
                {
                    AddNewItem(document,
                        " >> Interes profesional, inclusiv intre locuinta/gospodarie si locul/locurile de desfasurare a activitatii profesionale si inapoi",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.AsigurareBunuri)
                {
                    AddNewItem(document,
                        " >> Asigurarea de bunuri care acopera necesitatile de baza ale persoanelor si animalelor de companie/domestice",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.AsistentaMedicala)
                {
                    AddNewItem(document,
                        " >> Asistenta medicala care nu poate fi amanata si nici realizata de la distanta",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.MotiveJustificate)
                {
                    AddNewItem(document,
                        " >> Motive justificate, precum ingrijirea/insotirea unui minor/copilului, asistenta persoanelor varstnice, bolnave sau cu dizabilitati ori deces al unui membru de familie",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.ActivitateFizica)
                {
                    AddNewItem(document,
                        " >> Activitate fizica individuala (cu excluderea oricaror activitati sportive de echipa/colective) sau pentru nevoile animalelor de companie/domestice, in apropierea locuintei",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.ActivitatiAgricole)
                {
                    AddNewItem(document,
                        " >> Realizarea de activitati agricole",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.DonareSange)
                {
                    AddNewItem(document,
                        " >> Donarea de sange, la centrele de transfuzie sanguina",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.ScopuriUmanitare)
                {
                    AddNewItem(document,
                        " >> Scopuri umanitare sau de voluntariat",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.ComertAgricole)
                {
                    AddNewItem(document,
                        " >> Comercializarea de produse agroalimentare (in cazul producatorilor agricoli)",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                if (form.BunuriActivitateProfesionala)
                {
                    AddNewItem(document,
                        " >> Asigurarea de bunuri necesare desfasurarii activitatii profesionale",
                        iTextSharp.text.Element.ALIGN_LEFT,
                        paragraphFont);
                }

                AddSpace(document, paragraphFont);

                AddNewItemLeftAndRight(document, "Data declaratiei: " + form.DataDeclaratiei, "Semnatura", boldFont);

                AddImage(document, CommonData._folderPath + "img.png");

                document.Close();

                Toast.MakeText(MainActivity.AppContext, "Declaratie generata", ToastLength.Short).Show();

                PrintDocument(file);
            }
            catch (FileNotFoundException e)
            {
                Log.Debug("PDF Printer", e.Message);
            }
            catch (DocumentException e)
            {
                Log.Debug("PDF Printer", e.Message);
            }
            catch (IOException e)
            {
                Log.Debug("PDF Printer", e.Message);
            }
        }

        private void AddImage(Document document, string imagePath)
        {
            var image = iTextSharp.text.Image.GetInstance(File.ReadAllBytes(imagePath));
            image.ScalePercent(15f);

            Chunk chunk = new Chunk(image, 0f, -30f);

            Paragraph p = new Paragraph(chunk);
            p.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;

            document.Add(p);
        }

        private void PrintDocument(string file)
        {
            PrintManager manager = (PrintManager)MainActivity.AppContext.GetSystemService(Context.PrintService);

            try
            {
                PrintDocumentAdapter adapter = new PrintPDFAdapter(file);
                manager.Print("Document", adapter, new PrintAttributes.Builder()
                    .SetMediaSize(PrintAttributes.MediaSize.IsoA4)
                    .Build());
            }
            catch (Exception e)
            {
                Log.Error("PDF Printer", e.Message);
            }
        }

        private void AddNewItem(Document document, string text, int align, iTextSharp.text.Font font)
        {
            Paragraph p = new Paragraph(new Chunk(text, font));
            p.Alignment = align;
            document.Add(p);
        }

        private void AddSpace(Document document, iTextSharp.text.Font font)
        {
            document.Add(new Paragraph(new Chunk(" ", font)));
        }

        private void AddNewItemLeftAndRight(Document document, string leftText, string rightText, iTextSharp.text.Font font)
        {
            Chunk chunkLeft = new Chunk(leftText, font);
            Chunk chunkRight = new Chunk(rightText, font);
            Paragraph p = new Paragraph(chunkLeft);
            p.Add(new Chunk(new VerticalPositionMark()));
            p.Add(rightText);
            document.Add(p);
        }
    }
}