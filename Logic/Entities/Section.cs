using Logic.Exceptions;

namespace Logic.Entities;

public class Section
{
    private Random _random = new Random();
    public List<Seat> Seats = new List<Seat>();
    public int TotalRows;
    public int TotalColumns;
    public bool IsOpen { get; set; }
    public static int MaxRows = 3;
    public static int MaxColumns = 10;
    public static int MinRows = 1;
    public static int MinColumns = 3;

    public Section()
    {
        for (int i = 0; i < _random.Next(MinRows, MaxRows + 1); i++)
        {
            for (int j = 0; j < _random.Next(MinColumns, MaxColumns + 1); j++)
            {
                Seat seat = new Seat(i, j);
                Seats.Add(seat);
            }
        }
    }

    /// <summary>
    /// Places a group on the front row
    /// </summary>
    /// <param name="group">A group full of children with 1 adult</param>
    /// <exception cref="FrontRowIsNotAvailableException">Will be thrown if for whatever reason the frontrow is full</exception>
    public void PlaceGroupOnFrontRow(Group group)
    {
        var visitors = group.Visitors.ToList();

        var frontRow = Seats.Where(s => s.Row == 1).OrderBy(s => s.Column);
        if (!frontRow.Any(s => s.IsAvailable))
        {
            throw new FrontRowIsNotAvailableException("Front row is not available");
        }

        foreach (Seat seat in frontRow)
        {
            if (!visitors.Any()) break;

            seat.Visitor = visitors.First();
            visitors.Remove(seat.Visitor);
        }
    }
}