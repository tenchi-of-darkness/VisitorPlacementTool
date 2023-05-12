namespace Logic.Entities;

public class PlaceVisitors
{
    public List<RejectedVisitor> RejectedVisitors = new List<RejectedVisitor>();

    private void Reject(Visitor visitor, string reason)
    {
        RejectedVisitors.Add(new RejectedVisitor(visitor, reason));
    }

    public void Place(Event show)
    {
        RejectChildren(show);
    }

    private void RejectChildren(Event show)
    {
        foreach (Visitor visitor in show.UnplacedVisitors.Where(v => v.IsChild).ToArray())
        {
            Reject(visitor, "Child is without adult");
            show.UnplacedVisitors.Remove(visitor);
        }

        foreach (Group group in show.UnplacedGroups.Where(g=> g.HasAloneChildren).ToArray())
        {
            foreach (Visitor visitor in group.Visitors)
            {
                Reject(visitor, "Child is without adult");
            }
            show.UnplacedGroups.Remove(group);
        }
    }
}

public class RejectedVisitor
{
    public RejectedVisitor(Visitor visitor, string reason)
    {
        Reason = reason;
        Visitor = visitor;
    }

    public string Reason { get; set; }
    public Visitor Visitor { get; set; }
}


// public Event PlaceAllVisitors(Event newEvent)
// {
//     //Place the groups with children and sort by size
//     
//     var groupsWithChildren = newEvent.UnplacedGroups.Where(g => g.Visitors.Any(v => v.IsChild)).OrderByDescending(g=>g.TotalChildren);
//     foreach (Group groupChildren in groupsWithChildren)
//     {
//         //Plaats de kinderen in de grootste overgebleven sectie op de eerste rij met 1 volwassene
//         //Dan plaats je de overgebleven kinderen net zoals hierboven
//         //Dan plaats je de overgebleven volwassene in de sectie achter de kinderen
//
//         foreach (Section section in newEvent.Sections.OrderByDescending(s=>s.TotalColumns))
//         {
//             var frontRowSeats = section.TotalColumns;
//             if (groupChildren.TotalChildren+1<=frontRowSeats)
//             {
//                 section.PlaceGroupOnFrontRow(groupChildren);
//             }
//         }
//
//         
//         //Plaats de overgebleven in een nieuwe lijst
//         //Place the remaining adults of the group with children on the second row
//         
//     }
//
//     //Place the other groups without children
//     var groupsWithoutChildren = newEvent.UnplacedGroups.Where(g => !g.Visitors.Any(v => v.IsChild));
//     foreach (Group group in groupsWithoutChildren)
//     {
//         
//     }
//     
//     //Place individual visitors
//     var individualVisitors = newEvent.UnplacedVisitors;
//     return newEvent;
// }