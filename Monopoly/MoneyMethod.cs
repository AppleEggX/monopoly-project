using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class MoneyMethod
    {
        public void RentTransaction(Player playerFrom, Player playerTo, Tile tile)
        {
            if (tile is Utility)
            {
                Utility tileUtility = (Utility)tile;
                int utilityAmount = tileUtility.getRent();                
                playerTo.ChangeBalance(utilityAmount);
                playerFrom.ChangeBalance(-utilityAmount);
            }
            else
            {
                Street tileStreet = (Street)tile;
                int rentAmount = tileStreet.tileRentValue;
                playerTo.ChangeBalance(rentAmount);
                playerFrom.ChangeBalance(-rentAmount);
            }
        }

        public void Transaction(Player playerFrom, Tile tile)
        {
            if (tile is Special)
            {
                Special tileSpecial = (Special)tile;
                int specialAmount = tileSpecial.tileValue;
                playerFrom.ChangeBalance(specialAmount);

            }
            else
            {
                Street tileStreet = (Street)tile;
                int buyAmount = tileStreet.tileBuyValue;
                playerFrom.ChangeBalance(-buyAmount);
            }   
            
        }


    }
}
