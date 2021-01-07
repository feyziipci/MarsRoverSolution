using System;

namespace MarsRover
{
    public class RoboticRover
    {
        public const string OutOfAreaException = "Out of area!";

        public Direction Direction { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public string Path { get; set; }

        public RoboticRover(int xPosition, int yPosition, Direction direction, string path)
        {
            Direction = direction;
            XPosition = xPosition;
            YPosition = yPosition;
            Path = path;
        }

        public string Operate(int[] fieldBoundaries)
        {
            var movePath = Path.ToCharArray();
            bool isOut = false;

            foreach (var item in movePath)
            {
                if (isOut)
                {
                    return OutOfAreaException;
                }

                if (item == 'M'){

                    Move(fieldBoundaries,ref isOut);
                }
                else
                {
                    Rotate(item);
                } 
            }

            return string.Format("{0} {1} {2}", XPosition, YPosition, Direction);
        }

        public void Move(int[] fieldBoundaries, ref bool isOut)
        {
            if((int)Direction % 2 == 0)
            {
                XPosition -= (int)Direction - 1;
            }
            else
            {
                YPosition += (int)Direction - 2;
            }
            
            if(XPosition > fieldBoundaries[0] || YPosition > fieldBoundaries[1])
            {
                isOut = true;
            }
        }

        public void Rotate(char way)
        {
           if(way == 'R')
            {
                Direction = (Direction)(((int)Direction + 5) % 4);
            }
            else
            {
                Direction = (Direction)(((int)Direction + 3) % 4);
            }
        }
    }
}
