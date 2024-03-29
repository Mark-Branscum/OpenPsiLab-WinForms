﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Views
{
    public partial class AddFilesForm : Form
    {
        private OPLConfiguration oplConfig { get; set; }

        public AddFilesForm(List<string> filePaths, OPLConfiguration oplConfiguration)
        {
            InitializeComponent();

            oplConfig = oplConfiguration;

            //Add existing file paths to grid
            if (filePaths != null && filePaths.Count > 0)
            {
                foreach (string filePath in filePaths)
                {
                    string[] row = { "View", filePath };
                    fileDataGridView.Rows.Add(row);
                    fileDataGridView.Refresh();
                }
            }
            
            //Setup working directory
            string dir = Directory.GetCurrentDirectory();
            if (string.IsNullOrWhiteSpace(oplConfig.AddFilePath))
            {
                oplConfig.AddFilePath = dir;
            }
            fileDataGridView.ClearSelection();
            fileDataGridView.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string dir = Directory.GetCurrentDirectory();
            string savedPath = oplConfig.AddFilePath;
            if (string.IsNullOrWhiteSpace(savedPath)
                || !Directory.Exists(savedPath))
            {
                dlg.InitialDirectory = dir;
                oplConfig.AddFilePath = dir;
            }
            else
            {
                dlg.InitialDirectory = savedPath;
            }

            dlg.Filter = "All files (*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in dlg.FileNames)
                {
                    bool fileMatch = false;
                    foreach (DataGridViewRow gridRow in fileDataGridView.Rows)
                    {
                        string gridFileName = gridRow.Cells[1].Value.ToString();
                        if (gridFileName.Trim().ToLower() == fileName.Trim().ToLower())
                            fileMatch = true;
                    }
                    if (fileMatch == true)
                        continue;
                    string[] row = { "View", fileName };
                    fileDataGridView.Rows.Add(row);
                    oplConfig.AddFilePath = Path.GetDirectoryName(fileName);
                }
            }
            fileDataGridView.ClearSelection();
            fileDataGridView.Refresh();
            this.Refresh();
        }

        private void fileDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView fileGrid = (DataGridView)sender;
            if (fileGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string filePath = fileDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            SortedSet<int> rowIndexes = new SortedSet<int>();
            foreach (DataGridViewCell gridCell in fileDataGridView.SelectedCells)
            {
                rowIndexes.Add(gridCell.RowIndex);
            }

            foreach (int rowIndex in rowIndexes.Reverse())
            {
                fileDataGridView.Rows.RemoveAt(rowIndex);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddFilesForm_Activated(object sender, EventArgs e)
        {
            fileDataGridView.ClearSelection();
            fileDataGridView.Refresh();
        }
    }
}
