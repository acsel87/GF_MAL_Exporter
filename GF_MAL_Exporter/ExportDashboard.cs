using ExportLibrary.DataAccess;
using ExportLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GF_MAL_Exporter
{
    public partial class ExportDashboard : Form
    {
        string inputFilePath = "";
        string outputFilePath = "";
        string inputFileType = "html";
        string outputFileType = "txt";

        bool isAdd = false;

        public ExportDashboard()
        {
            InitializeComponent();
            
            sourceComboBox.SelectedIndex = 0;
            tableComboBox.SelectedIndex = 0;

            CheckOutputType();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = $"{inputFileType} (*.{inputFileType})|*.{inputFileType}",
                Title = $"Select a {inputFileType} File"
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFile.FileName;
                pathTextBox.Text = inputFilePath;
            }           
        }
        
        private void CheckOutputType()
        {
            if (txtRadioButton.Checked)
            {
                outputFileType = "txt";
            }
            else if (csvRadioButton.Checked)
            {
                outputFileType = "csv";
            }
        }

        private void SourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceComboBox.SelectedIndex == 0)
            {
                inputFileType = "html";
            }
            else if (sourceComboBox.SelectedIndex == 1)
            {
                inputFileType = "xml";
            }

            pathTextBox.Text = "";
            exportPanel.Enabled = false;
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pathTextBox.Text == "")
            {
                exportPanel.Enabled = false;
            }
            else
            {
                exportPanel.Enabled = true;
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            CheckOutputType();

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = $"{outputFileType} (*.{outputFileType})|*.{outputFileType}",
                Title = $"Save as {outputFileType} File"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = saveFile.FileName;

                if (sourceComboBox.SelectedIndex == 0)
                {
                    List<GFModel> modelsGF = new List<GFModel>();

                    try
                    {
                        modelsGF = ImportGF.ParseHTML(inputFilePath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid file");

                        return;
                    }                    

                    if (outputFileType == "txt")
                    {
                        ExportTXT exportTXT = new ExportTXT(modelsGF, outputFilePath);
                    }
                    else if (outputFileType == "csv")
                    {
                        ExportCSV exportCSV = new ExportCSV(modelsGF, outputFilePath);
                    }
                }
                else if (sourceComboBox.SelectedIndex == 1)
                {
                    List<MALModel> modelsMAL = new List<MALModel>();

                    try
                    {
                        modelsMAL = ImportMAL.ParseXML(inputFilePath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid file");

                        return;
                    }

                    if (outputFileType == "txt")
                    {
                        ExportTXT exportTXT = new ExportTXT(modelsMAL, outputFilePath);
                    }
                    else if (outputFileType == "csv")
                    {
                        ExportCSV exportCSV = new ExportCSV(modelsMAL, outputFilePath);
                    }
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SqlConnector sqlConnector = new SqlConnector(isAdd, backupCheckBox.Checked);

            if (sourceComboBox.SelectedIndex == 0)
            {
                List<GFModel> modelsGF = new List<GFModel>();

                try
                {
                    modelsGF = ImportGF.ParseHTML(inputFilePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid file");

                    return;
                }

                try
                {
                    sqlConnector.CreateGF(modelsGF);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error connecting to the Database");
                }
                
            }
            else if (sourceComboBox.SelectedIndex == 1)
            {
                List<MALModel> modelsMAL = new List<MALModel>();

                try
                {
                    modelsMAL = ImportMAL.ParseXML(inputFilePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid file");

                    return;
                }

                try
                {
                    sqlConnector.CreateMAL(modelsMAL);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error connecting to the Database");
                }                
            }
        }

        private void TableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableComboBox.SelectedIndex == 0)
            {
                isAdd = false;
            }
            else if (tableComboBox.SelectedIndex == 1)
            {
                isAdd = true;
            }
        }
    }
}
