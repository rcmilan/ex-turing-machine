namespace ex_turing_m;

public record struct TMInstruction(char Symbol, char WriteSymbol, int Move, string NextState)
{
    public static readonly TMInstruction HaltInstruction = new(default, default, default, default);
};