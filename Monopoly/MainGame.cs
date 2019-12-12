using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monopoly
{
    class MainGame
    {
        static StartGameSetting startGameSetting = new StartGameSetting();
        static Board board = new Board();
        static MoneyMethod bank = new MoneyMethod();
        static List<Player> brokePlayers = new List<Player>();

        static void Main()
        {
            while (true)
            {
                List<Player> playerList = startGameSetting.InitialiseGame();
                RollingDie die = startGameSetting.InitialiseDie();
                List<Tile> tileList = board.InitializeBoard();
                Player winner;

                while (true)
                {
                    foreach (Player player in playerList)
                    {


                        Console.WriteLine($"It is {player.GetPlayerName()}'s turn.");
                        Console.ReadLine();
                        int dieResult = die.Roll();
                        player.CurrentTileIndex += dieResult;
                        Console.WriteLine($"You rolled a {dieResult}");
                        if (player.CurrentTileIndex >= tileList.Count())
                        {
                            player.CurrentTileIndex -= tileList.Count();
                        }
                        Console.WriteLine($"You landed on {tileList[player.CurrentTileIndex].tileName}.");




                        if (tileList[player.CurrentTileIndex] is Special)
                        {
                            Special currentSpecial = (Special)tileList[player.CurrentTileIndex];
                            bank.Transaction(player, tileList[player.CurrentTileIndex]);


                            if (currentSpecial.tileValue > 0) { Console.WriteLine($"You Gained {currentSpecial.tileValue} credits"); }
                            else if (currentSpecial.tileValue < 0) { Console.WriteLine($"You Lost {-(currentSpecial.tileValue)} credits"); }
                            else { Console.WriteLine($"Nothing happens on this tile - it's free!"); }
                            Console.ReadLine();

                        }
                        else
                        {
                            Street currentStreet = (Street)tileList[player.CurrentTileIndex];
                            if (currentStreet.owner == null)
                            {
                                bank.Transaction(player, tileList[player.CurrentTileIndex]);
                                currentStreet.owner = player.GetPlayerName();
                                tileList[player.CurrentTileIndex] = currentStreet;
                                player.ownedProperties.Add(currentStreet);


                                Console.WriteLine($"You Bought {currentStreet.tileName} for {currentStreet.tileBuyValue} credits");
                                Console.ReadLine();
                            }
                            else
                            {
                                bank.RentTransaction(player, playerList.Find(i => i.GetPlayerName() == currentStreet.owner), tileList[player.CurrentTileIndex]);


                                Console.WriteLine($"You Paid {currentStreet.tileRentValue} credits of rent to {currentStreet.owner}");
                                Console.ReadLine();
                            }


                        }

                    }
                    List<Player> tempBrokePlayers = playerList.FindAll(i => i.MoneyBalance < 0);
                    playerList.RemoveAll(i => i.MoneyBalance < 0);
                    foreach (Player player in tempBrokePlayers)
                    {
                        brokePlayers.Add(player);
                        Console.WriteLine($"{player.GetPlayerName()} is broke. ");
                        Console.ReadLine();
                        foreach (Tile tile in player.ownedProperties)
                        {
                            Street tempStreet = (Street)tileList[tile.tileID];
                            tempStreet.owner = null;
                            tileList.RemoveAt(tile.tileID);
                            tileList.Insert(tile.tileID,tempStreet);
                            Console.WriteLine($"{tempStreet.tileName} is now available to purchase");
                        }
                    }
                    if (playerList.Count() == 1)
                    {
                        winner = playerList[0];
                        break;
                    }

                    Console.Write("At the end of this round,\n");
                    foreach (Player player in playerList)
                    {                       
                            Console.Write($"{player.GetPlayerName()} has {player.GetBalance()} credits\n" +
                                $"");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"The winner is {winner.GetPlayerName()}");
                Console.WriteLine("Type 'y' to play again. Type anything else to quit.");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            
        }


    }
}
