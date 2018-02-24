﻿using System;
using System.IO;

namespace SpreadsheetCalculator
{
    /// <summary>
    /// Write spreadsheet to StdOut.
    /// </summary>
    class SpreadsheetWriter
    {
        /// <summary>
        /// Spreadsheet data source.
        /// </summary>
        private TextWriter _tOut;

        /// <summary>
        /// Create new SpreadsheetReader.
        /// </summary>
        /// <param name="tOut">Output writer that can write a sequential series of characters. Will be used for spreadsheet output.</param>
        public SpreadsheetWriter(TextWriter tOut)
        {
            _tOut = tOut ?? throw new ArgumentNullException(nameof(tOut));
        }

        /// <summary>
        /// Write Spreadsheet to output stream.
        /// </summary>
        public void Write(Spreadsheet spreadsheet)
        {
            _tOut.WriteLine("{0} {1}", spreadsheet.ColumnNumber, spreadsheet.RowNumber );

            for (var rowNumber = 0; rowNumber < spreadsheet.RowNumber; rowNumber++)
            {
                for (var columnNumber = 0; columnNumber < spreadsheet.ColumnNumber; columnNumber++)
                {
                    var value = spreadsheet.Cells[rowNumber, columnNumber].GetCellValue();
                    var output = "";

                    if (value.HasValue)
                    {
                        output = value.Value.ToString("F5");
                    }

                    _tOut.WriteLine(output);

                }
            }
        }
    }
}