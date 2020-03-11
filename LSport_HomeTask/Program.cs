using System;
using LSport_HomeTask.Config;
using LSport_HomeTask.Managers.MySQL.GiphyManager;
using LSport_HomeTask.Managers.WebAPI;
using LSport_HomeTask.Models.Giphy;
using LSport_HomeTask.Models.Parser;

namespace LSport_HomeTask
{
    class Program
    {
		static void Main(string[] args)
		{
			//Establish connection to Giphy API service.
			Console.WriteLine("Operation started");
			GiphyWebAPIManager giphyWebAPIManager = new GiphyWebAPIManager();
			//Retriving data from Giphy.com
			string randomGiphyData = giphyWebAPIManager.getRandomGiphy();

			//Parsing data to Json.
			Console.WriteLine("creating parser...");
			GiphyParser giphyParser = new GiphyParser(randomGiphyData);
			Console.WriteLine("done");

			//Parsing Json to Giphy object.
			Console.WriteLine("creating Giphy object...");
			Giphy newGiphy = giphyParser.JsonToGiphy;
			Console.WriteLine("done");

			//Establish connection to MySQL database.
			Console.WriteLine("creating Giphy database manager...");
			GiphyDBConfig giphyConfig = new GiphyDBConfig();
			GiphyMySQLManager mySqlHandler = new GiphyMySQLManager(giphyConfig.getConnectionString());
			Console.WriteLine("done");

			//Saving Giphy object too MySQL database.
			Console.WriteLine("Saving to database...");
			if (mySqlHandler.SaveToDatabase(newGiphy))
			{
				Console.WriteLine("Operation Succeeded !");
			}
			else
			{
				Console.WriteLine("Operation Failed !");
			}
		}
    }
}
