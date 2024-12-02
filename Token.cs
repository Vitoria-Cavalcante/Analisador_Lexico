namespace LexerApp.Models;

public class Token {
    public string Type { get; }
    public string Lexeme { get; }
    public int Line { get; }
    public int Column { get; }

    public Token(string type, string lexeme, int line, int column) {
        Type = type;
        Lexeme = lexeme;
        Line = line;
        Column = column;
    }

    public override string ToString() =>
        $"Token(Type: {Type}, Lexeme: '{Lexeme}', Line: {Line}, Column: {Column})";
}
