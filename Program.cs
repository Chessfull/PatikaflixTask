using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PatikaflixTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ▼ Creating list of series ▼
            List<Series> seriesList = new List<Series>();

            // ▼ Greeting ▼
            Console.WriteLine("Welcome to Patikaflix!\n**************************");

            // ▼ Taking properties of series from user ▼
            bool repeatCheck = true; // -> Repeat key
            while (repeatCheck)
            {
                Console.Write("Series Name:");
                string seriesName = Console.ReadLine();

                bool yearCheck = false; // -> Year format key
                int produceYear = 0;
                while (!yearCheck)
                {
                    Console.Write("Producing Year:");
                    yearCheck = int.TryParse(Console.ReadLine(), out produceYear);
                }

                Console.Write("Series Type:");
                string seriesType = Console.ReadLine();

                yearCheck = false; // -> Year format key
                int publishYear = 0;
                while (!yearCheck)
                {
                    Console.Write("Producing Year:");
                    yearCheck = int.TryParse(Console.ReadLine(), out publishYear);
                }

                Console.Write("Director:");
                string director = Console.ReadLine();

                Console.Write("First Platform:");
                string firstPlatform = Console.ReadLine();

                // ▼ Creating instance of series with user properties and adding to Series List ▼
                Series series = new Series { Name = seriesName, PublishYear = new DateTime(publishYear, 1, 1), Type = seriesType, ProduceYear = new DateTime(produceYear, 1, 1), Director = director, FirstPlatform = firstPlatform };
                seriesList.Add(series);

                // ▼ Asking repeat part ▼
                Console.Write("Do you want add one more series? (Y/N) :");
                string repeatAnswer = Console.ReadLine().ToLower();
                if (repeatAnswer == "y")
                {
                    repeatCheck = true;
                }
                else
                {
                    repeatCheck = false;
                }
            }

            // ▼ Firstly I created filtered list with 'Comedy' ▼
            List<Series> comedyFilterList = seriesList.Where(I => I.Type == "Comedy").ToList();

            // ▼ Secondly I created ComedySeries list that I create a class with 3 prop like task wants ▼
            List<ComedySeries> comedySeriesList = new List<ComedySeries>();

            // ▼ Thirdly for solution of adding Series class to ComedySeries class I created a method below and with 'ForEach' Linq method I added Comedy filtered series to ComedySeries ▼
            comedyFilterList.ForEach(I =>comedySeriesList.Add(ConvertingFromSeries(I)));

            // ▼ Printing props of ComedySeries ▼
            foreach (ComedySeries comedySeries in comedySeriesList)
            {
                Console.WriteLine($"Name:{comedySeries.Name}\nType:{comedySeries.Type}\nDirector:{comedySeries.Director}");
                Console.WriteLine("******************************");
            }
        }

        // ▼ Defined method for creating Comedy Series from Series ▼
        // Note: If ComedySeries is a base class of Series I dont need to do that for converting process.
        public static ComedySeries ConvertingFromSeries(Series series)
            {
                return new ComedySeries
                {
                    Name = series.Name,
                    Type = series.Type,
                    Director = series.Director
                };
            }
        }
    }
