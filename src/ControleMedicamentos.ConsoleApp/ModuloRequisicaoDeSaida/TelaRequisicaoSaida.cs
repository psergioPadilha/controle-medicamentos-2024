
using System.Drawing;
using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    internal class TelaRequisicaoSaida : TelaBase
    {
        public TelaPaciente telaPaciente = null;
        public TelaMedicamento telaMedicamento = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioMedicamento repositorioMedicamento = null;

        #region Registro
        public override void Registrar()
        {
            ApresentarCabecalho();
            Console.WriteLine($"Cadastro de {tipoEntidade}...");
            Console.WriteLine();

            RequisicaoSaida entidade = (RequisicaoSaida)ObterRegistro();

            bool conseguiRegistrar = entidade.RetirarMedicamento();

            if (!conseguiRegistrar)
            {
                ExibirMensagem("Quantidade de medicamento solicitada não está dispoível!", ConsoleColor.DarkRed);
                return;
            }
            repositorio.Cadastrar(entidade);
            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.DarkGreen);
        }
        #endregion

        #region Visualização de registros de saída de medicamentos
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();
                Console.WriteLine("Visualizar requisições de saída...");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
                "{0, -5} | {1, -25} | {2, -30} | {3, -15} | {4, -5}",
                "ID", "MEDICAMENTO", "PACIENTE", "DATA DA REQUISIÇÃO", "QUANTIDADE"
            );
            Console.ResetColor();
            
            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoSaida requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -5} | {1, -25} | {2, -30} | {3, -15} | {4, -5}",
                    requisicao.Id,
                    requisicao.medicamento.medicamento,
                    requisicao.paciente.paciente,
                    requisicao.dataRequisicao.ToShortDateString(),
                    requisicao.quantidade
                );
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        protected override EntidadeBase ObterRegistro()
        {
            //telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            telaPaciente.VisualizarRegistros(false);

            Console.Write("Digite o ID do paciente requisitante: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteSelecionado = (Paciente)repositorioPaciente.SelecionarPorId(idPaciente);

            Console.Write("Digite a quantidade do medicamente que deseja retirar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida novaRequisicao = new RequisicaoSaida(medicamentoSelecionado, pacienteSelecionado, quantidade);

            return novaRequisicao;
        }
    }
}
