using System.Collections.Generic;

namespace Treino.ViewModels.ViewModels
{
    public class VeiculoViewModel
    {
        public IEnumerable<VeiculoModel> ListaVeiculos { get; set; }
        public IEnumerable<FilmeModel> ListaFilme { get; set; }
        public PessoaModel Pessoa { get; set; }

    }
}
