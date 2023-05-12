using Logic.Exceptions;

namespace Logic.Entities;

public class Section
{
    public List<Seat> Seats = new List<Seat>();
    public int TotalRows;
    public int TotalColumns;
    public bool IsOpen { get; set; }

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