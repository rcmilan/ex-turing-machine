using System.Collections;

namespace ex_turing_m
{
    public readonly record struct TMTape : IEnumerable<char>
    {
        private const char EMPTY = ' ';

        private readonly char[] tape;
        private readonly int headPosition;

        private TMTape(char[] tape, int headPosition)
        {
            this.tape = tape;
            this.headPosition = headPosition;
        }

        public static TMTape Initialize(char[] initialContent) => new(initialContent, 0);

        public readonly char Read() => headPosition < 0 || headPosition >= tape.Length ? EMPTY : tape[headPosition];

        public readonly TMTape Write(char symbol)
        {
            char[] newTape = (char[])tape.Clone();
            newTape[headPosition] = symbol;
            return new TMTape(newTape, headPosition);
        }

        public readonly TMTape MoveLeft(int n = 1)
        {
            int newHeadPosition = headPosition - n;
            if (newHeadPosition < 0)
            {
                char[] newTape = new char[tape.Length + Math.Abs(newHeadPosition)];
                Array.Fill(newTape, EMPTY, 0, Math.Abs(newHeadPosition));
                Array.Copy(tape, 0, newTape, Math.Abs(newHeadPosition), tape.Length);
                return new TMTape(newTape, 0);
            }

            return new TMTape(tape, newHeadPosition);
        }

        public readonly TMTape MoveRight(int n = 1)
        {
            int newHeadPosition = headPosition + n;
            if (newHeadPosition >= tape.Length)
            {
                char[] newTape = new char[tape.Length + n];
                Array.Copy(tape, 0, newTape, 0, tape.Length);
                Array.Fill(newTape, EMPTY, tape.Length, n);
                return new TMTape(newTape, headPosition);
            }

            return new TMTape(tape, newHeadPosition);
        }

        public override readonly string ToString()
        {
            var tapeString = string.Join(' ', tape);
            return $"{tapeString}\n{new string(' ', headPosition * 2)}^";
        }

        public readonly IEnumerator<char> GetEnumerator() => ((IEnumerable<char>)tape).GetEnumerator();

        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
