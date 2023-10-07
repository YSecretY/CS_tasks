using patterns.builder.Classes;
using patterns.builder.Classes.gardenParts;

namespace patterns.builder.Interfaces;

public interface IGarden
{
    /// <summary>
    /// Adds a tree to the garden.
    /// </summary>
    /// <param name="tree">Tree to add.</param>
    public void AddTree(Tree tree);

    /// <summary>
    /// Adds a bush to the garden.
    /// </summary>
    /// <param name="bush">Bush to add</param>
    public void AddBush(Bush bush);

    /// <summary>
    /// Adds a flower to the garden.
    /// </summary>
    /// <param name="flower">Flower to add.</param>
    public void AddFlower(Flower flower);

    /// <summary>
    /// Adds a scarecrow to the garden.
    /// </summary>
    /// <param name="scarecrow">Scarecrow to add.</param>
    public void AddScarecrow(Scarecrow scarecrow);

    /// <summary>
    /// Adds a fountain to the garden.
    /// </summary>
    /// <param name="fountain">Fountain to add.</param>
    public void AddFountain(Fountain fountain);

    /// <summary>
    /// Adds a barn to the garden.
    /// </summary>
    /// <param name="barn">Barn to add.</param>
    public void AddBarn(Barn barn);

    /// <summary>
    /// Adds a greenhouse to the garden.
    /// </summary>
    /// <param name="greenhouse">Greenhouse to add.</param>
    public void AddGreenhouse(Greenhouse greenhouse);
}