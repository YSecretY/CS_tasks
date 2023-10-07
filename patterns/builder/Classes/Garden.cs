using System.Text;
using patterns.builder.Classes.gardenParts;
using patterns.builder.Interfaces;

namespace patterns.builder.Classes;

public class Garden : IGarden
{
    private List<Tree> _trees = new();
    private List<Bush> _bushes = new();
    private List<Flower> _flowers = new();
    private List<Scarecrow> _scarecrows = new();
    private List<Fountain> _fountains = new();
    private List<Barn> _barns = new();
    private List<Greenhouse> _greenhouses = new();

    public void AddTree(Tree tree) => _trees.Add(tree);

    public void AddBush(Bush bush) => _bushes.Add(bush);

    public void AddFlower(Flower flower) => _flowers.Add(flower);

    public void AddScarecrow(Scarecrow scarecrow) => _scarecrows.Add(scarecrow);

    public void AddFountain(Fountain fountain) => _fountains.Add(fountain);

    public void AddBarn(Barn barn) => _barns.Add(barn);

    public void AddGreenhouse(Greenhouse greenhouse) => _greenhouses.Add(greenhouse);

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        foreach (Tree tree in _trees)
        {
            if (tree is FruitfulTree) builder.Append(((FruitfulTree)tree).ToString() + ' ');
            builder.Append('\n');
        }

        builder.Append('\n');

        foreach (Bush bush in _bushes)
        {
            if (bush is BerryBush) builder.Append(((BerryBush)bush).ToString() + ' ');
            builder.Append('\n');
        }

        builder.Append('\n');

        foreach (Flower flower in _flowers)
        {
            if (flower is ToSaleFlower) builder.Append(((ToSaleFlower)flower).ToString() + ' ');
            builder.Append('\n');
        }

        builder.Append('\n');

        foreach (Scarecrow scarecrow in _scarecrows)
            builder.Append(scarecrow.Name + ' ');
        builder.Append('\n');


        foreach (Fountain fountain in _fountains)
            builder.Append(fountain.Name + ' ');
        builder.Append('\n');

        foreach (Barn barn in _barns)
            builder.Append($"{barn.Name}, area: {barn.Area}, perimeter: {barn.Perimeter}\n");
        builder.Append('\n');

        foreach (Greenhouse greenhouse in _greenhouses)
            builder.Append($"{greenhouse.Name}, area: {greenhouse.Area}, perimeter: {greenhouse.Perimeter}\n");
        builder.Append('\n');


        return builder.ToString();
    }
}