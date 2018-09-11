﻿using System.Collections.Generic;

namespace SpreadsheetCalculator.Spreadsheet
{
    /// <summary>
    /// A rectangular array of objects arranged in rows and columns.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Matrix<T> where T : class
    {
        private T[,] Cells { get; }

        /// <summary>
        /// Rows count in matrix.
        /// </summary>
        public int RowsCount => Cells.GetLength(1);

        /// <summary>
        /// Columns count in matrix.
        /// </summary>
        public int ColumnsCount => Cells.GetLength(0);

        /// <summary>
        /// Create new matrix with specified size.
        /// </summary>
        /// <param name="columnsCount">Columns count in matrix.</param>
        /// <param name="rowsCount">Rows count in matrix.</param>
        public Matrix(int columnsCount, int rowsCount)
        {
            Cells = new T[columnsCount, rowsCount];
        }

        /// <summary>
        /// Check if cell coordinates is inside matrix.
        /// </summary>
        /// <param name="column">Column in matrix.</param>
        /// <param name="row">Row in matrix.</param>
        /// <returns></returns>
        public bool InMatrix(int column, int row)
        {
            return InRange(column - 1, 0, ColumnsCount) && InRange(row - 1, 0, RowsCount);

            bool InRange(int target, int start, int end) => target >= start && target <= end;
        }

        /// <summary>
        /// Define the indexer to allow client code to use [] notation.
        /// </summary>
        /// <param name="column">Column in matrix.</param>
        /// <param name="row">Row in matrix.</param>
        /// <returns></returns>
        public T this[int column, int row]
        {
            get => Cells[column - 1, row - 1];
            set => Cells[column - 1, row - 1] = value;
        }

        /// <summary>
        /// Get plain collection (row by row) of all elements in Matrix.
        /// </summary>
        /// <returns>All matrix elements row by row.</returns>
        public IEnumerable<T> AsEnumerable()
        {
            for (var i = 0; i < ColumnsCount; i++)
            {
                for (var j = 0; j < RowsCount; j++)
                {
                    yield return Cells[i, j];
                }
            }
        }
    }
}