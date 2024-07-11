using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private const int mapSize = 4;
        private Label[,] labelsMap;
        private static Random random = new Random();
        private int score = 0;
        RulesForm rulesForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
            ShowScore();
        }
        private void ShowScore()
        {
            scoreLabel.Text = score.ToString(); 
        }
        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }
        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelsMap[indexRow, indexColumn].Text = "2";
                }
                break;
            }
        }
        private Label CreateLabel(int indexRaw, int indexColumn)
        {
            var label = new Label();
             
            label.BackColor = SystemColors.ActiveCaption;
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + indexColumn * 76;
            int y = 90 + indexRaw * 76;
            label.Location = new Point(x, y);
            return label;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i_row = 0; i_row < mapSize; i_row++)
                {
                    for (int j_column = mapSize - 1; j_column >= 0; j_column--)
                    {
                        if (labelsMap[i_row, j_column].Text != string.Empty)
                        {
                            for (int k_column = j_column - 1; k_column >= 0; k_column--)
                            {
                                if (labelsMap[i_row, k_column].Text != string.Empty)
                                {
                                    if (labelsMap[i_row, j_column].Text == labelsMap[i_row, k_column].Text)
                                    {
                                        var number = int.Parse(labelsMap[i_row, k_column].Text);
                                        score = score + (number * 2);
                                        labelsMap[i_row, j_column].Text = (number * 2).ToString();
                                        labelsMap[i_row, k_column].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }

                    }
                }

                for (int i_row = 0; i_row < mapSize; i_row++)
                {
                    for (int j_column = mapSize - 1; j_column >= 0; j_column--)
                    {
                        if (labelsMap[i_row, j_column].Text == string.Empty)
                        {
                            for (int k_column = j_column - 1; k_column >= 0; k_column--)
                            {
                                if (labelsMap[i_row, k_column].Text != string.Empty)
                                {
                                    labelsMap[i_row, j_column].Text = labelsMap[i_row, k_column].Text;
                                    labelsMap[i_row, k_column].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i_row = 0; i_row < mapSize; i_row++)
                {
                    for (int j_column = 0; j_column < mapSize; j_column++)
                    {
                        if (labelsMap[i_row, j_column].Text != string.Empty)
                        {
                            for (int k_column = j_column + 1; k_column < mapSize; k_column++)
                            {
                                if (labelsMap[i_row, k_column].Text != string.Empty)
                                {
                                    if (labelsMap[i_row, j_column].Text == labelsMap[i_row, k_column].Text)
                                    {
                                        var number = int.Parse(labelsMap[i_row, k_column].Text);
                                        score = score + (number * 2);
                                        labelsMap[i_row, j_column].Text = (number * 2).ToString();
                                        labelsMap[i_row, k_column].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i_rowIndex = 0; i_rowIndex < mapSize; i_rowIndex++)
                {
                    for (int j_columnIndex = 0; j_columnIndex < mapSize; j_columnIndex++)
                    {
                        if (labelsMap[i_rowIndex, j_columnIndex].Text == string.Empty)
                        {
                            for (int k_columnIndex = j_columnIndex + 1; k_columnIndex < mapSize; k_columnIndex++)
                            {
                                if (labelsMap[i_rowIndex, k_columnIndex].Text != string.Empty)
                                {
                                    labelsMap[i_rowIndex, j_columnIndex].Text = labelsMap[i_rowIndex, k_columnIndex].Text;
                                    labelsMap[i_rowIndex, k_columnIndex].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int j_column = 0; j_column < mapSize; j_column++)
                {
                    for (int i_row = 0; i_row < mapSize; i_row++)
                    {
                        if (labelsMap[i_row, j_column].Text != string.Empty)
                        {
                            for (int k_row = i_row + 1; k_row < mapSize; k_row++)
                            {
                                if (labelsMap[k_row, j_column].Text != string.Empty)
                                {
                                    if (labelsMap[i_row, j_column].Text == labelsMap[k_row, j_column].Text)
                                    {
                                        var number = int.Parse(labelsMap[i_row, j_column].Text);
                                        score = score + (number * 2);
                                        labelsMap[i_row, j_column].Text = (number * 2).ToString();
                                        labelsMap[k_row, j_column].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }


                for (int j_column = 0; j_column < mapSize; j_column++)
                {
                    for (int i_row = 0; i_row < mapSize; i_row++)
                    {
                        {
                            if (labelsMap[i_row, j_column].Text == string.Empty)
                            {
                                for (int k_row = i_row + 1; k_row < mapSize; k_row++)
                                {
                                    if (labelsMap[k_row, j_column].Text != string.Empty)
                                    {
                                        labelsMap[i_row, j_column].Text = labelsMap[k_row, j_column].Text;
                                        labelsMap[k_row, j_column].Text = string.Empty;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                


            }
            if (e.KeyCode == Keys.Down)
            {
                for (int j_column = 0; j_column < mapSize; j_column++)
                {
                    for (int i_row = mapSize - 1; i_row >- 0; i_row--)
                    {
                        if (labelsMap[i_row, j_column].Text != string.Empty)
                        {
                            for (int k_row = i_row - 1; k_row >= 0; k_row--)
                            {
                                if (labelsMap[k_row, j_column].Text != string.Empty)
                                {
                                    if (labelsMap[i_row, j_column].Text == labelsMap[k_row, j_column].Text)
                                    {
                                        var number = int.Parse(labelsMap[i_row, j_column].Text);
                                        score = score + (number * 2);
                                        labelsMap[i_row, j_column].Text = (number * 2).ToString();
                                        labelsMap[k_row, j_column].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }


                for (int j_column = 0; j_column < mapSize; j_column++)
                {
                    for (int i_row = mapSize - 1; i_row > -0; i_row--)
                    {
                        if (labelsMap[i_row, j_column].Text == string.Empty)
                        {
                            for (int k_row = i_row - 1; k_row >= 0; k_row--)
                            {
                                if (labelsMap[k_row, j_column].Text != string.Empty)
                                {
                                    labelsMap[i_row, j_column].Text = labelsMap[k_row, j_column].Text;
                                    labelsMap[k_row, j_column].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            GenerateNumber();
            ShowScore();
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
                rulesForm = new RulesForm(this);
                rulesForm.ShowDialog();
            }
        }

        private void играToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
