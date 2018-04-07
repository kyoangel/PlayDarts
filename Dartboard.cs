using System;
using System.Collections.Generic;

namespace PlayDarts
{
    public class Dartboard
    {
        private List<String> _fixResult = new List<string>() { "X", "DB", "SB" };

        private Dictionary<Distance, String> _magniDistanceLookup = new Dictionary<Distance, string>()
        {
            {new Distance(0, 6.35), "DB"},
            {new Distance(6.35, 15.9), "SB"},
            {new Distance(15.9, 99), ""},
            {new Distance(99, 107), "T"},
            {new Distance(107, 162), ""},
            {new Distance(162, 170), "D"},
            {new Distance(170, Double.MaxValue), "X"},
        };

        private Dictionary<Angle, int> _scoreAngleLookup = new Dictionary<Angle, int>()
        {
            {new Angle(351, 9), 6},
            {new Angle(9, 27), 13},
            {new Angle(27, 45), 4},
            {new Angle(45, 63), 18},
            {new Angle(63, 81), 1},
            {new Angle(81, 99), 20},
            {new Angle(99, 117), 5},
            {new Angle(117, 135), 12},
            {new Angle(135, 153), 9},
            {new Angle(153, 171), 14},
            {new Angle(171, 189), 11},
            {new Angle(189, 207), 8},
            {new Angle(207, 225), 16},
            {new Angle(225, 243), 7},
            {new Angle(243, 261), 19},
            {new Angle(261, 279), 3},
            {new Angle(279, 297), 17},
            {new Angle(297, 315), 2},
            {new Angle(315, 333), 15},
            {new Angle(333, 351), 10},
        };

        public string GetScore(double x, double y)
        {
            var mangi = GetMagniByPosition(x, y);
            var score = _fixResult.Contains(mangi) ? "" : GetScoreByPosition(x, y);
            return mangi + score;
        }

        private double GetAngle(double x, double y)
        {
            var result = Math.Atan2(y, x) * 180.0 / Math.PI;
            return result > 0 ? result : 360 + result;
        }

        private double GetDistance(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        private string GetMagniByPosition(double x, double y)
        {
            var distance = GetDistance(x, y);
            foreach (KeyValuePair<Distance, string> entry in _magniDistanceLookup)
            {
                if (entry.Key.IsThisDistance(distance))
                {
                    return entry.Value;
                }
            }
            return "";
        }

        private string GetScoreByPosition(double x, double y)
        {
            var angle = GetAngle(x, y);
            foreach (KeyValuePair<Angle, int> entry in _scoreAngleLookup)
            {
                if (entry.Key.IsThisRange(angle))
                {
                    return Convert.ToString(entry.Value);
                }
            }
            return "";
        }

        internal class Angle
        {
            public double MaxAngle;
            public double MinAngle;

            public Angle(double min, double max)
            {
                MaxAngle = max;
                MinAngle = min;
            }

            public Boolean IsThisRange(double angle)
            {
                if (MinAngle < MaxAngle)
                {
                    return MinAngle < angle && MaxAngle > angle;
                }
                else
                {
                    return MinAngle < angle || (angle > 0 && angle < MaxAngle);
                }
            }
        }

        internal class Distance
        {
            public double MaxDistance;
            public double MinDistance;

            public Distance(double min, double max)
            {
                MaxDistance = max;
                MinDistance = min;
            }

            public Boolean IsThisDistance(double distance)
            {
                return MinDistance <= distance && MaxDistance >= distance;
            }
        }
    }
}