using System;

namespace NetFramework
{
    [Serializable]
    public class Apple : Fruit
    {
        public string Color { get; set; }
        public int Seed { get; set; }
        public int Trees { get; set; }

        public Apple(string name, string color, int amount, double price, int seed, int trees)
            : base(name, amount, price)
        {
            Color = color;
            Seed = seed;
            Trees = trees;
        }
        public override string ToString()
        {
            return base.ToString() + $":{Color}:{Seed}:{Trees}";
        }

    }
}
