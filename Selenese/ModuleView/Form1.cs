using OpenQA.Selenium;
using SeleneseOperation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Text;
using SeleneseOperation.Domain;
using SeleneseOperation.Operations;
using System.Diagnostics;

namespace ModuleView
{
    public partial class Form1 : Form
    {
        private List<Person> peopleImported;
        private IWebDriver _driver;
        private const string FileNotFound = "You must provide a file to load something to the system.";
        private const string FileError = "Some issues occurred during the loading of the data. Please check your file and try again.";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _driver = MainOperation.Initialize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lb_ExistingPeople.Items.Clear();
            if (peopleImported == null)
                peopleImported = new List<Person>();

            if (peopleImported.Count > 0)
            {
                List<Person> existingPeople = SearchOp.CheckExistance(_driver, peopleImported);

                if (existingPeople.Count > 0)
                {
                    DealWithExistingPeople(existingPeople);
                    return;
                }

                MessageBox.Show("There are no existing people matching with the people you provided. Nice!");
            }
            else
            {
                MessageBox.Show(FileNotFound);
            }
        }

        private void DealWithExistingPeople(List<Person> existingPeople)
        {
            MessageBox.Show("There are " + existingPeople.Count + " existing people. Check in the panel.");
            AddPeopleToList(existingPeople);
        }

        private void AddPeopleToList(List<Person> existingPeople)
        {
            foreach (var item in existingPeople)
            {
                lb_ExistingPeople.Items.Add(item.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string stringConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(stringConn);
            try
            {
                

                if (txt_Path.Text != string.Empty)
                {
                    OleDbCommand command = new OleDbCommand
                    {
                        CommandText = "SELECT Nome, Cargo, Status, CPF, Posicao " +
                        "FROM [Planilha1$]",
                        Connection = conn
                    };

                    DataSet people = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    adapter.Fill(people);
                    conn.Close();
                    peopleImported = ExcelOp.GetData(people);
                    if (peopleImported.Count > 0)
                    {
                        MessageBox.Show("There are " + peopleImported.Count + " rows available for creation in the scope.");

                    }
                    else
                    {
                        MessageBox.Show(FileError);
                    }
                }
                else
                {
                    
                    MessageBox.Show(FileNotFound);
                }
            }
            catch (Exception ex)
            {
                conn.Dispose();
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Test Only
        /// </summary>
        private List<Person> GenerateRandomPeople()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person()
            {
                Name = "Erik"
            });

            list.Add(new Person()
            {
                Name = "Ferreira da Silva"
            });

            list.Add(new Person()
            {
                Name = "Maria"
            });

            return list;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            if (opfd.ShowDialog() == DialogResult.OK)
                txt_Path.Text = opfd.FileName;
        }

        private void txt_Path_TextChanged(object sender, EventArgs e)
        {
            btn_ExcelData.Enabled = true;
        }

        private void btn_CreateUsers_Click(object sender, EventArgs e)
        {
            var tryInclude = CreationOp.CreateUsers(_driver, peopleImported);
            if (tryInclude)
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("There were some unexpected issues in this operation.");
            }
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            Process.Start("manual.pdf");
        }

        private void btn_JustEdit_Click(object sender, EventArgs e)
        {
            if (peopleImported.Count <= 0)
            {
                MessageBox.Show(FileNotFound);
                return;
            }

            var tryInclude = CreationOp.CompleteInfoGroup(_driver, peopleImported);
            if (tryInclude)
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("There were some unexpected issues in this operation.");
            }

        }
    }
}
