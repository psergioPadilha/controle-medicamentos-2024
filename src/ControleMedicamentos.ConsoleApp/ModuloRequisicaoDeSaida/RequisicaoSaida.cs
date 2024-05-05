
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    internal class RequisicaoSaida : EntidadeBase
    {
        public Medicamento medicamento { get; set; }
        public Paciente paciente { get; set; }
        public DateTime dataRequisicao { get; set; }
        public int quantidade { get; set; }

        public RequisicaoSaida(Medicamento medicamento, Paciente paciente, int quantidade)
        {
            this.medicamento = medicamento;
            this.paciente = paciente;
            this.quantidade = quantidade;
        }

        public bool RetirarMedicamento()
        {
            if (medicamento.quantidade < quantidade)
                return false;

            medicamento.quantidade -= quantidade;

            return true;
        }
    }
}
