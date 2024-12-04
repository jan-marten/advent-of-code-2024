using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent_of_code_2024.day04
{
    public class day04
    {
        public int ResultCounter { get; set; }
        private string _input;

        public void ReadInputFromFile()
        {
            _input = File.ReadAllText("day04/input.txt");
        }

        public void ReadInput(string input)
        {
            _input = input;
        }

        public void ParseInput()
        {
            // We need 2 seperate regexes to find both XMAS and SAMX (XMASAMX = 2 matches)
            var strRegex1 = @"XMAS";
            var strRegex2 = @"SAMX";
            RegexOptions options = RegexOptions.Multiline;
            var regex1 = new Regex(strRegex1, options);
            var regex2 = new Regex(strRegex2, options);

            var input0 = _input;
            var input45 = RotateMatrix45(input0);
            var input90 = RotateMatrix(input0);
            var mirrorInput = MirrorInput(input90);
            var input135 = RotateMatrix45(mirrorInput);

            ResultCounter = regex1.Matches(input0).Count;
            ResultCounter += regex1.Matches(input45).Count;
            ResultCounter += regex1.Matches(input90).Count;
            ResultCounter += regex1.Matches(input135).Count;

            ResultCounter += regex2.Matches(input0).Count;
            ResultCounter += regex2.Matches(input45).Count;
            ResultCounter += regex2.Matches(input90).Count;
            ResultCounter += regex2.Matches(input135).Count;

            //Console.WriteLine("0------------------------");
            //Console.WriteLine(input0);
            //Console.WriteLine("1------------------------");
            //Console.WriteLine(input45);
            //Console.WriteLine("2------------------------");
            //Console.WriteLine(input90);
            //Console.WriteLine("3------------------------");
            //Console.WriteLine(input135);

        }

        private string MirrorInput(string input90)
        {
            var lines = input90.Split("\n");
            var result = string.Empty;
            foreach (var line in lines)
            {
                result += new string(line.Reverse().ToArray()) + "\n";
            }
            return result;
        }

        public string RotateMatrix(string input)
        {
            var lines = input.Split("\n");
            var rows = lines.Length;
            var cols = lines[0].Length;

            var result = string.Empty;

            for (int c = 0; c < cols; c++)
            {
                if (result.Length > 0)
                {
                    result += "\n";
                }
                for (int r = 0; r < rows; r++)
                {
                    if (lines[r].Length > c)
                    {
                        result += lines[r][c];
                    }
                }

            }
            return result;
        }

        public string RotateMatrix45(string input)
        {
            // ABC
            // DEF
            // GHI
            // Rotate 45 degreest to:
            // C
            // BF
            // AEI
            // DH
            // G
            var lines = input.Split("\n");
            string result = "";

            for (int c = lines[0].Length - 1; c >= 0; c--)
            {
                for (int r = 0; r < lines.Length; r++)
                {
                    int colPos = c + r;

                    if (colPos < lines[r].Length)
                    {
                        result += lines[r][colPos];
                    }
                    else
                    {
                        // Reached EOL, continue with next line
                        result += "\n";
                        break;
                    }
                }
            }

            result += "\n";

            for (int r = 1; r < lines.Length; r++)
            {
                for (int c = 0; c < lines[r].Length; c++)
                {
                    //int colPos = c + r;
                    int rowPos = r + c;

                    if (rowPos < lines.Length && lines[rowPos].Length > 0)
                    {
                        result += lines[rowPos][c];
                    }
                    else
                    {
                        // Reached EOL, continue with next line
                        result += "\n";
                        break;
                    }
                }
            }
            return result.Substring(0, result.LastIndexOf("\n"));
        }

        
    }
}
