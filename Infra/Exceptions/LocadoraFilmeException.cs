namespace WebExercicios.Infra.Exceptions;
public class LocadoraFilmeException : Exception
{
    public LocadoraFilmeException() { }

    public LocadoraFilmeException(string message)
        : base(message) { }

    public LocadoraFilmeException(string message, Exception inner)
        : base(message, inner) { }
}
