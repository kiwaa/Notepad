using System;
// you can also use other imports, for example:
using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

namespace Notepad.Codility.Battleships
{
    class Solution
    {
        public string solution(int N, string S, string T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var ships = ParseShips(S);
            var hits = ParseHits(T);

            int sunk = 0, hitNotSunk = 0;
            foreach (var ship in ships)
            {
                var hitCount = ship.ProcessHits(hits);
                if (hitCount > 0)
                {
                    // hit or sunk
                    if (hitCount == ship.Size)
                        sunk++;
                    else
                        hitNotSunk++;
                    //                   Console.WriteLine(hitCount);
                }
            }

            return sunk + "," + hitNotSunk;
        }

        // 1b 2c, 2d 4d
        private List<Ship> ParseShips(string str)
        {
            var list = new List<Ship>();
            var tokens = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                list.Add(Ship.Parse(token));
            }
            return list;
        }

        // 2b 2d 3d 4d 4a
        private List<Coordinate> ParseHits(string str)
        {
            var list = new List<Coordinate>();
            var tokens = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
                list.Add(Coordinate.Parse(token));
            return list;
        }

        public class Ship
        {
            // 1b 2c
            public static Ship Parse(string str)
            {
                var tokens = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new Ship(Coordinate.Parse(tokens[0]), Coordinate.Parse(tokens[1]));
            }

            public Coordinate TopLeft { get; }
            public Coordinate BottomRight { get; }

            public int Size
            {
                get
                {
                    return (BottomRight.X - TopLeft.X + 1) * (BottomRight.Y - TopLeft.Y + 1);
                }
            }

            public Ship(Coordinate topLeft, Coordinate bottomRight)
            {
                TopLeft = topLeft;
                BottomRight = bottomRight;
            }

            public int ProcessHits(IEnumerable<Coordinate> hits)
            {
                var counter = 0;
                foreach (var hit in hits)
                {
                    if (TestHit(hit))
                        counter++;
                }
                return counter;
            }

            private bool TestHit(Coordinate c)
            {
                return c.X >= TopLeft.X && c.Y >= TopLeft.Y &&
                       BottomRight.X >= c.X && BottomRight.Y >= c.Y;
            }
        }

        public class Coordinate
        {
            // 4a
            public static Coordinate Parse(string str)
            {
                var len = str.Length;
                var y = int.Parse(str.Substring(0, len - 1)) - 1;
                var x = str[len - 1] - 'A';
                return new Coordinate(x, y);
            }

            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}