using System.ComponentModel.DataAnnotations.Schema;

namespace Gran_Prix.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string Codigo { get; set; }
        public int Fornecedor_Id { get; set; }
        public FornecedorModel? Fornecedor { get; set; }
    }
}
