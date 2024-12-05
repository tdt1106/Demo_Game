using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Game;

namespace Demo_Game
{
    public class Character
    {
        private static int _nextId = 1;
        public int CharacterId { get; private set; }
        public string Name { get; set; }
        public int Turns { get; private set; } = 1;  // Mặc định là 1 lượt chơi ban đầu
        public int Health { get; private set; } = 100;  // Mặc định là 100 máu
        public List<Item> Items { get; private set; }

        public Character(string name)
        {
            CharacterId = _nextId++;
            Name = name;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            item.ApplyEffect(this);  // Áp dụng hiệu ứng của vật phẩm
        }

        public void AddTurns(int turns)
        {
            Turns += turns;
        }

        public void IncreaseHealth(int health)
        {
            Health += health;
        }

        public int GetTotalTurns()
        {
            return Turns;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {CharacterId}, Name: {Name}, Turns: {Turns}, Health: {Health}");
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"  {item.ItemCode}");
            }
        }
    }
}
