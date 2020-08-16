using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameLibrary
{
    public class GameController
    {
        public Battlefield UserBoard { get; set; }
        public Battlefield ComputerBoard { get; set; }
        private Random rand;
        public bool GameOver { get; set; }
        public bool EasyMode { get; set; }

        public GameController()
        {
            rand = new Random();
        }

        public void FireOpponentMissile()
        {
            if (EasyMode == true)
            {
                FireOpponentMissileEasy();
            }
            else
            {
                FireOpponentMissileDifficult();
            }

            // check if the game is done
            if (UserBoard.AreAllShipsSunken())
            {
                GameOver = true;
                MessageBox.Show("Computer won the game!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ComputerBoard.AreAllShipsSunken())
            {
                GameOver = true;
                MessageBox.Show("You won the game!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FireOpponentMissileEasy()
        {
            // fire opponent missile
            bool done = false;
            while (done == false)
            {
                int rowNumber = rand.Next(Battlefield.FIELD_SIZE);
                int columnNumber = rand.Next(Battlefield.FIELD_SIZE);
                FireMissileStatus status = UserBoard.FireMissile(columnNumber, rowNumber);
                if (status == FireMissileStatus.Hit || status == FireMissileStatus.Miss)
                {
                    done = true;
                }
            }
        }

        int startingRow = 0;
        int startingColumn = 0;
        int curRow = 0;
        int curColumn = 0;
        int sunkenShips = 0;
        bool huntMode = false;
        bool dirSelected = false;
        int numDirectionChanges = 0;
        FiringDirection huntDir;

        private void FireOpponentMissileDifficult()
        {
            // fire opponent missile
            bool done = false;
            while (done == false)
            {
                // start firing randomly until we hit a ship
                if (huntMode == false)
                {
                    int rowNumber = rand.Next(Battlefield.FIELD_SIZE);
                    int columnNumber = rand.Next(Battlefield.FIELD_SIZE);
                    FireMissileStatus status = UserBoard.FireMissile(columnNumber, rowNumber);
                    if (status == FireMissileStatus.Hit || status == FireMissileStatus.Miss)
                    {
                        done = true;
                    }
                    // If this is the first hit, then remember the coordinates and start the algorithm
                    if (status == FireMissileStatus.Hit)
                    {
                        startingColumn = columnNumber;
                        startingRow = rowNumber;
                        curColumn = columnNumber;
                        curRow = rowNumber;
                        huntMode = true;
                        sunkenShips = UserBoard.GetSunkenShipCount();
                        dirSelected = false;
                        numDirectionChanges = 0;
                    }
                }
                else
                {
                    // Do some intelligent firing since we are already in hunt mode

                    if (dirSelected == false)
                    {
                        huntDir = DirectionHelper.GetRandDirection();
                        dirSelected = true;
                        numDirectionChanges++;
                    }
                    int tempRow = 0;
                    int tempColumn = 0;
                    DirectionHelper.GetNextFiringCoordinate(huntDir, curRow, curColumn, out tempRow, out tempColumn);
                    FireMissileStatus status = UserBoard.FireMissile(tempColumn, tempRow);
                    if (status == FireMissileStatus.Hit || status == FireMissileStatus.Miss)
                    {
                        done = true;
                        int curSunkenShips = UserBoard.GetSunkenShipCount();
                        if (sunkenShips != curSunkenShips)
                        {
                            // we sunk a battle ship, so we are done with this algorithm
                            // start over again with another random firing
                            huntMode = false;
                        }
                        else
                        {
                            if (status == FireMissileStatus.Hit)
                            {
                                curRow = tempRow;
                                curColumn = tempColumn;
                            }
                            else if (status == FireMissileStatus.Miss)
                            {
                                // we exhausted all the hits in one direction, now pick a different direction
                                if (numDirectionChanges == 1 || numDirectionChanges == 3)
                                {
                                    // we are moving in one direction, we still need to go to opposite dir
                                    huntDir = DirectionHelper.GetOppositeDirection(huntDir);
                                }
                                else
                                {
                                    // we exhausted opposite directions, so go perpendicular
                                    huntDir = DirectionHelper.GetRandPerpendicularDirection(huntDir);
                                }
                                numDirectionChanges++;
                                curRow = startingRow;
                                curColumn = startingColumn;
                            }
                        }
                    }
                    else if (status == FireMissileStatus.AlreadyFired || status == FireMissileStatus.Illegal)
                    {
                        // we exhausted all the hits in one direction, now pick a different direction
                        if (numDirectionChanges == 1 || numDirectionChanges == 3)
                        {
                            // we are moving in one direction, we still need to go to opposite dir
                            huntDir = DirectionHelper.GetOppositeDirection(huntDir);
                        }
                        else
                        {
                            // we exhausted opposite directions, so go perpendicular
                            huntDir = DirectionHelper.GetRandPerpendicularDirection(huntDir);
                        }
                        numDirectionChanges++;
                        curRow = startingRow;
                        curColumn = startingColumn;

                        // some ship placements might make this algorithm get stuck in an infinite loop
                        // let us break it manually and start over again
                        if (numDirectionChanges > 6)
                        {
                            Console.WriteLine("Coming out of a bind ... :-)");
                            huntMode = false;
                        }
                    }
                }
            }
        }
    }
}
