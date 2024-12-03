using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024.day02
{
    internal static class day02
    {
        public static void Run()
        {
            var input = File.ReadAllText("day02/input.txt").Split("\n").ToArray();

            //var input = new List<string>
            //{
            //    "7 6 4 2 1",
            //    "1 2 7 8 9",
            //    "9 7 6 2 1",
            //    "1 3 2 4 5",
            //    "8 6 4 4 1",
            //    "1 3 6 7 9",
            //};

            // each line = 1 report
            // 1 report contains 5 levels
            //
            var totalSafe = 0;
            foreach (var line in input.Where(x => x.Length > 5))
            {
                var report = new Report();
                report.Parse(line);
                var status = report.IsSafe(report.Levels);
                if (status == Report.ReportStatus.Safe || status == Report.ReportStatus.Safe_Dampened)
                {
                    totalSafe++;
                }

                Console.WriteLine(report);
            }

            Console.WriteLine($"Total safe reports: {totalSafe}");

        }

    }

    internal class Report
    {
        public List<int> Levels { get; set; } = new();
        public string RawData { get; set; } = string.Empty;
        private ReportStatus _isSafe { get; set; } = ReportStatus.Unknown;

        public void Parse(string input)
        {
            RawData = input;
            Levels = input.Split(" ").Where(x => x.Length > 0).Select(x => int.Parse(x)).ToList();
        }

        public ReportStatus IsSafe(List<int> levels)
        {
            // The levels are either all increasing or all decreasing.
            // Any two adjacent levels differ by at least one and at most three.

            if (_isSafe != ReportStatus.Unknown)
            {
                return _isSafe;
            }

            int incorrectIndex = -1;

            if (!IsOrderSafe(levels, out incorrectIndex))
            {
                _isSafe = ReportStatus.Unsafe_NotOrdered;
            }
            
            else if (!IsIncrementalSafe(levels, out incorrectIndex))
            {
                _isSafe = ReportStatus.Unsafe_NotIncremental;
            }
            else
            {
                _isSafe = ReportStatus.Safe;
            }

            if (_isSafe != ReportStatus.Unknown && incorrectIndex > -1)
            {
                // retry with dampener
                levels.RemoveAt(incorrectIndex);
                if (IsOrderSafe(levels, out incorrectIndex) && IsIncrementalSafe(levels, out incorrectIndex))
                {
                    _isSafe = ReportStatus.Safe_Dampened;
                }
            }

            return _isSafe;

        }

        private bool IsIncrementalSafe(List<int> levels, out int incorrectIndex)
        {
            incorrectIndex = -1;

            // test differences
            for (var i = 1; i < levels.Count; i++)
            {
                var diff = Math.Abs(Levels[i - 1] - Levels[i]);
                if (diff < 1 || diff > 3)
                {
                    incorrectIndex = i;
                    return false;
                }
            }
            return true;
        }

        private bool IsOrderSafe(List<int> levels, out int incorrectIndex)
        {
            incorrectIndex = -1;

            var isOrdered = IsOrdered(levels, out incorrectIndex);

            if (!isOrdered)
            {
                levels.Reverse();
                isOrdered = IsOrdered(levels, out incorrectIndex);
            }

            return isOrdered;
        }

        public static bool IsOrdered(List<int> list, out int incorrectIndex)
        {
            incorrectIndex = -1;
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i - 1] > list[i])
                {
                    incorrectIndex = i;
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{RawData} = {IsSafe(Levels)}";
        }

        public enum ReportStatus
        {
            Unknown,
            Safe,
            Safe_Dampened,
            Unsafe_NotOrdered,
            Unsafe_NotIncremental
        }
    }
}
