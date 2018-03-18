using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Imaging;
using TTB_Manager.Types;
using TTB_Manager.Database;
using System.Diagnostics;

namespace TTB_Manager.PDFCreator {
    class AccountingCreator {
        public String bill_nr = "Abrechnung";
        private String cur_date = DateTime.Now.Date.ToShortDateString() + "";
        public Workplace workplace = new Workplace();
        public List<Accounting_Position> position_list = new List<Accounting_Position>();
        public String date_start_string = "";
        public String date_end_string = "";
        public String deadline = "zum nächsten Monat";

        const float content_width_percentage = 80;
        const String iban = "DE02 8504 0000 0200 9025 00";
        Document doc;
        public AccountingCreator() {
        }
        public int create() {
            doc = new Document(iTextSharp.text.PageSize.A4, 1, 0, 50, 35);
            PdfWriter writer;
            try {
                // writer = PdfWriter.GetInstance(doc, new FileStream(bill_nr + ".pdf", FileMode.Create)); 
                writer = PdfWriter.GetInstance(doc, new FileStream("Abrechnung.pdf", FileMode.Create));
            } catch (IOException) {
                return -1;
            }
            doc.Open();

            float Margin_Left = doc.LeftMargin;
            float Magrin_Right = doc.RightMargin;
            float Margin_Bottom = doc.BottomMargin;
            float Margin_Top = doc.TopMargin;

            Paragraph paragraph;


            //Import header-image
            var logo = System.Drawing.Image.FromHbitmap(TTB_Manager.Properties.Resources.pdf_header.GetHbitmap());
            Image ABCRCLogo = Image.GetInstance(logo, System.Drawing.Imaging.ImageFormat.Tiff);
            ABCRCLogo.ScaleAbsolute(doc.PageSize.Width, doc.PageSize.Width*logo.Height/logo.Width-5);
            doc.Add(Image.GetInstance(ABCRCLogo));

            //Import underlined-adress-header
           
            String pdf_header_adress = "TTBPersonal UG, Martin-Luther-Straße 17, 01099 Dresden";
            paragraph = new Paragraph(pdf_header_adress, Default_Font(8,Font.UNDERLINE));
            doc.Add(setProps(paragraph, 1));
            doc.Add(new Paragraph("\n\n"));

            //Import header left and right
            PdfPTable table_header_text = new PdfPTable(2);
            table_header_text.DefaultCell.Border = 0;
            table_header_text.TotalWidth = doc.PageSize.Width * (content_width_percentage / 100);


            String pdf_adress = workplace.name + "\n"
                + workplace.ust_id + "\n"
                + workplace.extra + "\n"
                + workplace.accounting_adress.street + " " + workplace.accounting_adress.number + "\n"
                + workplace.accounting_adress.plz + " " + workplace.accounting_adress.city + "\n"
                + workplace.accounting_adress.country + "\n";
            paragraph = new Paragraph(pdf_adress, Default_Font(10));

            table_header_text.AddCell(paragraph);

            Phrase phrase = new Phrase();
            phrase.Add(new Chunk("Personalvermittlung & Personalleasing", Default_Font(11)));

            String pdf_header_right = "\n\nAnsprechpartner: Thomas Jahn\n\n"
                + "Tel.: (+49) 351 897 368 99\n"
                + "E-Mail: info@ttb-personal.de\n"
                + "Steuernummer: 202/121/09429\n\n"
                + "Datum: " + cur_date;
            phrase.Add(new Chunk(pdf_header_right, Default_Font(10)));

            paragraph = new Paragraph(phrase);
            PdfPCell cell = new PdfPCell(paragraph);
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table_header_text.AddCell(cell);


            doc.Add(table_header_text);




            //Import bill-nr
            String pdf_bill_nr = "Rechnung Nr.: " + bill_nr;
            paragraph = new Paragraph(pdf_bill_nr, Default_Font(10,Font.BOLD));
            doc.Add(setProps(paragraph,1));

            doc.Add(new Paragraph("\n\n"));

            //Import prev-mail
            String pdf_prev_mail = "";
            if (!workplace.contact_person.Equals("")) {
                if (workplace.gender_of_contact_person == 0) {
                    pdf_prev_mail = "Sehr geehrter Herr ";
                }
                else {
                    pdf_prev_mail = "Sehr geehrte Frau ";
                }
                pdf_prev_mail += workplace.contact_person;
            }
            else {
                pdf_prev_mail = "Sehr geehrte Damen und Herren";
            }


            pdf_prev_mail += ",\n\n"
                + "vielen Dank für die Zusammenarbeit mit unserem Unternehmen. Für die bei Ihnen erbrachten Leistungen stellen wir Ihnen folgenden Betrag in Rechnung:\n\n"
                + "Leistungszeitraum: " + date_start_string + " bis "+ date_end_string +"\n"
                + "Entleiher: " + workplace.name;
            paragraph = new Paragraph(pdf_prev_mail, Default_Font(10));
            doc.Add(setProps(paragraph,1.1f));

            //Import usage-line
            phrase = new Phrase();
            phrase.Add(new Chunk("Verwendungszweck: ", Default_Font(10)));
            phrase.Add(new Chunk(bill_nr, Default_Font(10,Font.BOLD)));

            paragraph = new Paragraph(phrase);
            doc.Add(setProps(paragraph, 1.1f));

            doc.Add(new Paragraph("\n"));
            /*
             //Testliste
            for (int k=0;k<5;k++) {
                Accounting_Position ap = new Accounting_Position();
                ap.amount = k + 3;
                ap.description = "";
                ap.price = 2.5f;
                ap.tax = 19f;
                ap.unit = Unit.Std;
                position_list.Add(ap);

            }
            */

            //Import position_table
            PdfPTable table_positions = new PdfPTable(7);
            table_positions.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
            float default_border_width = table_positions.DefaultCell.BorderWidth;
            table_positions.DefaultCell.BorderWidth = 2;

            table_positions.AddCell(new Paragraph("Pos.", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Anzahl", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Einheit", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Beschreibung", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Preis in €/h", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("MwSt. in %", Default_Font(10, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Gesamt in €", Default_Font(10, Font.BOLD)));

            
            float[] floatWidths = { 7, 10, 10, 43, 7, 8, 10 };
            table_positions.SetWidths(floatWidths);
            table_positions.TotalWidth = doc.PageSize.Width * (content_width_percentage / 100);

            table_positions.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
            table_positions.DefaultCell.BorderWidth = default_border_width;

            for (int i=0;i<position_list.Count;i++) {
                table_positions.AddCell(new Paragraph("" + (i+1), Default_Font(10)));
                table_positions.AddCell(new Paragraph("" + position_list[i].amount.ToString("0.0"), Default_Font(10)));
                table_positions.AddCell(new Paragraph("" + position_list[i].unit + ".", Default_Font(10)));
                try {
                    if (position_list[i].description.Equals("")) {
                        table_positions.AddCell(new Paragraph("Personalüberlassung", Default_Font(10)));
                    }
                    else {
                        table_positions.AddCell(new Paragraph("" + position_list[i].description, Default_Font(10)));
                    }
                } catch (NullReferenceException) {
                    doc.Close();
                    return 0;
                }

                
                table_positions.AddCell(new Paragraph("" + position_list[i].price.ToString("0.00"), Default_Font(10)));
                table_positions.AddCell(new Paragraph("" + position_list[i].tax.ToString("0.00"), Default_Font(10)));
                table_positions.AddCell(new Paragraph("" + (position_list[i].price* position_list[i].amount).ToString("0.00"), Default_Font(10)));
            }
            doc.Add(table_positions);

            //Calculate Sums
            double pdf_netto = 0,
            pdf_mwst = 0,
            pdf_sum = 0;
            for (int i=0;i<position_list.Count;i++) {
                pdf_netto += position_list[i].amount * position_list[i].price;
                pdf_mwst += position_list[i].amount * position_list[i].price * (position_list[i].tax/100);
                
            }
            pdf_sum = pdf_mwst + pdf_netto;


            //Import Results (Netto ...)

            PdfPTable table_sums = new PdfPTable(2);
            table_sums.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
            float[] sumtable_floatWidths = { 65,35 };
            table_sums.SetWidths(sumtable_floatWidths);
            table_sums.TotalWidth = 200f;
            table_sums.LockedWidth = true;
            table_sums.HorizontalAlignment = Element.ALIGN_RIGHT;

            table_sums.AddCell(new Paragraph("NETTO", Default_Font(10, Font.BOLD)));
            table_sums.AddCell(new Paragraph(pdf_netto.ToString("0.00") + " €", Default_Font(10, Font.BOLD)));
            table_sums.AddCell(new Paragraph("MwSt.", Default_Font(10, Font.BOLD)));
            table_sums.AddCell(new Paragraph(pdf_mwst.ToString("0.00") + " €", Default_Font(10, Font.BOLD)));
            table_sums.AddCell(new Paragraph("Summe", Default_Font(10, Font.BOLD)));
            table_sums.AddCell(new Paragraph(pdf_sum.ToString("0.00") + " €", Default_Font(10, Font.BOLD)));

            PdfPTable table_sumsInSums= new PdfPTable(2);
            table_sumsInSums.TotalWidth = doc.PageSize.Width * (content_width_percentage / 100);
            table_sumsInSums.DefaultCell.Border = 0;
            cell = new PdfPCell(table_sums);
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table_sumsInSums.AddCell("");
            table_sumsInSums.AddCell(cell);

            doc.Add(table_sumsInSums);




            doc.Add(new Paragraph("\n"));

            //Import suf-mail
            phrase = new Phrase();
            String pdf_suf_mail1 = "Die genauen Arbeitszeiten entnehmen Sie bitte dem Ihnen vorliegenden „Arbeitszeitennachweis Arbeitgeber“. Bitte überweisen Sie den Betrag ";
            String pdf_suf_mail2 = "bis " + deadline;
            String pdf_suf_mail3 = " auf das unten angegebene Konto. Über eine weitere Zusammenarbeit mit Ihnen freuen wir uns sehr.\n"
                + "Sehr geehrte Daen und Herren, unsere Kontoverbindungen haben sich geändert. Bitte überweisen Sie künftig die Rechnungen auf das Konto mit der\n";
            phrase.Add(new Chunk(pdf_suf_mail1, Default_Font(10)));
            phrase.Add(new Chunk(pdf_suf_mail2, Default_Font(10,Font.BOLD)));
            phrase.Add(new Chunk(pdf_suf_mail3, Default_Font(10)));

            String pdf_iban = "            IBAN: " + iban + "\n";
            phrase.Add(new Chunk(pdf_iban, Default_Font(10, Font.BOLD)));

            String pdf_suf_mail4 = "bei der Commerzbank Dresden. Bis 30.03.2017 ist unser Konto bei der Dresdner Volksbank noch aktiv.";
            phrase.Add(new Chunk(pdf_suf_mail4, Default_Font(10)));

            paragraph = new Paragraph(phrase);
            doc.Add(setProps(paragraph, 1.1f));

            doc.Add(new Paragraph("\n\n"));

            //Import greeting
            String pdf_greeting = "Mit freundlichen Grüßen\n\n"
            + "Thomas Jahn\n"
            + "TTBPersonal UG";
            paragraph = new Paragraph(pdf_greeting, Default_Font(10));
            doc.Add(setProps(paragraph, 1.1f));


            doc.Close();
            return 1;
        }
        public Paragraph setProps(Paragraph p, float abs_space) {
            float margin = (doc.PageSize.Width - (doc.PageSize.Width * (content_width_percentage/100f))) / 2f;
            p.IndentationLeft = margin;
            p.IndentationRight = margin;
            p.SetLeading(1, abs_space);
            return p;
        }
        public Font Default_Font(int size) {
            return FontFactory.GetFont("Arial", size);
        }
        public Font Default_Font(int size, int style) {
            return FontFactory.GetFont("Arial", size, style);
        }
        public bool open() {
            try {
                Process proc = new Process();
                proc.StartInfo.FileName = "Abrechnung.pdf";
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                return true;
            } catch { return false; }

        }
    }
}
