using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using LSport_HomeTask.Config;
using LSport_HomeTask.Interfaces.WebAPI;

namespace LSport_HomeTask.Managers.WebAPI
{
	class GiphyWebAPIManager : GiphyWebAPIInterface
	{
		public string getRandomGiphy()
		{
			GiphyAPIConfig giphyAPIConfig = new GiphyAPIConfig();
			// Create a request for the URL.   
			WebRequest request = WebRequest.Create(giphyAPIConfig.getRandomURL());
			// If required by the server, set the credentials.  
			request.Credentials = CredentialCache.DefaultCredentials;

			// Get the response.  
			WebResponse response = request.GetResponse();
			// Display the status.  
			Console.WriteLine(((HttpWebResponse)response).StatusDescription);

			// Get the stream containing content returned by the server. 
			// The using block ensures the stream is automatically closed. 
			using (Stream dataStream = response.GetResponseStream())
			{ 
				// Open the stream using a StreamReader for easy access.  
				StreamReader reader = new StreamReader(dataStream);
				// Read the content.  
				return reader.ReadToEnd();
			}
		}
	}
}
