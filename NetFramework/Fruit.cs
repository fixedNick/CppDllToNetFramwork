using System;

namespace NetFramework
{
    [Serializable]
    public class Fruit
    {
        // Можно заприватить setter
        // Можно указать в сеттере правила установки
        // {get;set;} - синтаксический сахар - свойства
        // по сути своей раскрываются в два поля private _name & public Name и два метода set->_name = val & get->return _name
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Fruit(string name, int amount, double price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}:{Amount}:{Price}";
        }
    }
}
