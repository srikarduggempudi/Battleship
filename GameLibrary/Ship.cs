using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameLibrary
{
    public enum Direction
    {
        Vertical = 0,
        Horizontal = 1
    }
    public class Ship
    {
        public Direction direction;
        private string shipImageName;
        public string Name { get; set; }
        public int Length { get; set; }
        public int Hits { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Image[] ShipImage { get; set; }

        public Direction Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                if (shipImageName != null)
                {
                    ShipImage = ImageUtil.ChopShipImage(shipImageName, direction, 30);
                }
            }
        }
        public string ShipImageName
        {
            get
            {
                return shipImageName;
            }
            set
            {
                shipImageName = value;
                ShipImage = ImageUtil.ChopShipImage(shipImageName, Direction, 30);
            }
        }
        public bool Sunken
        {
            get
            {
                if (Length > 0 && Hits == Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Ship()
        {

        }

        public static Ship[] GetAllShips()
        {
            Ship[] ships = new Ship[5];
            ships[0] = new Ship()
            {
                Name = "Aircraft Carrier",
                ShipImageName = "Images.Ship1.png",
                Direction = Direction.Horizontal,
                Length = 5,
                Hits = 0,
            };
            ships[1] = new Ship()
            {
                Name = "Submarine",
                ShipImageName = "Images.Ship2.png",
                Direction = Direction.Horizontal,
                Length = 4,
                Hits = 0
            };
            ships[2] = new Ship()
            {
                Name = "Waterjet",
                ShipImageName = "Images.Ship3.png",
                Direction = Direction.Horizontal,
                Length = 3,
                Hits = 0
            };
            ships[3] = new Ship()
            {
                Name = "Gunship",
                ShipImageName = "Images.Ship4.png",
                Direction = Direction.Horizontal,
                Length = 3,
                Hits = 0
            };
            ships[4] = new Ship()
            {
                Name = "Lifeboat",
                ShipImageName = "Images.Ship5.png",
                Direction = Direction.Horizontal,
                Length = 2,
                Hits = 0
            };

            return ships;
        }
    }
}
