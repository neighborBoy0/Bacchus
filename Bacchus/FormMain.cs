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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm();
            importForm.Show();
        }

        private void ReadCSV(StreamReader sr)
        {
            // record each line
            string strLine = "";

            // record each field
            string[] aryLine; 

            bool IsFirstLine = true;

            // count the number of column
            int columnCount = 0;

            // read file content by line
            while((strLine = sr.ReadLine()) != null)
            {
                System.Console.WriteLine("read cdv");
                // split field by ";" in a line
                aryLine = strLine.Split(';');

                if(IsFirstLine == true)
                {
                    IsFirstLine = false;
                    columnCount = aryLine.Length;
                    

                    //ListViewItem item = new ListViewItem(aryLine[0],0);
                    for(int i = 0; i < columnCount ; i++)
                    {
                        ColumnHeader ch = new ColumnHeader();
                        ch.Text = aryLine[i];
                        ch.Width = 120;
                        ch.TextAlign = HorizontalAlignment.Left;

                        //DataColumn dc = new DataColumn(aryLine[i]);
                        listView1.Columns.Add(ch);

                        //listView1.Columns.Add(dc);
                       // item.Checked = true;
                       // item.SubItems.Add(aryLine[i]);

                        //string dbName = "test";
                        //DBSQLite.CreateDB(dbName);
                        //DataColumn dc = new DataColumn(aryLine[i]);
                        //DataTable dt 
                        //dt.Columns.Add(dc);

                    }
                    //ListView listView2 = new ListView();
                    //listView1.Columns.Add(item);
                }
                else
                {
                    columnCount = aryLine.Length;
                    ListViewItem item = new ListViewItem(aryLine[0],0);
                    for (int i = 0; i < columnCount; i++)
                    {
                        item.SubItems.Add(aryLine[i]);
                    }
                    listView1.Items.Add(item);
                }

            }
        }

        

        public void SetListView(List<List<String>> T)
        {

        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        
    }
}
