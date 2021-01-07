using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Field
    {
        public int[] FieldBoundaries;

        public Field(int xBoundary, int yBoundary)
        {
            FieldBoundaries = new int[] { xBoundary, yBoundary };
        }

        public List<RoboticRover> RoverList { get; set; }

        public string SearchArea()
        {
            StringBuilder searchResult = new StringBuilder();

            foreach(var rover in RoverList)
            {
                searchResult.Append(rover.Operate(FieldBoundaries));
                searchResult.AppendLine();
            }

            return searchResult.ToString().TrimEnd();
        }
    }
}
