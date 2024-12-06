using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Game
{
    public class Game
    {
        public List<Character> Characters { get; set; }

        public Game()
        {
            Characters = new List<Character>();
        }
        public Character GetCharacterById(int characterId)
        {
            return Characters.FirstOrDefault(c => c.CharacterId == characterId);
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public void AddItemToCharacter(int characterId, Item item)
        {
            var character = GetCharacterById(characterId);
            if (character != null)
            {
                character.AddItem(item);
            }
            else
            {
                Console.WriteLine("Character not found.");
            }
        }

        public void DisplayCharacterInfo(int characterId)
        {
            var character = GetCharacterById(characterId);
            if (character != null)
            {
                character.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Character not found.");
            }
        }

        public void SortCharactersByItems()
        {
            Characters = Characters.OrderByDescending(c => c.Items.Count).ToList();
            Console.WriteLine("Characters sorted by item count:");
            foreach (var character in Characters)
            {
                Console.WriteLine($"{character.Name} - Items: {character.Items.Count}");
            }
        }
        // Thêm phương thức để lấy máu hiện tại của nhân vật
        public int GetCharacterHealth(int characterId)
        {
            var character = GetCharacterById(characterId);
            if (character != null)
            {
                return character.Health; // Giả định lớp Character có thuộc tính Health
            }
            else
            {
                Console.WriteLine("Character not found.");
                return 0; // Trả về giá trị mặc định nếu không tìm thấy
            }
        }
    }

}
