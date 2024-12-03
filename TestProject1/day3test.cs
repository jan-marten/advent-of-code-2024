using advent_of_code_2024.day03;

namespace TestProject1
{
    public class day3test
    {
        [Fact]
        public void Test_Sample_ShouldReturn4Multiplications()
        {
            // Arrange
            var input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            var uot = new day03();

            // Act
            uot.Run(input);
            var result = uot.Multiplications;

            // Assert
            Assert.Equal(4, result.Count);

        }

        // Parse test
        [Fact]
        public void Test_Sample_ShouldReturnParsedResult()
        {
            // Arrange
            var input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            var uot = new day03();

            // Act
            uot.Run(input);
            uot.ParseToDictionary();
            var firstItem = uot.MultiplicationsList.First();

            // Assert
            Assert.Equal(2, firstItem.Item1);
            Assert.Equal(4, firstItem.Item2);
        }

        [Fact]
        public void Test_Sample_ShouldReturn161AsResult()
        {
            // Arrange
            var input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            var uot = new day03();

            // Act
            uot.Run(input);
            uot.ParseToDictionary();
            var result = uot.Calculate();

            // Assert
            Assert.Equal(161, result);

        }

        [Fact]
        public void Test_Sample_ParseShouldContain2Records()
        {
            // Arrange
            var input = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            var uot = new day03();

            uot.Run2(input);
            uot.ParseToDictionary2();
            var result = uot.MultiplicationsList;

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public void Test_Sample_DoDont()
        {
            // Arrange
            var input = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            var uot = new day03();

            uot.Run2(input);
            uot.ParseToDictionary2();
            var result = uot.Calculate();

            Assert.Equal(48, result);

        }

    }
}
