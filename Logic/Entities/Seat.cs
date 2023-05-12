using System.Security.Cryptography.X509Certificates;

namespace Logic.Entities;

public class Seat
{
    public readonly int Row;
    public readonly int Column;
    public Visitor? Visitor;

    public Seat(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAvailable => Visitor == null;
    
}