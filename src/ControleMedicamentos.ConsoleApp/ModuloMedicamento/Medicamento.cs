
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        public string medicamento { get; set; }
        public string descricao { get; set; }
        public string lote { get; set; }
        public DateTime dataValidade { get; set; }
        public int quantidade { get; set; } = 5;

        public Medicamento(string nome, string descricao, string lote, DateTime dataValidade)
        {
            this.medicamento = nome;
            this.descricao = descricao;
            this.lote = lote;
            this.dataValidade = dataValidade;
        }
    }
}
