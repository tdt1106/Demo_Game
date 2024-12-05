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

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public void AddItemToCharacter(int characterId, Item item)
        {
            var character = Characters.FirstOrDefault(c => c.CharacterId == characterId);
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
            var character = Characters.FirstOrDefault(c => c.CharacterId == characterId);
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
    }

}
