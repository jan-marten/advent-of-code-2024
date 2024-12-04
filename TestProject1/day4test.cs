using advent_of_code_2024.day04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class day4test
    {
        [Fact]
        public void Test_SampleData_Contains18Xmas()
        {
            var sampleData = 
                "MMMSXXMASM\n" +
                "MSAMXMSMSA\n" +
                "AMXSXMAAMM\n" +
                "MSAMASMSMX\n" +
                "XMASAMXAMM\n" +
                "XXAMMXXAMA\n" +
                "SMSMSASXSS\n" +
                "SAXAMASAAA\n" +
                "MAMMMXMMMM\n" +
                "MXMXAXMASX";

  
            var day4 = new day04();
            day4.ReadInput(sampleData);
            day4.ParseInput();

            Assert.Equal(18, day4.ResultCounter);
        }

        [Fact]
        public void Test_RotateMatrix_Simple()
        {
            var input = 
                "ABCD\n" +
                "EFGH\n" +
                "IJKL\n" +
                "MNOP\n" +
                "QRST";
            var day4 = new day04();
            var result = day4.RotateMatrix(input);

            Assert.Equal("AEIMQ\nBFJNR\nCGKOS\nDHLPT", result);
        }

        [Fact]
        public void Test_RotateMatrix45_Simple()
        {
            var input =
                "ABC\n" +
                "DEF\n" +
                "GHI";

            var day4 = new day04();
            var result = day4.RotateMatrix45(input);
            var expectedResult =
                "C\n" +
                "BF\n" +
                "AEI\n" +
                "DH\n" +
                "G";

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Test_InputData()
        {
            var day4 = new day04();
            day4.ReadInputFromFile();
            day4.ParseInput();
            Console.WriteLine("Result=" + day4.ResultCounter);
        }
    }
}
