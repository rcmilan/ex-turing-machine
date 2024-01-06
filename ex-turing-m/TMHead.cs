namespace ex_turing_m
{
    public class TMHead(TMTape tape, TMInstruction[] instructions, string initialState)
    {
        public IEnumerable<TMTape> Execute()
        {
            while (true)
            {
                char currentSymbol = tape.Read();
                TMInstruction instruction = FindInstruction(currentSymbol, initialState);

                if (instruction == TMInstruction.HaltInstruction)
                {
                    Console.WriteLine("No instruction found for current state and symbol.");
                    yield return tape;
                    break;
                }

                // Execute instruction
                tape = tape.Write(instruction.WriteSymbol);
                tape = (instruction.Move < 0) ? tape.MoveLeft(Math.Abs(instruction.Move)) : tape;
                tape = (instruction.Move > 0) ? tape.MoveRight(Math.Abs(instruction.Move)) : tape;
                initialState = instruction.NextState;

                // Print tape
                Console.WriteLine($"State: {initialState}, Symbol: {currentSymbol}");
                yield return PrintTape();
            }
        }

        private TMInstruction FindInstruction(char symbol, string state) => Array.Find(instructions, i => i.Symbol == symbol && i.NextState == state);

        public TMTape PrintTape()
        {
            Console.WriteLine("Tape:");
            Console.WriteLine(tape.ToString());
            Console.WriteLine();

            return tape;
        }
    }
}
