namespace Logic.Entities;

public class PlaceVisitors
{
    public Event PlaceAllVisitors(Event newEvent)
    {
        //Place the groups with children and sort by size
        
        var groupsWithChildren = newEvent.UnplacedGroups.Where(g => g.Visitors.Any(v => v.IsChild)).OrderByDescending(g=>g.TotalChildren);
        foreach (Group groupChildren in groupsWithChildren)
        {
            //Plaats de kinderen in de grootste overgebleven sectie op de eerste rij met 1 volwassene
            //Dan plaats je de overgebleven kinderen net zoals hierboven
            //Dan plaats je de overgebleven volwassene in de sectie achter de kinderen

            foreach (Section section in newEvent.Sections.OrderByDescending(s=>s.TotalColumns))
            {
                var frontRowSeats = section.TotalColumns;
                if (groupChildren.TotalChildren+1<=frontRowSeats)
                {
                    section.PlaceGroupOnFrontRow(groupChildren);
                }
            }

            
            //Plaats de overgebleven in een nieuwe lijst
            //Place the remaining adults of the group with children on the second row
            
        }

        //Place the other groups without children
        var groupsWithoutChildren = newEvent.UnplacedGroups.Where(g => !g.Visitors.Any(v => v.IsChild));
        foreach (Group group in groupsWithoutChildren)
        {
            
        }
        
        //Place individual visitors
        var individualVisitors = newEvent.UnplacedVisitors;
        return newEvent;
    }

    
}