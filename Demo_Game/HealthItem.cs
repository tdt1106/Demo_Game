using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Game
{

    // vật phẩm tăng máu
    public class HealthItem : Item
    {
        public int Health { get; set; }
        public HealthItem(string itemCode, int health) : base(itemCode)
        {
            Health = health;
        }
        public override void ApplyEffect(Character character)
        {
            character.IncreaseHealth(Health);
        }
    }
}
