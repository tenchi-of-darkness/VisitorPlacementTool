namespace Logic.Entities;

public class Visitor
{
    public DateTime BirthDayDate;
    public bool IsChild => BirthDayDate < DateTime.Now.AddYears(-12);
    public DateTime RegisterDateTime = DateTime.Now;
    Visitor _individual= new Visitor();
}
