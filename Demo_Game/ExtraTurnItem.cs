using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Demo_Game
{
    // vật phẩm tăng lượt chơi
    public class ExtraTurnItem : Item
    {
        public int Turns { get; set; }
        public ExtraTurnItem(string itemCode, int turns) : base(itemCode)
        {
            Turns = turns;
        }
        public override void ApplyEffect(Character character)
        {
            character.AddTurns(Turns);
        } 
    }
}
