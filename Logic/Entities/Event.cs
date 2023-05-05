namespace Logic.Entities;

public class Event
{
    public List<Section> Sections;
    public List<Visitor> UnplacedVisitors;
    public List<Group> UnplacedGroups;

    public Event(List<Section> sections, List<Visitor> unplacedVisitors, List<Group> unplacedGroups)
    {
        Sections = sections;
        UnplacedVisitors = unplacedVisitors;
        UnplacedGroups = unplacedGroups;
    }
}