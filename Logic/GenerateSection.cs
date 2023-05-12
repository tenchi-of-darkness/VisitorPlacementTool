using Logic.Entities;

namespace Logic;

public static class GenerateSection
{
    private static Random _random = new Random();

    public static List<Section> Generate()
    {
        List<Section> sections = new List<Section>();
        for (int i = 0; i < _random.Next(3, 8); i++)
        {
            sections.Add(new Section());
        }

        return sections;
    }
}