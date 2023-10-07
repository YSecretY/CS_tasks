using patterns.builder.builder.enums;
using patterns.builder.Classes.gardenParts;
using patterns.builder.enums;
using patterns.builder.Interfaces;

namespace patterns.builder.Classes.builders;

public class GardenBuilder : IGardenBuilder
{
    private Garden _garden = new();

    public void AddTrees(int numberOfTrees)
    {
        if (numberOfTrees < 0) throw new ArgumentException("numberOfTrees cannot be < 0.");

        for (int i = 0; i < numberOfTrees; ++i)
        {
            Random random = new Random();
            int randomFruitType = random.Next(0, Enum.GetNames(typeof(FruitTypes)).Length);
            FruitfulTree fruitfulTree = new FruitfulTree($"fruitfulTree{i}", (FruitTypes)randomFruitType);
            _garden.AddTree(fruitfulTree);
        }
    }

    public void AddScarecrows(int numberOfScarecrows)
    {
        if (numberOfScarecrows < 0) throw new ArgumentException("numberOfScarecrows cannot be < 0.");

        for (int i = 0; i < numberOfScarecrows; ++i)
        {
            Scarecrow scarecrow = new Scarecrow($"Scarecrow{i}");
            _garden.AddScarecrow(scarecrow);
        }
    }

    public void AddBushes(int numberOfBushes)
    {
        if (numberOfBushes < 0) throw new ArgumentException("numberOfBushes cannot be < 0.");

        for (int i = 0; i < numberOfBushes; ++i)
        {
            Random random = new Random();
            int randomBerryType = random.Next(0, Enum.GetNames(typeof(BerryTypes)).Length);
            BerryBush berryBush = new BerryBush($"Bush{i}", (BerryTypes)randomBerryType);
            _garden.AddBush(berryBush);
        }
    }

    public void AddFlowers(int numberOfFlowers)
    {
        if (numberOfFlowers < 0) throw new ArgumentException("numberOfFlowers cannot be < 0.");

        for (int i = 0; i < numberOfFlowers; ++i)
        {
            Random random = new Random();
            int randomFlowerType = random.Next(0, Enum.GetNames(typeof(FlowerTypes)).Length);
            ToSaleFlower toSaleFlower = new ToSaleFlower($"Flower{i}", (FlowerTypes)randomFlowerType);
            _garden.AddFlower(toSaleFlower);
        }
    }

    public void AddFountains(int numberOfFountains)
    {
        if (numberOfFountains < 0) throw new ArgumentException("numberOfFountains cannot be < 0.");

        for (int i = 0; i < numberOfFountains; ++i)
        {
            Fountain fountain = new Fountain($"Fountain{i}");
            _garden.AddFountain(fountain);
        }
    }

    public void AddGreenhouses(int numberOfGreenhouses)
    {
        if (numberOfGreenhouses < 0) throw new ArgumentException("numberOfGreenhouses cannot be < 0.");

        for (int i = 0; i < numberOfGreenhouses; ++i)
        {
            Greenhouse greenhouse = new Greenhouse($"Greenhouse{i}", (i + 1) * 15, (i + 1) * 15);
            _garden.AddGreenhouse(greenhouse);
        }
    }

    public void AddBarns(int numberOfBarns)
    {
        if (numberOfBarns < 0) throw new ArgumentException("numberOfBarns cannot be < 0.");

        for (int i = 0; i < numberOfBarns; ++i)
        {
            Barn barn = new Barn($"Barn{i}", (i + 1) * 15, (i + 1) * 15);
            _garden.AddBarn(barn);
        }
    }

    public Garden GetResult()
    {
        return _garden;
    }
}