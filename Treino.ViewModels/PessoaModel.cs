using System.Collections.Generic;

namespace Treino.ViewModels
{
    public class PessoaModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string eye_color { get; set; }
        public string hair_color { get; set; }
        public List<string> films { get; set; }
        public ICollection<FilmeModel> filmesModel { get; set; }
        public EspecieModel especieModel { get; set; }
        public string species { get; set; }
        public string url { get; set; }

        //criado para comparar idade
        public int idade { get; set; }
        public PessoaModel()
        {
            filmesModel = new List<FilmeModel>();
        }
    }
}
