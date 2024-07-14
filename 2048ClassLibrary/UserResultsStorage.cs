using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UserResultsStorage
    {

        public static string PathToResults = "ResultsTable";
        public static string PathToBestScore = "BestScore";

        public static List<User> GetAll()
        {
            if (!FileProvider.IsFileExists(PathToResults))
            {
                return new List<User>();    
            }
            else
            {
                string results = FileProvider.GetValue(PathToResults);
                return Converter.ConvertFromJson<List<User>>(results);

            }
        }
        public static int GetBestScore()
        {
            if (!FileProvider.IsFileExists(PathToBestScore))
            {
                return 0;
            }
            else
            {
                string bestScoreToString = FileProvider.GetValue(PathToBestScore);
                int bestScoreToInt = Converter.ConvertFromJson<int>(bestScoreToString);
                return bestScoreToInt;
            }
        }

        public static string CompareBestScore(int score)
        {
            int currentBestScore = GetBestScore();
            if (score > currentBestScore)
            {
                string scoreToJson = Converter.ConvertToJson(score);
                FileProvider.SetValue(PathToBestScore, scoreToJson);
                return score.ToString();
            }
            else
            {
                return currentBestScore.ToString();
            }
        }
        
        public static void SetScore(User user)
        {
            List<User> users = GetAll();
            users.Add(user);
            string usersToJson = Converter.ConvertToJson(users);
            FileProvider.SetValue(PathToResults, usersToJson);
        }

    }
}
