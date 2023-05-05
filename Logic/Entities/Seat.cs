using System.Security.Cryptography.X509Certificates;

namespace Logic.Entities;

public class Seat
{
    public int Row;
    public int Column;
    public Visitor? Visitor;
    public bool IsAvailable => Visitor == null;
}