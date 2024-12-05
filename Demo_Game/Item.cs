using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Game
{
    // tất cả các loại vật phẩm trong trò chơi
    public abstract class Item
    {
        public string ItemCode { get; set; }

        public Item(string itemCode)
        {
            ItemCode = itemCode;
        }
        public abstract void ApplyEffect(Character character); // hiệu ứng tăng máu or tăng lượt chơi
    }
}
