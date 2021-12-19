using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NetFramework.Import;

namespace NetFramework
{
    public class Salad
    {
        public List<Fruit> Fruits = new List<Fruit>();
        
        public static Fruit ConvertImportFruitToFruit(FruitImport importedFruit) 
            => new Fruit(importedFruit.Name, importedFruit.Amount, importedFruit.Price);
        public static FruitImport ConvertFruitToImportFruit(Fruit fruit) 
            => new FruitImport() { Name = fruit.Name, Price = fruit.Price, Amount = fruit.Amount };
        public static Apple ConvertImportAppleToApple(AppleImport importedApple) 
            => new Apple(importedApple.Name, importedApple.Color, importedApple.Amount, importedApple.Price, importedApple.Seed, importedApple.Trees);
        public static AppleImport ConvertAppleToImportApple(Apple apple)
            => new AppleImport() { Name = apple.Name, Price = apple.Price, Amount = apple.Amount, Color = apple.Color, Trees = apple.Trees, Seed = apple.Seed };
    }
}
