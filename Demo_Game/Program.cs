using System;
using System.Collections.Generic;
using System.Linq;
using Demo_Game;

public class Program
{
    public static void Main(string[] args)
    {

        Game game = new Game();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nGame Management:");
            Console.WriteLine("1. Add Character");
            Console.WriteLine("2. Add Item to Character");
            Console.WriteLine("3. Display Character Info");
            Console.WriteLine("4. Calculate Total Play Turns");
            Console.WriteLine("5. Sort Characters by Items Count");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter character name: ");
                        string name = Console.ReadLine();
                        Character newCharacter = new Character(name);
                        game.AddCharacter(newCharacter);
                        Console.WriteLine($"Character {name} added with ID {newCharacter.CharacterId}.");
                        break;

                    case 2:
                        Console.Write("Enter character ID: ");
                        if (int.TryParse(Console.ReadLine(), out int characterId))
                        {
                            Console.WriteLine("Choose Item Type:");
                            Console.WriteLine("1. Extra Turn Item");
                            Console.WriteLine("2. Health Item");
                            Console.Write("Choose an option: ");
                            if (int.TryParse(Console.ReadLine(), out int itemType))
                            {
                                Console.Write("Enter item code (e.g. A01, B01): ");
                                string itemCode = Console.ReadLine().ToUpper();

                                // Kiểm tra mã vật phẩm hợp lệ
                                bool isValidItemCode = false;
                                switch (itemType)
                                {
                                    case 1:
                                        if (itemCode.Length == 3 && itemCode.StartsWith("A") && int.TryParse(itemCode.Substring(1), out _))
                                        {
                                            isValidItemCode = true;
                                            Console.Write("Enter number of turns: ");
                                            if (int.TryParse(Console.ReadLine(), out int turns))
                                            {
                                                game.AddItemToCharacter(characterId, new ExtraTurnItem(itemCode, turns));
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid number of turns.");
                                            }
                                        }
                                        break;

                                    case 2:
                                        if (itemCode.Length == 3 && itemCode.StartsWith("B") && int.TryParse(itemCode.Substring(1), out _))
                                        {
                                            isValidItemCode = true;
                                            Console.Write("Enter health amount: ");
                                            if (int.TryParse(Console.ReadLine(), out int health))
                                            {
                                                // Lấy số máu hiện tại của nhân vật
                                                int currentHealth = game.GetCharacterHealth(characterId);

                                                // Kiểm tra nếu số máu nhập vào không hợp lệ
                                                if (health < -currentHealth)
                                                {
                                                    Console.WriteLine($"Invalid health amount. The health cannot go below zero. Current health: {currentHealth}");
                                                }
                                                else
                                                {
                                                    game.AddItemToCharacter(characterId, new HealthItem(itemCode, health));
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid health amount.");
                                            }
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Invalid item type.");
                                        break;
                                }

                                if (!isValidItemCode)
                                {
                                    Console.WriteLine("Invalid item code. Please enter a valid code (e.g., A01, B01).");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid option for item type.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid character ID.");
                        }
                        break;


                    case 3:
                        Console.Write("Enter character ID: ");
                        if (int.TryParse(Console.ReadLine(), out characterId))
                        {
                            game.DisplayCharacterInfo(characterId);
                        }
                        break;

                    case 4:
                        Console.Write("Enter character ID: ");
                        if (int.TryParse(Console.ReadLine(), out characterId))
                        {
                            var character = game.Characters.FirstOrDefault(c => c.CharacterId == characterId);
                            if (character != null)
                            {
                                Console.WriteLine($"Total turns for {character.Name}: {character.GetTotalTurns()}");
                            }
                            else
                            {
                                Console.WriteLine("Character not found.");
                            }
                        }
                        break;

                    case 5:
                        game.SortCharactersByItems();
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}