using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monopoly
{
    class MainGame
    {
        static StartGameSetting startGameSetting;
        static Board board;
        static MoneyMethod bank;

        static void Main()
        {
            startGameSetting = new StartGameSetting();
            board = new Board();
            
            while (true)
            {
                List<Player> playerList = startGameSetting.InitialiseGame();
                RollingDie die = startGameSetting.InitialiseDie();
                List<Tile> tileList = board.InitializeBoard(); 

                while (true)
                {
                    foreach (Player player in playerList)
                    {
                        int dieResult = die.Roll();
                        player.CurrentTileIndex += dieResult;
                        if (player.CurrentTileIndex >= tileList.Count())
                        {
                            player.CurrentTileIndex -= tileList.Count();
                        }


                    }
                }
            }
            
        }

        public static void LandOnTile(Player player, List<Player> playerList, List<Tile> tileList, int tileIndex)
        {
            bank = new MoneyMethod();
            Tile currentTile = tileList[tileIndex];
            if (currentTile is Special)
            {
                bank.Transaction(player, currentTile);

            }
            else
            {
                Street currentStreet = (Street)currentTile;
                if (currentStreet.owner == null)
                {
                    bank.Transaction(player, currentStreet);
                }
                else
                {
                    bank.RentTransaction(player,)
                }
            }

           
        }
    }
}
