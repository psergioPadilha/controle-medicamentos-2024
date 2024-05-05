
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class Paciente : EntidadeBase
    {
        public string paciente { get; set; }
        public string telefone { get; set; }
        public string cartaoSus { get; set; }

        public Paciente(string paciente, string telefone, string cartaoSus)
        {
            this.paciente = paciente;
            this.telefone = telefone;
            this.cartaoSus = cartaoSus;
        }
    }
}
