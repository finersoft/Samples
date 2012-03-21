﻿using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

using LateBindingApi.Core;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;

namespace Example02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize Api COMObject Support
            LateBindingApi.Core.Factory.Initialize();

            // start excel and turn off msg boxes
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = false;

            // add a new workbook
            Excel.Workbook workBook = excelApplication.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];

            // font action
            workSheet.Range("A1").Value = "Arial Size:8 Bold Italic Underline";
            workSheet.Range("A1").Font.Name = "Arial";
            workSheet.Range("A1").Font.Size = 8;
            workSheet.Range("A1").Font.Bold = true;
            workSheet.Range("A1").Font.Italic = true;
            workSheet.Range("A1").Font.Underline = true;
            workSheet.Range("A1").Font.Color = Color.Violet.ToArgb();

            workSheet.Range("A3").Value = "Times New Roman Size:10";
            workSheet.Range("A3").Font.Name = "Times New Roman";
            workSheet.Range("A3").Font.Size = 10;
            workSheet.Range("A3").Font.Color = Color.Orange.ToArgb();

            workSheet.Range("A5").Value = "Comic Sans MS Size:12 WrapText";
            workSheet.Range("A5").Font.Name = "Comic Sans MS";
            workSheet.Range("A5").Font.Size = 12;
            workSheet.Range("A5").WrapText = true;
            workSheet.Range("A5").Font.Color = Color.Navy.ToArgb();

            // HorizontalAlignment
            workSheet.Range("A7").Value = "xlHAlignLeft";
            workSheet.Range("A7").HorizontalAlignment = XlHAlign.xlHAlignLeft;

            workSheet.Range("B7").Value = "xlHAlignCenter";
            workSheet.Range("B7").HorizontalAlignment  = XlHAlign.xlHAlignCenter;

            workSheet.Range("C7").Value = "xlHAlignRight";
            workSheet.Range("C7").HorizontalAlignment = XlHAlign.xlHAlignRight;

            workSheet.Range("D7").Value = "xlHAlignJustify";
            workSheet.Range("D7").HorizontalAlignment = XlHAlign.xlHAlignJustify;

            workSheet.Range("E7").Value = "xlHAlignDistributed";
            workSheet.Range("E7").HorizontalAlignment = XlHAlign.xlHAlignDistributed;

            // VerticalAlignment
            workSheet.Range("A9").Value = "xlVAlignTop";
            workSheet.Range("A9").VerticalAlignment = XlVAlign.xlVAlignTop;

            workSheet.Range("B9").Value = "xlVAlignCenter";
            workSheet.Range("B9").VerticalAlignment = XlVAlign.xlVAlignCenter;

            workSheet.Range("C9").Value = "xlVAlignBottom";
            workSheet.Range("C9").VerticalAlignment = XlVAlign.xlVAlignBottom;

            workSheet.Range("D9").Value = "xlVAlignDistributed";
            workSheet.Range("D9").VerticalAlignment = XlVAlign.xlVAlignDistributed;

            workSheet.Range("E9").Value = "xlVAlignJustify";
            workSheet.Range("E9").VerticalAlignment = XlVAlign.xlVAlignJustify;

            // setup rows and columns
            workSheet.Columns[1, Missing.Value].AutoFit();
            workSheet.Columns[2, Missing.Value].ColumnWidth = 25;
            workSheet.Columns[3, Missing.Value].ColumnWidth = 25;
            workSheet.Columns[4, Missing.Value].ColumnWidth = 25;
            workSheet.Columns[5, Missing.Value].ColumnWidth = 25;
            workSheet.Rows[9, Missing.Value].RowHeight = 25;

            // save the book
            string fileExtension = GetDefaultExtension(excelApplication);
            string workbookFile = string.Format("{0}\\Example02{1}", Application.StartupPath, fileExtension);
            workBook.SaveAs(workbookFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive);

            // close excel and dispose reference
            excelApplication.Quit();
            excelApplication.Dispose();

            FinishDialog fDialog = new FinishDialog("Workbook saved.", workbookFile);
            fDialog.ShowDialog(this);
        }

        #region Helper

        /// <summary>
        /// returns the valid file extension for the instance. for example ".xls" or ".xlsx"
        /// </summary>
        /// <param name="application">the instance</param>
        /// <returns>the extension</returns>
        private static string GetDefaultExtension(Excel.Application application)
        {
            double version = Convert.ToDouble(application.Version);
            if (version >= 120.00)
                return ".xlsx";
            else
                return ".xls";
        }

        #endregion
    }
}