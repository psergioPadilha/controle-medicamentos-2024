
using System.Globalization;
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : TelaBase
    {
        #region Formulário de medicamento
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Paciente: ");
            string nomePaciente = Console.ReadLine().ToUpper();
            nomePaciente = ValidarCampoString("medicamento inválido, por favor digite novamente...", "paciente: ", nomePaciente);

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine().ToUpper();
            telefone = ValidarCampoNumero("Descrição inválida, por favor digite novamente...", "Telefone: ", telefone);

            Console.Write("Nº SUS: ");
            string cartaoSus = Console.ReadLine().ToUpper();
            cartaoSus = ValidarCampoNumero("Descrição inválida, por favor digite novamente...", "Nº SUS: ", cartaoSus);

            
            Paciente novoPaciente = new Paciente(nomePaciente, telefone, cartaoSus);

            return novoPaciente;
        }
        #endregion

        #region Valida o campo que deve receber uma string, permitindo apenas letras e certificando-se de que o campo não vai ficar em branco
        private string ValidarCampoString(string mensagem, string campo, string valorCampo)
        {
            while ((valorCampo.All(char.IsDigit)) || (string.IsNullOrEmpty(valorCampo.Trim())))
            {
                ExibirMensagem("Opção inválida, por favor digite novamente...", ConsoleColor.DarkRed);
                Console.Write(campo);
                valorCampo = Console.ReadLine();
            }

            return valorCampo;
        }
        #endregion

        #region Valida o campo que deve receber um número, permitindo apenas números e certificando-se de que o campo não vai ficar em branco
        private string ValidarCampoNumero(string mensagem, string campo, string valorCampo)
        {
            while ((!valorCampo.All(char.IsDigit)) || (string.IsNullOrEmpty(valorCampo.Trim())) || (valorCampo.Length != 11))
            {
                ExibirMensagem("Opção inválida, por favor digite novamente...", ConsoleColor.DarkRed);
                Console.Write(campo);
                valorCampo = Console.ReadLine();
            }

            return valorCampo;
        }
        #endregion

        #region Visualiza os registros
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Pacientes...");
            }

            Console.WriteLine("Lista de pacientes cadastrados...");
            Console.WriteLine();

            Console.WriteLine
            (
                "{0, -5} | {1, -35} | {2, -15} | {3, -15}",
                "ID", "PACIENTE", "TELEFONE", "CARTÃO DO SUS"
            );

            EntidadeBase[] pacientesCadastrados = repositorio.SelecionarTodos();

            foreach (Paciente paciente in pacientesCadastrados)
            {
                if (paciente == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -5} | {1, -35} | {2, -15} | {3, -15}",
                    paciente.Id, paciente.paciente, paciente.telefone, paciente.cartaoSus
                );
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion

        #region Editar
        public override void Editar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Editar {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine($"Digite o ID do {tipoEntidade} que deseja editar!");
            Console.Write("ID: ");
            string idEntidade = Console.ReadLine();
            int idEntidadeEscolhida = VerificarIdValido(idEntidade);

            if (!repositorio.Existe(idEntidadeEscolhida))
            {
                ExibirMensagem($"O {tipoEntidade} não foi encontrado!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            bool conseguiuEditar = repositorio.Editar(idEntidadeEscolhida, entidade);

            ExibirMensagem($"O {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
        }
        #endregion

        private void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.Write(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
