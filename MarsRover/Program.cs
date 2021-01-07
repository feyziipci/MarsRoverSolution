using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string errorİnputMessage = "Wrong input, please check your inputs";
            const string errorFileMessage = "Wrong file input, please check your file";
            const string errorContinueMessage = "Program continue with default values for your explanation:";

            List<string> lines = new List<string>();
            List<string> initialPositions = new List<string>();
            List<string> directions = new List<string>();
            List<RoboticRover> roboticRovers = new List<RoboticRover>();
            string fieldParams = string.Empty;

            try
            {
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;

                filePath = Path.Combine(filePath, "Input.txt");

                if (File.Exists(filePath))
                {
                    lines = File.ReadAllLines(filePath).ToList();
                }
                else
                {
                    Console.WriteLine(errorFileMessage);
                }

                fieldParams = lines[0];

                for (int i = 1; i < lines.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        initialPositions.Add(lines[i]);
                    }
                    else
                    {
                        directions.Add(lines[i]);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine(errorContinueMessage);

                fieldParams = "5 5";
                initialPositions.AddRange(new string[] {"1 2 N", "3 3 E"});
                directions.AddRange(new string[] { "LMLMLMLMM", "MMRMMRMRRM" });
            }

            if(initialPositions.Count == directions.Count)
            {
                Field mars = new Field(Convert.ToInt32(fieldParams.Split(' ')[0]), Convert.ToInt32(fieldParams.Split(' ')[1]));

                for (int i = 0; i < initialPositions.Count; i++)
                {
                    string direction = directions[i];
                    var initialValues = initialPositions[i].Split(' ');

                    RoboticRover robot = new RoboticRover(Convert.ToInt32((initialValues[0])), (Convert.ToInt32(initialValues[1])),
                        (Direction)Enum.Parse(typeof(Direction), initialValues[2].ToString()), direction);

                    roboticRovers.Add(robot);
                }

                mars.RoverList = roboticRovers;
                string searchResult = mars.SearchArea();
                Console.Write(searchResult);
            }
            else
            {
                Console.WriteLine(errorİnputMessage);
            }

            Console.ReadLine();
        }
    }
}
