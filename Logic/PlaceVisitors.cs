namespace Logic.Entities;

public class PlaceVisitors
{
    public Event PlaceAllVisitors(Event newEvent)
    {
        //Place the groups with children and sort by size
        
        var groupsWithChildren = newEvent.UnplacedGroups.Where(g => g.Visitors.Any(v => v.IsChild)).OrderByDescending(g=>g.TotalChildren);
        foreach (var group in groupsWithChildren)
        {
            //Plaats de kinderen in de grootste overgebleven sectie op de eerste rij met 1 volwassene
            //Dan plaats je de overgebleven kinderen net zoals hierboven
            //Dan plaats je de overgebleven volwassene in de grootste sectie achter de kinderen

            foreach (var section in newEvent.Sections.OrderByDescending(s=>s.TotalColumns))
            {
                var frontRowSeats = section.TotalColumns;
                if (group.TotalChildren+1<=frontRowSeats)
                {
                    
                }

                
            }
        }

        //Place the other groups without children
        var groupsWithoutChildren = newEvent.UnplacedGroups.Where(g => !g.Visitors.Any(v => v.IsChild));
        //Place individual visitors
        var individualVisitors = newEvent.UnplacedVisitors;
        return newEvent;
    }

    
}