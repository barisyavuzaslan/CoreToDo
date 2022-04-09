using CoreProject.ToDo.BusinessLayer.Interfaces;
using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] TransferExcel<T>(List<T> list) where T : class, new()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Sheet1");
            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);
            return excelPackage.GetAsByteArray();
        }

        public string TransferPdf<T>(List<T> list) where T : class, new()
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var filename = Guid.NewGuid() + ".pdf";
            var returnpath = "/Documents/" + filename;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Documents/" + filename);
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            PdfPTable pdfPTable = new PdfPTable(dataTable.Rows.Count);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                pdfPTable.AddCell(dataTable.Columns[i].ColumnName);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }
            document.Add(pdfPTable);
            document.Close();
            return returnpath;
        }
    }
}
