using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ClassLibrary;

namespace _2048WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private int mapSize;
        private Label[,] labelsMap;
        private static Random random = new Random();
        private int score = 0;
        RulesForm rulesForm;
        ResultsTableForm resultsTableForm;
        User user;
        private bool isResultAdded = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            user = new User(loginForm.userNameTextBox.Text);
            mapSize = Convert.ToInt32(loginForm.chooseSizeBox.Text);
            switch (mapSize)
            {
                case 4: this.Size = new System.Drawing.Size(332, 434);
                    totalScoreBox.Location = new Point(145, 12); 
                    bestScoreBox.Location = new Point(228, 12); 
                    break;
                case 6: this.Size = new System.Drawing.Size(486, 585);
                    totalScoreBox.Location = new Point(287, 12);
                    bestScoreBox.Location = new Point(381, 12);
                    break; 
                case 8: this.Size = new System.Drawing.Size(638, 740);
                    totalScoreBox.Location = new Point(441, 12);
                    bestScoreBox.Location = new Point(533, 12);
                    break;
            }
            InitMap();
            GenerateNumber();
            ChangeColor();
            bestScoreLabel.Text = UserResultsStorage.GetBestScore().ToString();
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
            bool notAllFull = false;
            foreach (var label in labelsMap)
            {
                if (label.Text == string.Empty)
                {
                    notAllFull = true;
                    break;
                }
            }
            if (notAllFull)
            {
                List<Tuple<int, int>> tupleList = new List<Tuple<int, int>>();
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            tupleList.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
                string[] numbersArray = { "2", "2", "2", "4" };
                var randomIndex = random.Next(numbersArray.Length);
                var randomNumberLabel = random.Next(tupleList.Count);
                var choosenTuple = tupleList[randomNumberLabel];
                labelsMap[choosenTuple.Item1, choosenTuple.Item2].Text = numbersArray[randomIndex];
            }
        }
        private Label CreateLabel(int indexRaw, int indexColumn)
        {
            var label = new Label();
             
            label.BackColor = Color.White;
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

                for (int i_row = 0; i_row < mapSize; i_row++)
                {
                    for (int j_column = 0; j_column < mapSize; j_column++)
                    {
                        if (labelsMap[i_row, j_column].Text == string.Empty)
                        {
                            for (int k_column = j_column + 1; k_column < mapSize; k_column++)
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
            ChangeColor();
            CheckIfEmpty();
            ShowScore();
        }
        public void CheckIfEmpty()
        {
            bool allempty = true;
            foreach (Label label in labelsMap)
            {
                if (label.Text == string.Empty)
                {
                    label.BackColor = Color.White;
                    allempty = false;
                    break;
                }
            }
            if (allempty)
            {
                CheckIfGameOver();
            }
        }

        private void CheckIfGameOver()
        {
            bool gameover = true;
            int mapSize = 4;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i < mapSize - 1 && labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
                    {
                        gameover = false;
                        break;
                    }
                    if (j < mapSize - 1 && labelsMap[i, j].Text == labelsMap[i, j + 1].Text)
                    {
                        gameover = false;
                        break;
                    }
                }
            }
            if (gameover)
            {
                if (isResultAdded == false)
                {
                    user.FinalScore = score;
                    UserResultsStorage.SetScore(user);
                    isResultAdded = true;
                }
                MessageBox.Show("Игра окончена!");
            }
        }

        public void ChangeColor()
        {
            foreach (var label in labelsMap)
            {
                if (label.Text == string.Empty)
                {
                    label.BackColor = Color.White;
                }
                else
                {
                    switch (Convert.ToInt32(label.Text))
                    {
                        case 2: label.BackColor = Color.Linen; break;
                        case 4: label.BackColor = Color.Bisque; break;
                        case 8: label.BackColor = Color.LightSalmon; break;
                        case 16: label.BackColor = Color.DarkSalmon; break;
                        case 32: label.BackColor = Color.Salmon; break;
                        case 64: label.BackColor = Color.Coral; break;
                        case 128: label.BackColor = Color.Tomato; break;
                        case 256: label.BackColor = Color.LightCoral; break;
                        case 512: label.BackColor = Color.Firebrick; break;
                        case 1024: label.BackColor = Color.Red; break;
                        case 2048: label.BackColor = Color.DarkRed; break;
                    }
                }
            }
        }

        private void перезапускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bestScoreLabel.Text = UserResultsStorage.CompareBestScore(user.FinalScore);
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bestScoreLabel.Text = UserResultsStorage.CompareBestScore(user.FinalScore);
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
                resultsTableForm = new ResultsTableForm(this);
                resultsTableForm.ShowDialog();
            }
        }

        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.FinalScore = score;
            bestScoreLabel.Text = UserResultsStorage.CompareBestScore(user.FinalScore);
            isResultAdded = false;
            score = 0;
            user.FinalScore = 0;
            foreach (Label label in labelsMap)
            {
                label.Text = string.Empty;
            }
            GenerateNumber();
            ChangeColor();
            bestScoreLabel.Text = UserResultsStorage.GetBestScore().ToString();
            ShowScore();
        }
    }
}
