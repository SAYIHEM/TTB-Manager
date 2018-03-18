using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TTB_Manager.Types;
using System.IO;
using System.Diagnostics;
using TTB_Manager.Database;

namespace TTB_Manager.PDFCreator {
    class WorkProofCreator {
        Document doc;
        public List<WorkProof> wp_list = new List<WorkProof>();
        public String startdate = "";
        public String enddate = "";
        public Workplace workplace;
        public String bill_nr = "";
        DB_Manager db_manager = new DB_Manager();
        int content_width_percentage = 80;
        public WorkProofCreator() {

        }
        public int create() {
            doc = new Document(iTextSharp.text.PageSize.A4, 1, 0, 20, 35);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer;
            try {
                // writer = PdfWriter.GetInstance(doc, new FileStream(bill_nr + ".pdf", FileMode.Create)); 
                writer = PdfWriter.GetInstance(doc, new FileStream("Arbeitsnachweis.pdf", FileMode.Create));
            } catch (IOException) {
                return -1;
            }
            doc.Open();

            //Writing the content....
            //*************************

            Paragraph paragraph;

            var logo = System.Drawing.Image.FromHbitmap(TTB_Manager.Properties.Resources.pdf_header.GetHbitmap());
            Image ABCRCLogo = Image.GetInstance(logo, System.Drawing.Imaging.ImageFormat.Tiff);
            ABCRCLogo.ScaleAbsolute(doc.PageSize.Width, doc.PageSize.Width * logo.Height / logo.Width - 5);
            doc.Add(Image.GetInstance(ABCRCLogo));

            doc.Add(new Paragraph("\n"));
            //Import header left and right
            PdfPTable table_header_text = new PdfPTable(2);
            table_header_text.DefaultCell.Border = 0;
            table_header_text.TotalWidth = doc.PageSize.Width * (content_width_percentage / 100);

            paragraph = new Paragraph("", Default_Font(16));
            paragraph.Add("Arbeitszeitennachweis Arbeitgeber");
            paragraph.Add("\n\n\n");
            PdfPCell cell = new PdfPCell();
            cell.AddElement(paragraph);

            String date = "Datum: " + startdate + " bis " + enddate;
            paragraph = new Paragraph(date, Default_Font(14, Font.UNDERLINE));
            cell.AddElement(paragraph);
            cell.Border = 0;

            table_header_text.AddCell(cell);

            Phrase phrase = new Phrase();
            phrase.Add(new Chunk("TTBPersonal UG\nMartin-Luther-Strße 17\n01099 Dresden\n\n", Default_Font(12)));

            String pdf_header_right = "Ansprechpartner: Thomas Jahn\n"
                + "Tel.: (+49) 351 897 368 99\n"
                + "Fax (+49) 911 308 445 451 4\n"
                + "E-Mail: info@ttb-personal.de\n";
            phrase.Add(new Chunk(pdf_header_right, Default_Font(12)));
            phrase.Add(new Chunk("(Bitte jeden Monatg per Fax an TTB senden)", Default_Font(10)));

            paragraph = new Paragraph(phrase);
            cell = new PdfPCell(setProps(paragraph, 1.2f));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table_header_text.AddCell(cell);

            doc.Add(table_header_text);

            //Import underlined workplace string
            String pdf_workplace = "Arbeitgeber: ";
            pdf_workplace += workplace.name + " " + workplace.adress.street + " " + workplace.adress.number + " - " + bill_nr;
            paragraph = new Paragraph(pdf_workplace, Default_Font(12));
            doc.Add(setProps(paragraph, 1));

            doc.Add(new Paragraph("\n\n"));

            //Import position_table
            PdfPTable table_positions = new PdfPTable(10);

            table_positions.AddCell(new Paragraph("Tag", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Datum", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Name", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Vorname", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Von", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Bis", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Pause", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Dauer", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Tätigkeit", Default_Font(12, Font.BOLD)));
            table_positions.AddCell(new Paragraph("Unterschrift AN", Default_Font(12, Font.BOLD)));


            float[] floatWidths = { 5, 10, 15, 15, 6, 8, 8, 6, 12, 15 };
            table_positions.SetWidths(floatWidths);
            table_positions.TotalWidth = doc.PageSize.Width * (content_width_percentage / 100);

            for (int i = 0; i < wp_list.Count; i++) {
                table_positions.AddCell(new Paragraph("" + wp_list[i].day, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].date, Default_Font(12)));

                String lastnames = "";
                String firstnames = "";
                try {
                    for (int k = 0; k < wp_list[i].lastnames.Count; k++) {
                        lastnames += wp_list[i].lastnames[k];
                        if (wp_list[i].lastnames.Count > k + 1) {
                            lastnames += "\n";
                        }
                    }

                    for (int k = 0; k < wp_list[i].firstnames.Count; k++) {
                        firstnames += wp_list[i].firstnames[k];
                        if (wp_list[i].firstnames.Count > k + 1) {
                            firstnames += "\n";
                        }
                    }
                } catch { }
                
                table_positions.AddCell(new Paragraph("" + lastnames, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + firstnames, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].starttime, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].enddtime, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].break_time, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].duration, Default_Font(12)));
                table_positions.AddCell(new Paragraph("" + wp_list[i].name, Default_Font(12)));
                table_positions.AddCell(new Paragraph(" ")); //Signature

            }
            doc.Add(table_positions);
            doc.Add(setProps(new Paragraph("\n\n\nDatum/Unterschrift/Stempel Auftraggeber:"), 1));

            doc.Close();
            return 1;

        }
        public bool open() {
            try {
                Process proc = new Process();
                proc.StartInfo.FileName = "Arbeitsnachweis.pdf";
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                return true;
            } catch { return false; }
        }
        public Paragraph setProps(Paragraph p, float abs_space) {
            float margin = (doc.PageSize.Width - (doc.PageSize.Width * (content_width_percentage / 100f))) / 2f;
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

    }
}
