using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._1
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        private static readonly string PROCESS_ZIP_PATH = "ProcessZip.exe";
        private static readonly string PROCESS_HASHING_PATH = "ProcessHash.exe";
        private static readonly string PROCESS_PNG_CONVERTING_PATH = "ProcessPngConverting.exe";

        private static readonly string[] graphicalExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };

        private bool checkIfFileSelected = false;
        private bool isGraphical = false;
        private MetroCheckBox[] checkboxes;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (checkIfAdmin())
            {
                MetroFramework.MetroMessageBox.Show(this, "No admin rights for it:)", "Exiting...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            progressSpinner.Spinning = false;
            progressSpinner.Visible = false;
            btnPanel.Focus();
            filePathLabel.Text = "???";
            checkboxes = new MetroCheckBox[]{ zipChB, hashChb, pngConverterButton };
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            btnPanel.Focus();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose file";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                checkIfFileSelected = true;
                filePathLabel.Text = openFileDialog.FileName;
                isGraphical = Array.IndexOf(graphicalExtensions, Path.GetExtension(openFileDialog.FileName).ToLower()) != -1;

                if (isGraphical)
                {
                    pngConverterButton.Enabled = true;
                }
                else
                {
                    pngConverterButton.Checked = false;
                    pngConverterButton.Enabled = false;
                }
            }

        }

        private async void doButton_Click(object sender, EventArgs e)
        {
            btnPanel.Focus();

            if (!checkIfFileSelected)
            {
                MetroFramework.MetroMessageBox.Show(this, "No file was selected:(", "File is not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool checkIfActionSelected = false;
            foreach(var checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    checkIfActionSelected = true;
                    break;
                }
            }


            if (!checkIfActionSelected)
            {
                MetroFramework.MetroMessageBox.Show(this, "No action was selected:(", "Actions are not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Task> processes = new List<Task>();

            progressSpinner.Spinning = true;
            progressSpinner.Visible = true;

            DisableWindow();

            if (zipChB.Checked)
                processes.Add(Task.Run(ZipProcess));

            if (hashChb.Checked)
                processes.Add(Task.Run(HashProcess));

            if (pngConverterButton.Checked)
                processes.Add(Task.Run(ConvertToPngProcess));

            try
            {
                await Task.WhenAll(processes);
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                progressSpinner.Spinning = false;
                progressSpinner.Visible = false;

                zipChB.Checked = false;
                hashChb.Checked = false;
                pngConverterButton.Checked = false;

                EnableWindow();
            }

        }

       private bool checkIfAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private int startProcessByName(string filename)
        {
            if (!File.Exists(filename))
            {
                MetroFramework.MetroMessageBox.Show(this, $"Can't find {filename}", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -11;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = filename;
            startInfo.Arguments = $"\"{filePathLabel.Text}\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();
            process.WaitForExit();

            var code = process.ExitCode;
            if (code == -3)
            {
                startInfo.Verb = "runas";

                process.Start();
                process.WaitForExit();
                code = process.ExitCode;
                
            }
            return code;
        }

        private void ZipProcess()
        {
            var code = startProcessByName(PROCESS_ZIP_PATH);

            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Can't find {filePathLabel.Text} ", "Zip operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Archive: {Path.GetDirectoryName(filePathLabel.Text)}\\{Path.GetFileNameWithoutExtension(filePathLabel.Text)}.zip", "File's zipped succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Error!", "Zip operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       

        private void HashProcess()
        {
            var code = startProcessByName(PROCESS_HASHING_PATH);
            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Can't find {filePathLabel.Text}", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Hash file: {Path.GetDirectoryName(filePathLabel.Text)}\\{Path.GetFileNameWithoutExtension(filePathLabel.Text)}_hash_sha256", "Hash's saved succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Error!", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        private void ConvertToPngProcess()
        {
         
            var code = startProcessByName(PROCESS_PNG_CONVERTING_PATH);
            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Can't find {filePathLabel.Text}", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -5)
            {
                MetroFramework.MetroMessageBox.Show(this, $"{filePathLabel.Text} already has PNG format", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -6)
            {
                MetroFramework.MetroMessageBox.Show(this, $"{filePathLabel.Text} is not graphical", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"PNG file: {Path.GetDirectoryName(filePathLabel.Text)}\\{Path.GetFileNameWithoutExtension(filePathLabel.Text)}.png", "Image's converted succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Error!", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void hashChb_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void pngChb_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void zipChB_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void DisableWindow()
        {
            chooseFileBtn.Enabled = false;
            doActionButton.Enabled = false;
            zipChB.Enabled = false;
            hashChb.Enabled = false;
            pngConverterButton.Enabled = false;
        }

        private void EnableWindow()
        {
            chooseFileBtn.Enabled = true;
            doActionButton.Enabled = true;
            zipChB.Enabled = true;
            hashChb.Enabled = true;
            if (isGraphical)
                pngConverterButton.Enabled = true;
        }

        private void btnPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
