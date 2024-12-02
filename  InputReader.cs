namespace Analisador_Lexico.Core;

public class InputReader {
    private readonly string _input;
    private int _position;

    public int Line { get; private set; }
    public int Column { get; private set; }
    public char Current => _position < _input.Length ? _input[_position] : '\0';

    public InputReader(string input) {
        _input = input;
        _position = 0;
        Line = 1;
        Column = 1;
    }

    public void Advance() {
        if (_position < _input.Length) {
            if (_input[_position] == '\n') {
                Line++;
                Column = 1;
            }
            else {
                Column++;
            }

            _position++;
        }
    }
}
