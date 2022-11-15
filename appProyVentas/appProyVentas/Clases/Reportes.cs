using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iText.Kernel.Pdf;
using iText.Layout;
using iTextLE = iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;
namespace appProyVentas.Clases
{
    public class Reportes
    {
        public static byte[] ExportarPDF(GridView gvDatos, string titulo)
        {
            //iTextLE.Image img = new iTextLE.Image(ImageDataFactory.Create(archivoLogo)).SetTextAlignment(TextAlignment.LEFT);
            //img.SetHeight(50);
            //img.SetWidth(60);
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                using (var pdfDoc = new PdfDocument(writer))
                {
                    pdfDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                    Document doc = new Document(pdfDoc);
                    doc.SetFontSize(7);

                    // Cabecera en Tabla
                    iTextLE.Table tablaTitulo = new iTextLE.Table(3);
                    tablaTitulo.SetWidth(UnitValue.CreatePercentValue(100));

                    iTextLE.Cell celdaTitulo;
                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    //celdaTitulo.Add(img);
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(20));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    tablaTitulo.AddCell(celdaTitulo);

                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    celdaTitulo.Add(new iTextLE.Paragraph(titulo));
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(60));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetTextAlignment(TextAlignment.CENTER);
                    celdaTitulo.SetFontSize(14);
                    celdaTitulo.SetBold();
                    tablaTitulo.AddCell(celdaTitulo);

                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    celdaTitulo.Add(new iTextLE.Paragraph(""));
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(20));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetTextAlignment(TextAlignment.CENTER);
                    celdaTitulo.SetFontSize(14);
                    tablaTitulo.AddCell(celdaTitulo);

                    doc.Add(tablaTitulo);
                    //

                    // Cabecera Normal
                    //doc.Add(img);
                    //iTextLE.Paragraph c1 = new iTextLE.Paragraph(titulo);
                    //c1.SetFontSize(10);
                    //c1.SetTextAlignment(TextAlignment.CENTER);
                    //doc.Add(c1);

                    // Datos
                    iText.Kernel.Colors.Color colorFondoCabecera = new iText.Kernel.Colors.DeviceRgb(10, 49, 71);

                    if (gvDatos.Rows.Count > 0)
                    {
                        iTextLE.Table tabla = new iTextLE.Table(gvDatos.Rows[0].Cells.Count);
                        iTextLE.Cell celda;
                        for (int i = 0; i < gvDatos.HeaderRow.Cells.Count; i++)
                        {
                            celda = new iTextLE.Cell();
                            celda.Add(new iTextLE.Paragraph(WebUtility.HtmlDecode(gvDatos.HeaderRow.Cells[i].Text)));
                            celda.SetBold();
                            celda.SetBackgroundColor(colorFondoCabecera);
                            celda.SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE);
                            tabla.AddHeaderCell(celda);
                        }

                        for (int i = 0; i < gvDatos.Rows.Count; i++)
                        {
                            for (int j = 0; j < gvDatos.Rows[i].Cells.Count; j++)
                            {
                                celda = new iTextLE.Cell();
                                celda.Add(new iTextLE.Paragraph(WebUtility.HtmlDecode(gvDatos.Rows[i].Cells[j].Text)));
                                tabla.AddCell(celda);
                            }
                        }
                        doc.Add(tabla);
                    }
                    doc.Close();
                    writer.Close();

                    byte[] buffer = ms.ToArray();
                    return buffer;
                }
            }
        }

        //public static byte[] ExportarExcel(GridView gvDatos, FileInfo infoLogo, string titulo)
        public static byte[] ExportarExcel(GridView gvDatos,string titulo)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage ep = new ExcelPackage())
                {
                    ep.Workbook.Worksheets.Add("Reporte");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                    // Cabecera
                    //ExcelPicture pic = ew.Drawings.AddPicture("Logo", infoLogo);
                    //pic.SetPosition(0, 0, 0, 0);
                    //pic.SetSize(60, 50);

                    ew.Cells[1, 2].Value = titulo;
                    ew.Cells[1, 2].Style.Font.Size = 14;
                    ew.Cells[1, 2].Style.Font.Bold = true;
                    ew.Cells[1, 2, 2, gvDatos.HeaderRow.Cells.Count].Merge = true;
                    ew.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ew.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ew.Row(1).Height = 25;
                    // Datos
                    System.Drawing.Color colorFondoCabecera = System.Drawing.ColorTranslator.FromHtml("#0a3147");
                    if (gvDatos.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvDatos.HeaderRow.Cells.Count; i++)
                        {
                            ew.Cells[3, i + 1].Value = WebUtility.HtmlDecode(gvDatos.HeaderRow.Cells[i].Text);
                            ew.Cells[3, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ew.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(colorFondoCabecera);
                            ew.Cells[3, i + 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                            ew.Cells[3, i + 1].Style.Font.Bold = true;
                            ew.Column(i + 1).Width = 30;
                        }

                        for (int i = 0; i < gvDatos.Rows.Count; i++)
                        {
                            for (int j = 0; j < gvDatos.Rows[0].Cells.Count; j++)
                            {
                                ew.Cells[i + 4, j + 1].Value = WebUtility.HtmlDecode(gvDatos.Rows[i].Cells[j].Text);
                            }
                        }
                    }
                    ep.SaveAs(ms);

                    byte[] buffer = ms.ToArray();
                    return buffer;
                }
            }
        }
    }
}