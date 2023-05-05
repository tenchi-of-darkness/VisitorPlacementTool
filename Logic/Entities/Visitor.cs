namespace Logic.Entities;

public class Visitor
{
    public DateTime BirthDayDate;
    public bool IsChild => BirthDayDate < DateTime.Now.AddYears(-12);
}