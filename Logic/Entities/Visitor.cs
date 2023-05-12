namespace Logic.Entities;

public class Visitor
{
    private static readonly Random _random = new Random();
    public DateTime BirthDayDate { get; }
    public bool IsChild => BirthDayDate < DateTime.Now.AddYears(-12);
    public DateTime RegisterDateTime = DateTime.Now.AddDays(_random.Next(-7, 1));

    public Visitor(bool isChild)
    {
        if (isChild)
        {
            BirthDayDate = DateTime.Now.AddDays(-_random.Next(365*12));
        }
        else
        {
            BirthDayDate = DateTime.Now.AddYears(-12).AddDays(-_random.Next(365*30));
        }
    }
}
