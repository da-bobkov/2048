using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace _2048WindowsFormsApp
{
    public partial class ResultsTableForm : Form
    {
        private MainForm mainForm;
        private RulesForm rulesForm;
        public List<User> Users { get; set; }   

        public ResultsTableForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            Users = UserResultsStorage.GetAll();
            foreach (User user in Users)
            {
                resultsGridView.Rows.Add(user.Name, user.FinalScore);
            }
        }

        private void играToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
            mainForm.Focus();
        }

        private void перезапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                rulesForm.Show();
                rulesForm.Focus();
            }
            catch (Exception)
            {
                this.Hide();
                rulesForm = new RulesForm(mainForm);
                rulesForm.ShowDialog();
            }
        }

        private void renewResultsButton_Click(object sender, EventArgs e)
        {
            resultsGridView.Rows.Clear();
            Users = UserResultsStorage.GetAll();
            foreach (User user in Users)
            {
                resultsGridView.Rows.Add(user.Name, user.FinalScore);
            }
        }
    }
}
