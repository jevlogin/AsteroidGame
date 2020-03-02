using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    public static class Level
    {
        public static int LevelGame { get; set; } = 1;

        public static string NameLevelGame { get => $"Level {LevelGame}"; }

        public static int Asteroids_Count { get; set; } = 5 * LevelGame;
    }
}
