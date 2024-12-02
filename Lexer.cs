using Analisador_Lexico;

namespace Analisador_Lexico.Core;

public class Lexer {
    private readonly InputReader _reader;
    private readonly List<Token> _tokens = new();
    private readonly ErrorHandler _errorHandler;

    public Lexer(string sourceCode) {
        _reader = new InputReader(sourceCode);
        _errorHandler = new ErrorHandler();
    }

    public List<Token> Analyze() {
        while (_reader.Current != '\0') {
            SkipWhitespace();

            if (char.IsLetter(_reader.Current)) {
                ProcessIdentifier();
            }
            else if (char.IsDigit(_reader.Current)) {
                ProcessNumber();
            }
            else {
                ProcessSymbol();
            }
        }

        return _tokens;
    }

    private void SkipWhitespace() {
        while (char.IsWhiteSpace(_reader.Current)) {
            _reader.Advance();
        }
    }

    private void ProcessIdentifier() {
        var startLine = _reader.Line;
        var startColumn = _reader.Column;
        var lexeme = "";

        while (char.IsLetterOrDigit(_reader.Current)) {
            lexeme += _reader.Current;
            _reader.Advance();
        }

        _tokens.Add(new Token("IDENTIFIER", lexeme, startLine, startColumn));
    }

    private void ProcessNumber() {
        var startLine = _reader.Line;
        var startColumn = _reader.Column;
        var lexeme = "";

        while (char.IsDigit(_reader.Current)) {
            lexeme += _reader.Current;
            _reader.Advance();
        }

        _tokens.Add(new Token("NUMBER", lexeme, startLine, startColumn));
    }

    private void ProcessSymbol() {
        var startLine = _reader.Line;
        var startColumn = _reader.Column;
        var lexeme = _reader.Current.ToString();

        // Exemplo de tratamento de símbolos
        if (lexeme == "+" || lexeme == "-" || lexeme == "=") {
            _tokens.Add(new Token("SYMBOL", lexeme, startLine, startColumn));
        }
        else {
            _errorHandler.AddError(startLine, startColumn, $"Símbolo inesperado: {lexeme}");
        }

        _reader.Advance();
    }

    public void PrintErrors() => _errorHandler.PrintErrors();
}
