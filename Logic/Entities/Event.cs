namespace Logic.Entities;

public class Event
{
    public List<Section> Sections;
    public List<Visitor> UnplacedVisitors;
    public List<Group> UnplacedGroups;
    public bool VisitorIsLate(Visitor visitor) => visitor.RegisterDateTime <= _eventDate;
    private readonly DateTime _eventDate = DateTime.Now;

    public Event(List<Section> sections, List<Visitor> unplacedVisitors, List<Group> unplacedGroups)
    {
        Sections = sections;
        UnplacedVisitors = unplacedVisitors;
        UnplacedGroups = unplacedGroups;
    }
    
    // public Section? BestSection(Group group, IEnumerable<Group> remainingGroups)
    // {
    //     var totalChildrenWithOneParent = remainingGroups.Sum(g => g.TotalChildren + 1);
    //     if (group.TotalChildren + 1 <= Sections.Max(s => s.TotalColumns))
    //     {
    //         return Sections.MaxBy(s => s.TotalColumns);
    //     }
    //
    //     return null;
    // }
}