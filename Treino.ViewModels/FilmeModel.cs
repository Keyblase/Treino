using System.Collections.Generic;

namespace Treino.ViewModels
{
    public class FilmeModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string original_title_romanised { get; set; }
        public string description { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string running_time { get; set; }
        public string rt_score { get; set; }
        public List<string> people { get; set; }
        public List<string> species { get; set; }
        public List<string> locations { get; set; }
        public List<string> vehicles { get; set; }
        public string url { get; set; }
    }
}
