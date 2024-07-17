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
            var allUsers = GetAll();
            int maxResult = 0;
            if (allUsers.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (User user in allUsers)
                {
                    if(user.Score > maxResult)
                    {
                        maxResult = user.Score;    
                    }
                }
            }
            return maxResult;
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
