﻿using patterns.adapter.classes;
using patterns.adapter.interfaces;

namespace patterns;

class Program
{
    static void Main()
    {
        CoffeeMachine coffeeMachine = new CoffeeMachine();
        ITeaMakerAdapter teaMakerAdapter = new TeaMakerAdapter(coffeeMachine);
        teaMakerAdapter.MakeTea();
    }
}