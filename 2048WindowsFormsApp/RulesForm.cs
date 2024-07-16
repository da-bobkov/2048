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
    public partial class RulesForm : Form
    {

        private MainForm mainForm;
        private ResultsTableForm resultsTableForm;
        public RulesForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void перезапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void играToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
            mainForm.Focus();
        }

        private void таблицаРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                resultsTableForm.Show();
                resultsTableForm.Focus();
            }
            catch (Exception)
            {
                this.Hide();
                resultsTableForm = new ResultsTableForm(mainForm);
                resultsTableForm.ShowDialog();
            }
        }

        private void RulesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
