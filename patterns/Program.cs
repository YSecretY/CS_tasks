﻿using patterns.builder.Classes;
using patterns.builder.Classes.builders;
using patterns.builder.Classes.directors;

namespace patterns;

class Program
{
    static void Main()
    {
        GardenDirector director = new GardenDirector();
        StreamWriter emptyGardenFile = new StreamWriter("./patterns/builder/emptyGarden.txt");
        StreamWriter houseGardenFile = new StreamWriter("./patterns/builder/houseGarden.txt");
        StreamWriter luxuryGardenFile = new StreamWriter("./patterns/builder/luxuryGardenFile.txt");

        if (!emptyGardenFile.BaseStream.CanWrite ||
            !houseGardenFile.BaseStream.CanWrite ||
            !luxuryGardenFile.BaseStream.CanWrite)
            throw new FileLoadException("One the files cannot be open.");

        GardenBuilder builder1 = new GardenBuilder();
        director.CreateEmptyGarden(builder1);
        Garden emptyGarden = builder1.GetResult();
        emptyGardenFile.WriteLine($"Empty garden: \n{emptyGarden}");
        emptyGardenFile.Dispose();

        GardenBuilder builder2 = new GardenBuilder();
        director.CreateHouseGarden(builder2);
        Garden houseGarden = builder2.GetResult();
        houseGardenFile.WriteLine($"House garden: \n{houseGarden}");
        houseGardenFile.Dispose();

        GardenBuilder builder3 = new GardenBuilder();
        director.CreateLuxuryGarden(builder3);
        Garden luxuryGarden = builder3.GetResult();
        luxuryGardenFile.WriteLine($"luxury garden: \n{luxuryGarden}");
        luxuryGardenFile.Dispose();
    }
}