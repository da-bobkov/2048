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
        private bool isResultAdded = false;
        RulesForm rulesForm;
        ResultsTableForm resultsTableForm;
        User user;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            string choosenSize = loginForm.chooseSizeBox.Text[0].ToString();
            user = new User(loginForm.userNameTextBox.Text, loginForm.chooseSizeBox.Text);
            mapSize = Convert.ToInt32(choosenSize);
            this.ClientSize = new System.Drawing.Size(15 + 76 * mapSize, 95 + 76 * mapSize);
            this.totalScorePanel.Location = new System.Drawing.Point((15 + 76 * mapSize) - 168, 12);
            this.bestScorePanel.Location = new System.Drawing.Point((15 + 76 * mapSize) - 86, 12);
            InitMap();
            GenerateNumber();
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
        private Label CreateLabel(int indexRaw, int indexColumn)
        {
            var label = new Label();

            label.BackColor = Color.FromArgb(203, 193, 181);
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 11 + indexColumn * 76;
            int y = 90 + indexRaw * 76;
            label.Location = new Point(x, y);
            label.TextChanged += Label_TextChanged;
            return label;
        }
        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch (label.Text)
            {
                case "": label.BackColor = Color.FromArgb(203, 193, 181); break;
                case "2": label.BackColor = Color.FromArgb(238, 227, 217); break;
                case "4": label.BackColor = Color.FromArgb(236, 223, 198); break;
                case "8": label.BackColor = Color.FromArgb(242, 175, 123); break;
                case "16": label.BackColor = Color.FromArgb(236, 140, 85); break;
                case "32": label.BackColor = Color.FromArgb(246, 124, 94); break;
                case "64": label.BackColor = Color.FromArgb(233, 87, 55); break;
                case "128": label.BackColor = Color.FromArgb(244, 215, 107); break;
                case "256": label.BackColor = Color.FromArgb(241, 208, 75); break;
                case "512": label.BackColor = Color.FromArgb(228, 192, 42); break;
                case "1024": label.BackColor = Color.FromArgb(227, 186, 20); break;
                case "2048": label.BackColor = Color.FromArgb(236, 196, 0); break;
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
        public void CheckEmpty()
        {
            bool allempty = true;
            foreach (Label label in labelsMap)
            {
                if (label.Text == string.Empty)
                {
                    label.BackColor = Color.FromArgb(203, 193, 181); 
                    allempty = false;
                    break;
                }
            }
            if (allempty)
            {
                GameOver();
            }
        }
        private void GameOver()
        {
            bool gameover = true;
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
                AddResult();
                MessageBox.Show("Вы проиграли! Игра окончена.");
            }
        }

        private bool Win()
        {
            foreach (Label label in labelsMap)
            {
                if (label.Text == "2048")
                {
                    return true;
                }
            }
            return false;
        }
        public void AddResult()
        {
            if (isResultAdded == false)
            {
                user.Score = score;
                UserResultsStorage.SetScore(user);
                isResultAdded = true;
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                return;
            }
            if (Win())
            {
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                MoveRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }
            if (e.KeyCode == Keys.Up)
            {
                MoveUp();
            }
            if (e.KeyCode == Keys.Down)
            {
                MoveDown();
            }
            if (score > Convert.ToInt32(bestScoreLabel.Text))
            {
                bestScoreLabel.Text = score.ToString();
            }
            ShowScore();
            if (Win())
            {
                AddResult();
                MessageBox.Show("Победа!");
                return;
            }
            GenerateNumber();
            CheckEmpty();
        }

        private void MoveDown()
        {
            for (int j_column = 0; j_column < mapSize; j_column++)
            {
                for (int i_row = mapSize - 1; i_row > -0; i_row--)
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

        private void MoveUp()
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

        private void MoveLeft()
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

        private void MoveRight()
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
            user.Score = score;
            isResultAdded = false;
            score = 0;
            user.Score = 0;
            foreach (Label label in labelsMap)
            {
                label.Text = string.Empty;
            }
            GenerateNumber();
            bestScoreLabel.Text = UserResultsStorage.GetBestScore().ToString();
            ShowScore();
        }

    }
}
