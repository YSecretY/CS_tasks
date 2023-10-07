using patterns.builder.Interfaces;

namespace patterns.builder.Classes.directors;

public class GardenDirector : IGardenDirector
{
    public void CreateEmptyGarden(IGardenBuilder builder)
    {
    }

    public void CreateLuxuryGarden(IGardenBuilder builder)
    {
        builder.AddTrees(30);
        builder.AddBushes(50);
        builder.AddFlowers(240);
        builder.AddFountains(5);
    }

    public void CreateHouseGarden(IGardenBuilder builder)
    {
        builder.AddBushes(10);
        builder.AddTrees(5);
        builder.AddFlowers(20);
        builder.AddScarecrows(3);
        builder.AddBarns(3);
        builder.AddGreenhouses(2);
    }
}