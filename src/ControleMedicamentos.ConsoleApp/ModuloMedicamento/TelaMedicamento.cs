
using ControleMedicamentos.ConsoleApp.Repositorio;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento
    {
        public static RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();

        #region Cabeçalho
        static void Cabecalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("**********        CONTROLE DE MEDICAMENTOS        **********");
            Console.WriteLine("************************************************************");
            Console.WriteLine(titulo);
        }
        #endregion

        #region Menu
        public static void Menu()
        {
            Cabecalho("Medicamentos");
            Console.WriteLine();

            Console.WriteLine("(1)Cadastar;");
            Console.WriteLine("(2)Consultar;");
            Console.WriteLine("(3)Editar;");
            Console.WriteLine("(4)Excluir;");
            Console.WriteLine("(5)Voltar.");
            Console.WriteLine();
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            VerificaOpcaoMenu(opcao);
        }
        #endregion

        #region Verifica e valida opção de menu
        static void VerificaOpcaoMenu(string opcao)
        {
            while ((opcao != "1") && (opcao != "2") && (opcao != "3") && (opcao != "4") && (opcao != "5"))
            {
                Cabecalho("");
                Console.Write("Opção inválida, digite novamente...");
                Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("(1)Cadastar;");
                Console.WriteLine("(2)Consultar;");
                Console.WriteLine("(3)Editar;");
                Console.WriteLine("(4)Excluir;");
                Console.WriteLine("(5)Voltar.");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            switch (opcao)
            {
                case "1":
                    CadastrarMedicamento();
                    break;
                case "2":
                    ConsultarMedicamento();
                    break;
                case "3":
                    Cabecalho("Editar Medicamento!");
                    break;
                case "4":
                    Cabecalho("Excluir Medicamento!");
                    break;
                case "5":
                    Program.MenuPrincipal();
                    break;
            }
        }
        #endregion


        private static void ConsultarMedicamento()
        {
            Cabecalho("Lista de Medicamentos!");

            Console.WriteLine
            (
                "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                "Id", "Medicamento", "Genérico", "Descrição", "Apresentação", "Quantidade", "Laboratório"
            );

            Medicamento[] cadastroDeMedicamentos = repositorioMedicamento.ListarMedicamentos();

            for (int i = 0; i < cadastroDeMedicamentos.Length; i++)
            {
                Medicamento novoMedicamento = cadastroDeMedicamentos[i];

                if (novoMedicamento == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                    novoMedicamento.IdMedicamento, novoMedicamento.nomeMedicamento, novoMedicamento.nomeGenerico, novoMedicamento.descricao,
                    novoMedicamento.apresentacao, novoMedicamento.conteudo, novoMedicamento.laboratorio
                );
            }
            Console.ReadLine();
        }

        #region Cadastro de medicamento
        public static void CadastrarMedicamento()
        {
            //Cabecalho("Cadastro de Medicamento!");
            //Console.WriteLine();

            //Console.Write("Nome: ");
            //string nomeMedicamento = Console.ReadLine();

            //Console.Write("Nome Genérico: ");
            //string nomeGenerico = Console.ReadLine();

            //Console.Write("Descrição: ");
            //string descricao = Console.ReadLine();

            //Console.Write("Apresentação: ");
            //string apreseentacao = Console.ReadLine();

            //Console.Write("Quantidade: ");
            //string conteudo = Console.ReadLine();

            //Console.Write("Laboratório: ");
            //string laboratorio = Console.ReadLine();

            //Medicamento medicamento = new Medicamento(nomeMedicamento, nomeGenerico, descricao, apreseentacao, conteudo, laboratorio);
            //repositorioMedicamento.CadastrarMedicamento(medicamento);
            //Program.ExibirMensagem("Medicamento cadastrado com sucesso!", ConsoleColor.Green);

            repositorioMedicamento.CadastrarMedicamento();
        }
        #endregion
    }
}
