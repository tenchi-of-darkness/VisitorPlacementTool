namespace Logic.Entities;

public class Group
{
    public readonly List<Visitor> Visitors;

    public Group(List<Visitor> visitors)
    {
        Visitors = visitors;
    }

    public int TotalChildren => Visitors.Count(v => v.IsChild);
    public int TotalAdults => Visitors.Count(v=>!v.IsChild);
    public bool HasAloneChildren => TotalChildren > 0 && TotalAdults == 0;
}