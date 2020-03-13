
using Newtonsoft.Json;
using LSport_HomeTask.Models.Giphy;


namespace LSport_HomeTask.Models.Parser
{
    class GiphyParser
    {

		private dynamic jsonFile;


		public GiphyParser(string data)
		{
			this.jsonFile = JsonConvert.DeserializeObject(data); ;
		}


		public Giphy.Giphy JsonToGiphy => new Giphy.Giphy
		{
			id = jsonFile["data"]["id"],
			URL = jsonFile["data"]["bitly_url"],
			rating = jsonFile["data"]["rating"],
			title = jsonFile["data"]["title"],
			type = jsonFile["data"]["type"]
		};
	}
}
