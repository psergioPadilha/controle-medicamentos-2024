
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;
using Microsoft.VisualBasic;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : TelaBase
    {
        #region Formulário de medicamento
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Medicamento: ");
            string medicamento = Console.ReadLine().ToUpper();
            medicamento = ValidarCampoString("medicamento inválido, por favor digite novamente...", "medicamento: ", medicamento);

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine().ToUpper();
            descricao = ValidarCampoString("Descrição inválida, por favor digite novamente...", "Descrição: ", descricao);

            Console.Write("Lote: ");
            string lote = Console.ReadLine().ToUpper();

            Console.Write("Validade: ");
            
            string validade = Console.ReadLine();

            DateTime dataValidade = ValidarDataValidade("Data inválida, por favor digite novamente...", "O paciente vence hoje...",
              "Validade: ", validade);

            Medicamento novoMedicamento = new Medicamento(medicamento, descricao, lote, dataValidade);

            return novoMedicamento;
        }
        #endregion

        #region Valida o campo dataValidade permitindo apenas um valor do tipo data no formato 'dd/MM/yyyy' maior que a data do sistema
        private DateTime ValidarDataValidade(string mensagemUm, string mensagemDois, string campo, string validade)
        {
            DateTime validadeConvertida;
            DateTime hoje = DateTime.Now.Date;

            bool result = DateTime.TryParseExact(validade,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validadeConvertida);
            if (validadeConvertida < hoje)
                result = false;

            while (result == false)
            {
                ExibirMensagem(mensagemUm, ConsoleColor.DarkRed);
                Console.Write(campo);
                validade = Console.ReadLine();
                result = DateTime.TryParseExact(validade, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validadeConvertida);
                if (validadeConvertida < hoje)
                    result = false;
            }
            if (validadeConvertida == hoje)
                ExibirMensagem(mensagemDois, ConsoleColor.DarkYellow);

            return validadeConvertida;
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

        #region Visualiza os registros
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Medicamentos...");
            }

            Console.WriteLine("Lista de medicamentos cadastrados...");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -25} | {2, -30} | {3, -15} | {4, -10} | {5, -5}",
                "ID", "MEDICAMENTO", "DESCRIÇÃO", "LOTE", "VALIDADE", "QUANTIDADE"
            );

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine(
                    "{0, -5} | {1, -25} | {2, -30} | {3, -15} | {4, -10} | {5, -5}",
                    medicamento.Id, medicamento.medicamento, medicamento.descricao, medicamento.lote,
                    medicamento.dataValidade.ToShortDateString(), medicamento.quantidade
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

        #region Exibir mensagem
        private void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.Write(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        #endregion
    }
}
