using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;


namespace SICO.DistributedServices.Core
{
    public class ExcelFileResult<T> : ActionResult where T : class
    {
        private IEnumerable<T> _models;
        public ExcelFileResult(IEnumerable<T> models, string fileDownloadName, string contentType) : this(models, fileDownloadName)
        {
            ContentType = contentType;
        }
        public ExcelFileResult(IEnumerable<T> models, string fileDownloadName)
        {
            FileDownloadName = fileDownloadName;
            _models = models;
            ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }
        public string ContentType { get; private set; }
        public string FileDownloadName { get; private set; }
        public override void ExecuteResult(ActionContext context)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                using (var workbook = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook))
                {
                    var workbookPart = workbook.AddWorkbookPart();
                    workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                    workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId = sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = "Sheet1" };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<string> columns = new List<string>();
                    var properties = typeof(T).GetProperties();

                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                        columns.Add(attribute.Name);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(attribute.Name);
                        headerRow.AppendChild(cell);
                     
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (var item in _models)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                       
                        foreach (var header in properties)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;

                            var value = header.GetValue(item);
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(value?.ToString()); 
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                    }                    

                    sheetPart.Worksheet.Save();
                    workbook.WorkbookPart.Workbook.Save();
                    workbook.Close();

                    context.HttpContext.Response.ContentType = ContentType;
                    context.HttpContext.Response.Headers.Add("Content-Disposition", new[] { "attachment; filename=" + FileDownloadName });

                    var dgg = mem.ToArray();
                    context.HttpContext.Response.Body.Write(dgg, 0, dgg.Length);

                    //context.HttpContext.Response.Body.Write()

                    //mem.CopyTo(context.HttpContext.Response.Body);                  

                }
            }
        }

    }
}
