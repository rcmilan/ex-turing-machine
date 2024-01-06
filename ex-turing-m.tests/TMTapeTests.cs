namespace ex_turing_m.tests
{
    public class TMTapeTests
    {
        [Fact]
        public void Should_Create_Tape()
        {
            // Arrange
            // Act
            var t = TMTape.Initialize(['0', '1']);

            // Assert
            Assert.True(t.Read() == '0');
        }

        [Fact]
        public void Should_Move_And_Read_Tape()
        {
            // Arrange
            var t = TMTape.Initialize(['0', '1']);

            // Act
            // Assert
            var t1 = t.MoveRight();
            Assert.True(t1.Read() == '1');
            var t2 = t1.MoveLeft();
            Assert.True(t2.Read() == '0');

            Assert.True(t.Read() == '0');
        }

        [Fact]
        public void Should_Write_Tape()
        {
            // Arrange
            var t = TMTape.Initialize(['0', '1']);

            // Act
            var t1 = t.MoveRight().MoveLeft().Write('a');

            // Assert
            Assert.True(t1.Read() == 'a');
        }

        [Fact]
        public void Should_Read_Out_Of_Bounds()
        {
            // Arrange
            // Act
            var t = TMTape.Initialize(['0', '1']).MoveLeft();

            // Assert
            Assert.True(t.Read() == ' ');
        }
    }
}