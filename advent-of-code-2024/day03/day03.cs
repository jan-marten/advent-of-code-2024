using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent_of_code_2024.day03
{
    public class day03
    {
        private List<string> _multiplications = new();
        public List<string> Multiplications => _multiplications;

        private List<Tuple<int, int>> _multiplicationsList { get; set; } = new();
        public List<Tuple<int, int>> MultiplicationsList => _multiplicationsList;

        public void RunTestdata()
        {
            var input = File.ReadAllText("day03/input.txt");
            Run(input);
            ParseToDictionary();
            var result = Calculate();
            Console.WriteLine($"Result: {result}");
        }

        public void RunTestdata2()
        {
            var input = File.ReadAllText("day03/input.txt");
            Run2(input);
            ParseToDictionary2();
            var result = Calculate();
            Console.WriteLine($"Result: {result}");
        }

        public void Run(string input)
        {

            var strRegex = @"mul\([0-9]*,[0-9]*\)";
            var regex = new Regex(strRegex);
            _multiplications = regex.Matches(input).Select(x => x.Value).ToList();
        }

        public void Run2(string input)
        {
            var strRegex = @"mul\([0-9]*,[0-9]*\)|don't\(\)|do\(\)";
            var regex = new Regex(strRegex);
            _multiplications = regex.Matches(input).Select(x => x.Value).ToList();
        }


        public void ParseToDictionary()
        {
            foreach (var item in _multiplications)
            {
                var values = item.Replace("mul(", "").Replace(")", "").Split(",");
                var key = int.Parse(values[0]);
                var value = int.Parse(values[1]);
                _multiplicationsList.Add(new Tuple<int, int>(key, value));
            }
        }

        public void ParseToDictionary2()
        {
            bool doMultiplication = true;

            foreach (var item in _multiplications)
            {
                if (item.StartsWith("don't"))
                {
                    doMultiplication = false;
                }
                else if (item.StartsWith("do"))
                {
                    doMultiplication = true;
                }
                else if (item.StartsWith("mul") && doMultiplication)
                {
                    var values = item.Replace("mul(", "").Replace(")", "").Split(",");
                    var key = int.Parse(values[0]);
                    var value = int.Parse(values[1]);
                    _multiplicationsList.Add(new Tuple<int, int>(key, value));
                }
            }
        }

        public int Calculate()
        {
            var result = 0;
            foreach (var item in _multiplicationsList)
            {
                result += item.Item1 * item.Item2;
            }
            return result;
        }
    }
}
