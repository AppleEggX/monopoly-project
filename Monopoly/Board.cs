using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Board
    {
        NameValueCollection tileConfig = ConfigurationManager.GetSection("DefaultBoardSetupGroup/TileSetup") as System.Collections.Specialized.NameValueCollection;

        public List<Tile> InitializeBoard()
		{
            string cfgTotalTiles = tileConfig["TotalTilesInGroup"]; //TODO Create References to app.config
            bool parsedTotalTiles = Int32.TryParse(cfgTotalTiles, out int totalTiles);

            Special  freeParking = new Special();
            Street   oldStreet   = new Street();
            Street   newStreet   = new Street();
            Special  theft       = new Special();
            Utility  electric    = new Utility();
            Street   fleetStreet = new Street();
            Special  dividend    = new Special();
            Special  go          = new Special();


            Int32.TryParse(tileConfig["Tile0Index"], out int goID);
            go.tileID = goID;
            Int32.TryParse(tileConfig["Tile0Value"], out int goVal);
            go.tileValue = goVal;
            go.tileName = tileConfig["Tile0Name"];

            Int32.TryParse(tileConfig["Tile1Index"], out int freeParkingID);
            freeParking.tileID = freeParkingID;
            Int32.TryParse(tileConfig["Tile1Value"], out int freeParkingVal);
            freeParking.tileValue = freeParkingVal;
            freeParking.tileName = tileConfig["Tile1Name"];

            Int32.TryParse(tileConfig["Tile2Index"], out int oldStreetID);
            oldStreet.tileID = oldStreetID;
            Int32.TryParse(tileConfig["Tile2BuyVal"], out int oldStreetBuyVal);
            oldStreet.tileBuyValue = oldStreetBuyVal;
            Int32.TryParse(tileConfig["Tile2RentVal"], out int oldStreetRentVal);
            oldStreet.tileRentValue = oldStreetRentVal;
            oldStreet.owner = null;
            oldStreet.tileName = tileConfig["Tile2Name"];

            Int32.TryParse(tileConfig["Tile3Index"], out int newStreetID);
            newStreet.tileID = newStreetID;
            Int32.TryParse(tileConfig["Tile3BuyVal"], out int newStreetBuyVal);
            newStreet.tileBuyValue = newStreetBuyVal;
            Int32.TryParse(tileConfig["Tile3RentVal"], out int newStreetRentVal);
            newStreet.tileRentValue = newStreetRentVal;
            newStreet.owner = null;
            newStreet.tileName = tileConfig["Tile3Name"];

            Int32.TryParse(tileConfig["Tile4Index"], out int taxationIsTheftID);
            theft.tileID = taxationIsTheftID;
            Int32.TryParse(tileConfig["Tile4Value"], out int taxationIsTheftVal);
            theft.tileValue = taxationIsTheftVal;
            theft.tileName = tileConfig["Tile4Name"];

            Int32.TryParse(tileConfig["Tile5Index"], out int electricID);
            electric.tileID = electricID;
            Int32.TryParse(tileConfig["Tile5BuyVal"], out int elecricBuyVal);
            electric.tileBuyValue = elecricBuyVal;
            Int32.TryParse(tileConfig["Tile5RentVal"], out int elecricRentVal);
            electric.tileRentValue = elecricRentVal;
            electric.owner = null;
            electric.tileName = tileConfig["Tile5Name"];

            Int32.TryParse(tileConfig["Tile6Index"], out int fleetStreetID);
            fleetStreet.tileID = fleetStreetID;
            Int32.TryParse(tileConfig["Tile6BuyVal"], out int fleetStreetBuyVal);
            fleetStreet.tileBuyValue = 250;
            Int32.TryParse(tileConfig["Tile6RentVal"], out int fleetStreetRentVal);
            fleetStreet.tileRentValue = 100;
            fleetStreet.owner = null;
            fleetStreet.tileName = tileConfig["Tile6Name"];

            Int32.TryParse(tileConfig["Tile7Index"], out int dividendID);
            dividend.tileID = dividendID;
            Int32.TryParse(tileConfig["Tile7Value"], out int dividendVal);
            dividend.tileValue = dividendVal;
            dividend.tileName = tileConfig["Tile7Name"];

            List<Tile> tiles = new List<Tile>();
            tiles.Add(go);
            tiles.Add(freeParking);
            tiles.Add(oldStreet);
            tiles.Add(newStreet);
            tiles.Add(theft);
            tiles.Add(electric);
            tiles.Add(fleetStreet);
            tiles.Add(dividend);
            return tiles;
		}
    }
	
	public class Tile
	{
		public int tileID
		{ get; set; }
		public string tileName
		{ get; set; }
		
	}
	
	public class Special : Tile
	{
		public int tileValue
		{ get; set;}
			
	}
	
	public class Street : Tile
	{
		public int tileBuyValue
		{get; set; }
		public int tileRentValue
		{get; set;}
        public string owner
        {get; set;}
		
	}
	
	public class Utility : Street
	{
			public int getRent()
			{
                RollingDie die = new RollingDie();
                int numberOnDie = die.Roll();
                int totalRentAmount = numberOnDie * tileRentValue;
                Console.WriteLine($"You rolled a {numberOnDie}, your rent is therefore {totalRentAmount}");
				return totalRentAmount;
			}
	}
	
}
