using System;

namespace LSport_HomeTask.Models.Giphy
{
    public class Giphy
    {

        public string id { get; set; }
        public string URL { get; set; }
        public string rating { get; set; }
        public string title { get; set; }
        public string type { get; set; }



        public void toString()
        {
            Console.WriteLine("GIF Object : id:" + id + ", type:" + type + ", URL:" + URL + ", rating:" + rating + ", title:" + title);
        }
    }
}
