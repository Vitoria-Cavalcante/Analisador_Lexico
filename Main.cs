using Analisador_Lexico;
using Analisador_Lexico.Core;

namespace Analisador_Lexico;

class Program {
    static void Main(string[] args) {
        string sourceCode = @"
programa exemplo
    variavel x;
    x := 10;
fimPrograma";

        var lexer = new Lexer(sourceCode);
        var tokens = lexer.Analyze();

        Console.WriteLine("Tokens encontrados:");
        foreach (var token in tokens) {
            Console.WriteLine(token);
        }

        lexer.PrintErrors();
    }
}
