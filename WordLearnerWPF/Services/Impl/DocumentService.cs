using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using WordLearnerWPF.Services.Abstract;

namespace WordLearnerWPF.Services.Impl
{
    public class DocumentService : IDocumentService
    {
        public bool IsValidFormat(string format, string path)
        {
            if (path.Length <= format.Length)
            {
                return false;
            }

            string pathFormat = path.Substring(path.Length - format.Length, format.Length);

            if (pathFormat == format)
            {
                return true;
            }
            else { return false; }
        }

        public Dictionary<string, string> GetDictionaryFromXls(string path, int start, int end, string askLabel = "A", string answLabel = "B")
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(path, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                int wbPartRowCount = document.WorkbookPart.WorksheetParts.First().Worksheet.Elements<SheetData>().First().Elements<Row>().Count();
                var count = 0;
                if (end <= wbPartRowCount)
                {
                    count = end;
                }
                else count = wbPartRowCount;

                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().First();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                if (start <= count)
                {
                    for (int i = start; i <= count; i++)
                    {
                        string ask = GetCellData(askLabel, i, wsPart, wbPart);
                        string answ = GetCellData(answLabel, i, wsPart, wbPart);
                        if (!dictionary.ContainsKey(ask))
                        {
                            dictionary.Add(ask, answ);
                        }
                    }
                }
                return dictionary;

            }


            string GetCellData(string label, int i, WorksheetPart wsPart, WorkbookPart wbPart)
            {
                string value = "";
                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                   Where(c => c.CellReference == $"{label}{i}").FirstOrDefault();

                if (theCell != null)
                {
                    value = theCell.InnerText;

                    if (theCell.DataType != null)
                    {
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:

                                var stringTable =
                                    wbPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();

                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                                else value = "00";
                                break;

                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;

                                    default:
                                        value = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
                }
                else value = "--";
                return value;
            }
        }
    }
}
