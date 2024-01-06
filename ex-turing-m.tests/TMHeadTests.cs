namespace ex_turing_m.tests
{
    public class TMHeadTests
    {
        [Fact]
        public void Initialize_Head()
        {
            // Arrange
            var tape = TMTape.Initialize(['0', '1']);

            // Act
            var head = new TMHead(tape, [], "");

            var result = head.Execute();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Initialize_Head_With_Instructions()
        {
            // Initial content of the tape representing binary numbers: 110 + 101
            char[] initialContent = "110 101".ToCharArray();

            // Define TMInstructions for binary addition
            var instructions = new TMInstruction[]
            {
                // Move to the right until a space is found (separator between the two binary numbers)
                new('1', '1', 1, "q0"),
                new('0', '0', 1, "q0"),
                new(' ', ' ', 1, "q1"),

                // Move to the left and perform binary addition
                new('1', ' ', -1, "q2"),
                new('0', '1', -1, "q2"),
                new(' ', '1', 0, "HaltState") // Halt when the addition is complete
            };

            // Initialize TMHead with the initial tape content, instructions, and initial state
            TMTape tape = TMTape.Initialize(initialContent);
            TMHead head = new(tape, instructions, "q0");

            // Execute the Turing machine
            List<TMTape> results = [.. head.Execute()];

            Assert.NotNull(results);
        }
    }
}
