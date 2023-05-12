using Logic.Entities;

namespace Logic;

public static class GenerateVisitors
{
    private static readonly Random Random = new();
    public static List<Group> GroupGenerate()
    {
        var list = new List<Group>();
        for (int i = 0; i < 15; i++)
        {
            var visitors = new List<Visitor>();

            for (int j = 0; j < Random.Next(1, 6); j++)
            {
                visitors.Add(new Visitor(false));
            }

            for (int j = 0; j < Random.Next(1, 8); j++)
            {
                visitors.Add(new Visitor(true));
            }

            list.Add(new Group(visitors));
        }

        return list;
    }

    public static List<Visitor> VisitorGenerate()
    {
        var list = new List<Visitor>();
        for (int i = 0; i < Random.Next(10, 50); i++)
        {
            list.Add(new Visitor(Random.Next(50) == 1));
        }
        return list;
    }
}