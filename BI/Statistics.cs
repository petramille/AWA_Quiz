using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunication;

namespace BI
{
    public class Statistics
    {
        DatabaseHandling myDatabase = new DatabaseHandling();



        //Discuss what to display for statistics
        public void CalculateUserStatistics(string eMailAddress, string quizTitle)
        {
            List<string> statistics = myDatabase.ReadFromSQL(eMailAddress, quizTitle, "sp_GetStatistics");
            List<int> result = new List<int>();
            for (int i = 0; i < statistics.Count; i++)
            {
                if (i % 4 == 0)
                {
                    for (int j = 0; j < statistics.Count; j++)
                    {

                        int tempStat;
                        Int32.TryParse(statistics[i], out tempStat);
                        result.Add(tempStat);
                    }
                }
            }

            int correctPercentage = result.Sum() / result.Count;


        }

        public void CalculateQuizStatistics(string quizTitle)
        {
            List<string> statistics = myDatabase.ReadFromSQL(quizTitle, "");
        }

        public void VisualizeStatistics()
        {
            //Array Visualizer????
        }
    }
}
