namespace Logic.Exceptions;

public class FrontRowIsNotAvailableException: Exception
{
    public FrontRowIsNotAvailableException(string message)
        :base(message)
    {
    }
}