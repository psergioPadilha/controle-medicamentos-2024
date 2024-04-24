
namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento
    {
        public int IdMedicamento { get; set; }
        public string nomeMedicamento { get; set; }
        public string nomeGenerico { get; set; }
        public string descricao { get; set;}
        public string apresentacao { get; set; }
        public string conteudo { get; set; }
        public string laboratorio { get; set; }

        public Medicamento()
        {

        }

        public Medicamento(string nomeMedicamento, string nomeGenerico, string descricao, string apresentacao,
            string conteudo, string laboratorio)
        {
            this.nomeMedicamento = nomeMedicamento;
            this.nomeGenerico = nomeGenerico;
            this.descricao = descricao;
            this.apresentacao = apresentacao;
            this.conteudo = conteudo;
            this.laboratorio = laboratorio;
        }
    }
}
