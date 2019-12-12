using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public string PlayerName { get; set; }
        public bool IsAlive { get; set; }
        public int MoneyBalance { get; protected set; }
        public int PlayerID { get; protected set; }
        public int CurrentTileIndex { get; set; }
        public List<Tile> ownedProperties { get; set; }


        public Player(string playerName)
        {
            SetPlayerName(playerName);
            MoneyBalance = 1000;
            AddPlayer();
            CurrentTileIndex = 0;
            ownedProperties = new List<Tile>();

        }

        public Player(string playerName, int playerID)
        {
            SetPlayerName(playerName);
            SetPlayerID(playerID);
            MoneyBalance = 1000;
            AddPlayer();
            ownedProperties = new List<Tile>();
        }

        public string GetPlayerName()
        {
            return PlayerName;
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }

        public bool GetPlayerStatus()
        {
            return IsAlive;
        }

        public void AddPlayer()
        {
            IsAlive = true;
        }

        public void RemovePlayer()
        {
            IsAlive = false;
        }

        public int GetBalance()
        {
            return MoneyBalance;
        }

        public void ChangeBalance(int amountToChangeBalanceBy)
        {
            MoneyBalance += amountToChangeBalanceBy;
        }

        public int GetPlayerID()
        {
            return PlayerID;
        }

        public void SetPlayerID(int idValue)
        {
            PlayerID = idValue;
        }


    }
}
