using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class ImportForm : Form
    {
        public FormMain formMain = new FormMain();

        public ImportForm()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // API get the file path of Desktop
            string vDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //Open file action
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = vDesktopPath,
                Filter = "CSV File | *.csv",
                ValidateNames = true,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Open file"
            })
            {
                // comfirm if the openfiledialog is opened
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // NB: FileName include file path
                        string filePath = openFileDialog.FileName;

                        // Create FileStream to read the file stream 
                        //(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))

                        // Create StreamReader to read the file stream 
                        using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("ISO-8859-15")))
                        {
                            // Read CSV and Create DB
                            ReadCSVFile(sr);

                            // Create a void db

                            // Import CSV file


                        }
                        this.tbFilePath.Text = filePath;


                    }
                    catch
                    {
                        // if open file failed
                        MessageBox.Show("Fail to open the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void ReadCSVFile(StreamReader sr)
        {
            // count max number of column
            int line_max_count = 0;

            List<List<String>> T = new List<List<String>>();

            // Read file content and stock in Memory of a 2D table: T
            while (!sr.EndOfStream)
            {
                // Each line is a list of array splited by ';'
                List<String> line = new List<String>(sr.ReadLine().Split(';'));

                // Stock each line in T
                T.Add(line);

                if (line_max_count < line.Count)
                {
                    line_max_count = line.Count;
                }
            }

            // Set Header of ListView1
            for (int i = 0; i < line_max_count; i++)
            {
                // int width = listView1.Width / line_max_count - 1;
                int width = -2; // -2 means the default column size
                this.listView1.Columns.Add(T[0][i], width, HorizontalAlignment.Left);

            }

            this.listView1.BeginUpdate();

            // Add each line item in the listView
            for (int i = 1; i < T.Count; i++)
            {
                List<String> line = T[i];
                ListViewItem item = new ListViewItem();
                for (int j = 0; j < line.Count; j++)
                {
                    if (j == 0)
                    {
                        item.Text = line[j];

                    }
                    else
                    {
                        item.SubItems.Add(line[j]);
                    }
                }
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }

        private void btnModeAdd_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModeNew_Click(object sender, EventArgs e)
        {
            string filePath = tbFilePath.Text;

            using(StreamReader sr = new StreamReader(filePath))
            {
                LoadCSVFile(sr);
            }
        }

        private void LoadCSVFile(StreamReader sr)
        {
            // count max number of column
            int line_max_count = 0;

            List<List<String>> T = new List<List<String>>();

            while (!sr.EndOfStream)
            {
                List<String> line = new List<String>(sr.ReadLine().Split(';'));
                T.Add(line);
                if (line_max_count < line.Count)
                {
                    line_max_count = line.Count;
                }
            }

            InsertDB(T);
        }

        private void InsertDB(List<List<String>> T)
        {
            for (int i = 1; i < T.Count; i++)
            {
                List<String> line = T[i];

                // Create an instance of Class Articles
                string description = line[0];
                string refArticle = line[1];
                string marque = line[2];
                string famile = line[3];
                string sousFamile = line[4];
                string prixHT = line[5];

                Articles artcle = new Articles(description, refArticle, marque, famile, sousFamile, prixHT);

                ArticlesDAO ad = new ArticlesDAO();
                ad.connectionDB(artcle);

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
