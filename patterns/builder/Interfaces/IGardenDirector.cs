namespace patterns.builder.Interfaces;

public interface IGardenDirector
{
    /// <summary>
    /// Creates an empty garden, without anything in it.
    /// </summary>
    /// <param name="builder">Garden builder that builds it.</param>
    public void CreateEmptyGarden(IGardenBuilder builder);

    /// <summary>
    /// Creates a luxury garden, with many trees, bushes, flowers and fountains.
    /// </summary>
    /// <param name="builder">Garden builder that builds it.</param>
    public void CreateLuxuryGarden(IGardenBuilder builder);

    /// <summary>
    /// Creates a house garden, with barn and greenhouses in it.
    /// </summary>
    /// <param name="builder">Garden builder that builds it.</param>
    public void CreateHouseGarden(IGardenBuilder builder);
}