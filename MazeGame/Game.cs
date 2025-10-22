using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MazeGame
{
    public class Game
    {
        private World myWorld;
        private Player player;

        public void Start()
        {
            string[,] grid =
            {
                    { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                    { "W", " ", "W", " ", "W", " ", "W", "W", " ", "W" },
                    { "W", " ", " ", " ", "W", " ", " ", " ", " ", "W" },
                    { "W", " ", "W", " ", " ", " ", " ", "W", " ", "W" },
                    { "W", " ", "W", "W", "W", "W", " ", "W", " ", "W" },
                    { "W", " ", " ", " ", " ", "W", " ", " ", " ", "W" },
                    { "W", "W ", "W ", "W", " ", "W", "W", "W", "X", "W" },
                    { "W", " ", " ", "W", " ", " ", " ", "W", " ", "W" },
                    { "W", "W", " ", "W", "W", "W", " ", "W", " ", "W" },
                    { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
                };

            myWorld = new World(grid);
            player = new Player(1, 1);
            GameLoop();
        }

        private void DrawFrame()
        {
            Clear();
            myWorld.Draw();
            player.Draw();
        }

        private void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (myWorld.IsWalkable(player.X, player.Y - 1))
                    {
                        player.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (myWorld.IsWalkable(player.X, player.Y + 1))
                    {
                        player.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (myWorld.IsWalkable(player.X - 1, player.Y))
                    {
                        player.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (myWorld.IsWalkable(player.X + 1, player.Y))
                    {
                        player.X += 1;
                    }
                    break;
            }
        }

        private void intro()
        {
            WriteLine("welcome to maze!");
            WriteLine("\nInstructions");
            WriteLine("> use arrow keys to move");
            Write("> reach the goal, it looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ForegroundColor = ConsoleColor.White;
            WriteLine("> press any key to start");
            ReadKey();
        }

        private void outro()
        {
            Clear();
            WriteLine("you did it!");
            WriteLine("thanks 4 playning");
            WriteLine("press any key to exit");
            ReadKey();
        }

        private void GameLoop()
        {
            intro();
            var path = DepthFirstSearch(player.X, player.Y, "X");
            if (path != null)
            {
                AnimatePath(path);
            }
            outro();
        }

        private List<(int, int)> DepthFirstSearch(int startX, int startY, string target)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            Dictionary<(int, int), (int, int)> parentMap = new Dictionary<(int, int), (int, int)>();

            stack.Push((startX, startY));
            visited.Add((startX, startY));

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();

                if (myWorld.getThing(x, y) == target)
                {
                    return ConstructPath((x, y), parentMap);
                }

                foreach (var (nx, ny) in GetNeighbors(x, y))
                {
                    if (!visited.Contains((nx, ny)) && myWorld.IsWalkable(nx, ny))
                    {
                        stack.Push((nx, ny));
                        visited.Add((nx, ny));
                        parentMap[(nx, ny)] = (x, y);
                    }
                }
            }

            return null; // No path found
        }

        private List<(int, int)> ConstructPath((int, int) end, Dictionary<(int, int), (int, int)> parentMap)
        {
            List<(int, int)> path = new List<(int, int)>();
            var current = end;

            while (parentMap.ContainsKey(current))
            {
                path.Add(current);
                current = parentMap[current];
            }

            path.Reverse();
            return path;
        }

        private IEnumerable<(int, int)> GetNeighbors(int x, int y)
        {
            return new List<(int, int)>
                {
                    (x, y - 1), // Up
                    (x, y + 1), // Down
                    (x - 1, y), // Left
                    (x + 1, y)  // Right
                };
        }

        private void AnimatePath(List<(int, int)> path)
        {
            foreach (var (x, y) in path)
            {
                player.X = x;
                player.Y = y;
                DrawFrame();
                System.Threading.Thread.Sleep(200); // Adjust the speed of animation
            }
        }
    }
}



