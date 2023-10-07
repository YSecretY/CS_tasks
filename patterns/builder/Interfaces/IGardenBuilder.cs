using patterns.builder.Classes;
using patterns.builder.Classes.gardenParts;

namespace patterns.builder.Interfaces;

public interface IGardenBuilder
{
    /// <summary>
    /// Adds given number of trees to the garden.
    /// </summary>
    /// <param name="numberOfTrees">Number of trees to add.</param>
    public void AddTrees(int numberOfTrees);

    /// <summary>
    /// Adds given number of bushes to the garden.
    /// </summary>
    /// <param name="numberOfBushes">Number of bushes to add.</param>
    public void AddBushes(int numberOfBushes);

    /// <summary>
    /// Adds given number of flowers to the garden.
    /// </summary>
    /// <param name="numberOfFlowers">Number of flowers to add.</param>
    public void AddFlowers(int numberOfFlowers);

    /// <summary>
    /// Adds given number of scarecrows to the garden.
    /// </summary>
    /// <param name="numberOfScarecrows">Number of scarecrows to add.</param>
    public void AddScarecrows(int numberOfScarecrows);

    /// <summary>
    /// Adds given number of barns to the garden.
    /// </summary>
    /// <param name="numberOfBarns">Number of barns to add.</param>
    public void AddBarns(int numberOfBarns);

    /// <summary>
    /// Adds given number of greenhouses to the garden.
    /// </summary>
    /// <param name="numberOfGreenhouses">Number of greenhouses to add.</param>
    public void AddGreenhouses(int numberOfGreenhouses);

    /// <summary>
    /// Adds given number of fountains to the garden.
    /// </summary>
    /// <param name="numberOfFountains">Number of fountains to add.</param>
    public void AddFountains(int numberOfFountains);

    /// <summary>
    /// Returns the result garden.
    /// </summary>
    /// <returns>Garden in result.</returns>
    public Garden GetResult();
}