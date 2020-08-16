using System;

namespace GameLibrary
{
    public class DirectionHelper
    {
        public static FiringDirection GetRandDirection()
        {
            Random rand = new Random();
            int directionNumber = rand.Next(3);
            return (FiringDirection)directionNumber;
        }

        public static FiringDirection GetOppositeDirection(FiringDirection dir)
        {
            switch (dir)
            {
                case FiringDirection.North:
                    return FiringDirection.South;
                case FiringDirection.South:
                    return FiringDirection.North;
                case FiringDirection.East:
                    return FiringDirection.West;
                default:
                    return FiringDirection.East;
            }
        }

        public static FiringDirection GetRandPerpendicularDirection(FiringDirection dir)
        {
            Random rand = new Random();
            int r = rand.Next(1);
            if (dir == FiringDirection.East || dir == FiringDirection.West)
            {
                if (r == 0)
                {
                    return FiringDirection.North;
                }
                else
                {
                    return FiringDirection.South;
                }
            }
            else
            {
                if (r == 0)
                {
                    return FiringDirection.West;
                }
                else
                {
                    return FiringDirection.East;
                }
            }
        }

        public static void GetNextFiringCoordinate(FiringDirection dir, 
            int rowNumber, int columnNumber, out int newRowNumber, out int newColumnNumber)
        {
            switch (dir)
            {
                case FiringDirection.North:
                    newRowNumber = rowNumber - 1;
                    newColumnNumber = columnNumber;
                    break;
                case FiringDirection.South:
                    newRowNumber = rowNumber + 1;
                    newColumnNumber = columnNumber;
                    break;
                case FiringDirection.East:
                    newRowNumber = rowNumber;
                    newColumnNumber = columnNumber + 1;
                    break;
                default:
                    newRowNumber = rowNumber;
                    newColumnNumber = columnNumber - 1;
                    break;
            }

        }
    }
}
