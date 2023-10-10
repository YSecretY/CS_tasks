﻿using patterns.observer.classes;
using Timer = patterns.observer.classes.Timer;

namespace patterns;

class Program
{
    static void Main()
    {
        Microwave microwave = new Microwave();
        Oven oven = new Oven();
        Timer timer = new Timer();

        timer.Attach(microwave);
        timer.Attach(oven);
        Task task = Task.Run(async () => await timer.Set(DateTime.Now.AddSeconds(5)));

        microwave.MakeFood();
        oven.MakeFood();

        task.Wait();
    }
}