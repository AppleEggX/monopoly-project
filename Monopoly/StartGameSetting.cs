using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monopoly
{
    public class StartGameSetting
    {
        List<Player> players = new List<Player>();

        private void InitialisePlayers(ref List<Player> players, int playerNumberInInt)
        {
            for (int i = 0; i < playerNumberInInt; i++)
            {
                Console.WriteLine($"Please input player {i + 1}'s name: ");
                string playerNameInString = Console.ReadLine();
                Player player = new Player(playerNameInString, i);
                players.Add(player);
            }
        }

        public void InitialiseMap()
        {
            #region Holly's initialiseMap methods

            #endregion
        }

        public RollingDie InitialiseDie()
        {
            RollingDie die = new RollingDie();
            die.SetDieSideCount(6);
            return die;
        }

        public List<Player> InitialiseGame()
        {
            players.Clear();
            List<decimal> playerMoneys = new List<decimal>();
            //List<string> playerNames = new List<string>();
            //Player player;

            Console.Write("Welcome to Monopoly, please input the number of players: ");
            int playerNumberInInt;

            while (true)
            {
                string playerNumberInStr = Console.ReadLine();
                if (!Int32.TryParse(playerNumberInStr, out playerNumberInInt))
                {
                    Console.WriteLine("Please input an integer");
                    continue;
                }
                else
                {
                    if (playerNumberInInt > 6 || playerNumberInInt < 2)
                    {
                        Console.WriteLine("The number of players in the game has to be between 2 and 6");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"The number of players is {playerNumberInInt}");
                        break;
                    }
                }
            }

            InitialisePlayers(ref players, playerNumberInInt);
            
            Console.Write("In this game ");
            foreach (Player playerInPlayers in players)
            {
                //Console.WriteLine(playerInPlayers.GetPlayerName());
                if (playerInPlayers == players.First())
                {
                    Console.Write($"{playerInPlayers.GetPlayerName()}");
                }
                else if (playerInPlayers == players.Last())
                {
                    Console.Write($" and {playerInPlayers.GetPlayerName()} ");
                }
                else
                {
                    Console.Write($", {playerInPlayers.GetPlayerName()}");
                }
            }
            Console.Write("are playing.");
            Console.WriteLine();

            int startPlayerId = ChooseStartPlayer(playerNumberInInt);
            Console.WriteLine($"This game starts with player{startPlayerId + 1}: {players[startPlayerId].GetPlayerName()}");
            players = players.OrderBy(a => Guid.NewGuid()).ToList();
            Player firstPlayer = players[startPlayerId];
            players.Remove(players[startPlayerId]);
            players.Insert(0, firstPlayer);
            return players;
        }

        private int ChooseStartPlayer(int numberOfPlayers)
        {
            Random random = new Random();

            int idChosen = random.Next(0, numberOfPlayers);
            return idChosen;
        }






    }
}
