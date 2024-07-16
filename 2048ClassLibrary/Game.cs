//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles;
//using System.Drawing;

//namespace ClassLibrary
//{
//    internal class Game
//    {
//        private int mapSize;
//        private Label[,] labelsMap;
//        private static Random random = new Random();
//        private int score = 0;
//        private bool isResultAdded = false;

//        Label label = new Label();

//        private void ShowScore()
//        {
//            scoreLabel.Text = score.ToString();
//        }
//        private void InitMap()
//        {
//            labelsMap = new Label[mapSize, mapSize];
//            for (int i = 0; i < mapSize; i++)
//            {
//                for (int j = 0; j < mapSize; j++)
//                {
//                    var newLabel = CreateLabel(i, j);
//                    Controls.Add(newLabel);
//                    labelsMap[i, j] = newLabel;
//                }
//            }
//        }
//        private Label CreateLabel(int indexRaw, int indexColumn)
//        {
//            var label = new Label();

//            label.BackColor = Color.White;
//            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
//            label.Size = new Size(70, 70);
//            label.TextAlign = ContentAlignment.MiddleCenter;
//            int x = 10 + indexColumn * 76;
//            int y = 90 + indexRaw * 76;
//            label.Location = new Point(x, y);
//            return label;
//        }
//        private void GenerateNumber()
//        {
//            bool notAllFull = false;
//            foreach (var label in labelsMap)
//            {
//                if (label.Text == string.Empty)
//                {
//                    notAllFull = true;
//                    break;
//                }
//            }
//            if (notAllFull)
//            {
//                List<Tuple<int, int>> tupleList = new List<Tuple<int, int>>();
//                for (int i = 0; i < mapSize; i++)
//                {
//                    for (int j = 0; j < mapSize; j++)
//                    {
//                        if (labelsMap[i, j].Text == string.Empty)
//                        {
//                            tupleList.Add(new Tuple<int, int>(i, j));
//                        }
//                    }
//                }
//                string[] numbersArray = { "2", "2", "2", "4" };
//                var randomIndex = random.Next(numbersArray.Length);
//                var randomNumberLabel = random.Next(tupleList.Count);
//                var choosenTuple = tupleList[randomNumberLabel];
//                labelsMap[choosenTuple.Item1, choosenTuple.Item2].Text = numbersArray[randomIndex];
//            }
//        }
//        public void CheckIfEmpty()
//        {
//            bool allempty = true;
//            foreach (Label label in labelsMap)
//            {
//                if (label.Text == string.Empty)
//                {
//                    label.BackColor = Color.White;
//                    allempty = false;
//                    break;
//                }
//            }
//            if (allempty)
//            {
//                CheckIfGameOver();
//            }
//        }
//        private void CheckIfGameOver()
//        {
//            bool gameover = true;
//            for (int i = 0; i < mapSize; i++)
//            {
//                for (int j = 0; j < mapSize; j++)
//                {
//                    if (i < mapSize - 1 && labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
//                    {
//                        gameover = false;
//                        break;
//                    }
//                    if (j < mapSize - 1 && labelsMap[i, j].Text == labelsMap[i, j + 1].Text)
//                    {
//                        gameover = false;
//                        break;
//                    }
//                }
//            }
//            if (gameover)
//            {
//                if (isResultAdded == false)
//                {
//                    user.FinalScore = score;
//                    UserResultsStorage.SetScore(user);
//                    isResultAdded = true;
//                }
//                MessageBox.Show("Игра окончена!");
//            }
//        }
//        public void ChangeColor()
//        {
//            foreach (var label in labelsMap)
//            {
//                if (label.Text == string.Empty)
//                {
//                    label.BackColor = Color.White;
//                }
//                else
//                {
//                    switch (Convert.ToInt32(label.Text))
//                    {
//                        case 2: label.BackColor = Color.Linen; break;
//                        case 4: label.BackColor = Color.Bisque; break;
//                        case 8: label.BackColor = Color.LightSalmon; break;
//                        case 16: label.BackColor = Color.DarkSalmon; break;
//                        case 32: label.BackColor = Color.Salmon; break;
//                        case 64: label.BackColor = Color.Coral; break;
//                        case 128: label.BackColor = Color.Tomato; break;
//                        case 256: label.BackColor = Color.LightCoral; break;
//                        case 512: label.BackColor = Color.Firebrick; break;
//                        case 1024: label.BackColor = Color.Red; break;
//                        case 2048: label.BackColor = Color.DarkRed; break;
//                    }
//                }
//            }
//        }



//    }
//}
