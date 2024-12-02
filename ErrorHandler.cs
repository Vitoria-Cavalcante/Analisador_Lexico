namespace Analisador_Lexico.Core;

public class ErrorHandler {
    private readonly List<string> _errors = new();

    public void AddError(int line, int column, string message) {
        _errors.Add($"Erro na linha {line}, coluna {column}: {message}");
    }

    public void PrintErrors() {
        if (_errors.Count == 0) {
            Console.WriteLine("Nenhum erro encontrado.");
        }
        else {
            Console.WriteLine("Erros encontrados:");
            foreach (var error in _errors) {
                Console.WriteLine(error);
            }
        }
    }
}
