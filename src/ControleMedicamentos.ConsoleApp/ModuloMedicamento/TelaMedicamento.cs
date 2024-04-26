
using System.Reflection.Metadata.Ecma335;
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
                    MenuEditarMedicamento();
                    break;
                case "4":
                    MunuExcluirMedicamento();
                    break;
                case "5":
                    Program.MenuPrincipal();
                    break;
            }
        }
        #endregion

        #region Excluir medicamento
        static void MunuExcluirMedicamento()
        {
            Cabecalho("Excluir medicamento!");
            Console.WriteLine();
            ListaMedicamentos();
            Console.WriteLine();
            Console.WriteLine("Deseja excluir medicamento?");
            Console.WriteLine("(1)SIM\t(2)NÃO");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            if (VerificaOpcaoSimNao(opcao))
            {
                Console.WriteLine();
                Console.WriteLine("Digite o ID do medicamento que deseja excluir!");
                Console.WriteLine();
                Console.Write("ID do medicamento: ");
                string idMedicamento = Console.ReadLine();

                int id = VerificarValidarIdMedicamento(idMedicamento);

                Medicamento medicamento = new Medicamento();
                medicamento = repositorioMedicamento.ConsultarMedicamento(id);

                medicamento = VerificarIdCadastrado(medicamento);

                Cabecalho("Medicamento");

                Console.WriteLine();
                Console.WriteLine
                (
                    "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                    "Id", "Medicamento", "Genérico", "Descrição", "Apresentação", "Conteúdo", "Laboratório"
                );
                Console.WriteLine
                (
                    "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                    medicamento.IdMedicamento, medicamento.nomeMedicamento, medicamento.nomeGenerico, medicamento.descricao,
                    medicamento.apresentacao, medicamento.conteudo, medicamento.laboratorio
                );

                Console.WriteLine();
                Console.WriteLine("Excluir medicamento " + medicamento.nomeMedicamento + "?");
                Console.WriteLine("(1)SIM\t(2)NÂO");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                if (VerificaOpcaoSimNao(opcao))
                {
                    repositorioMedicamento.ExcluirMedicamento(id);
                    Program.ExibirMensagem("Medicamento 'EXCLUÍDO' com sucesso!", ConsoleColor.Green);
                    MunuExcluirMedicamento();
                }
                else
                    MunuExcluirMedicamento();
            }
            else
                Menu();
        }
        #endregion

        #region Verifica opção Sim ou Não
        private static bool VerificaOpcaoSimNao(string opcao)
        {
            while ((opcao != "1") && (opcao != "2"))
            {
                Console.WriteLine();
                Console.Write("Opção inválida, por favor digite novamente...");
                Console.ReadLine();

                Cabecalho("Excluir medicamento!");
                Console.WriteLine();
                ListaMedicamentos();
                Console.WriteLine();
                Console.WriteLine("Deseja excluir medicamento?");
                Console.WriteLine("(1)SIM\t(2)NÃO");
                Console.WriteLine();
                Console.WriteLine("Opção: ");
                opcao = Console.ReadLine();
            }
            if(opcao == "1")
                return true;
            else
                return false;
        }
        #endregion

        #region Cadastro de novo medicamento
        public static void CadastrarMedicamento()
        {
            //Cabecalho("Cadastro de Medicamento!");
            //Console.WriteLine();

            //Console.Write("Nome: ");
            //string descricao = Console.ReadLine();

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

            //Medicamento medicamento = new Medicamento(descricao, nomeGenerico, descricao, apreseentacao, conteudo, laboratorio);
            //repositorioMedicamento.CadastrarMedicamento(medicamento);

            repositorioMedicamento.CadastrarMedicamento();
            Program.ExibirMensagem("Medicamento cadastrado com sucesso!", ConsoleColor.Green);
            Menu();
        }
        #endregion

        #region Consulta de medicamentos
        private static void ConsultarMedicamento()
        {
            Cabecalho("Lista de Medicamentos!");
            Console.WriteLine();

            ListaMedicamentos();
            
            Console.WriteLine("(1)Menu Medicamentos\t(2)Menu Inicial");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            VerificaOpcaoMenuConsulta(opcao);
        }
        #endregion

        #region Verifica e valida a opcao do menu de consulta
        static void VerificaOpcaoMenuConsulta(string opcao)
        {
            while ((opcao != "1") && (opcao != "2"))
            {
                Console.Write("Opção inválida, digite novamente...");
                Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("(1)Menu Medicamentos\t(2)Menu Inicial");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            switch (opcao)
            {
                case "1":
                    Menu();
                    break;
                case "2":
                    Program.MenuPrincipal();
                    break;
            }
        }
        #endregion

        #region Menu edita medicamento
        static void MenuEditarMedicamento()
        {
            Cabecalho("Lista de Medicamentos!");
            Console.WriteLine();

            ListaMedicamentos();

            Console.WriteLine();
            Console.WriteLine("(1)Editar\t(2)Voltar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            opcao = VerificaOpcaoMenuEditar(opcao);

            if(opcao == "1")
            {
                Console.WriteLine();
                Console.WriteLine("Digite o ID do medicamento que deseja editar!");
                Console.WriteLine();
                Console.Write("ID do medicamento: ");
                string idMedicamento = Console.ReadLine();

                int id = VerificarValidarIdMedicamento(idMedicamento);

                Medicamento medicamento = new Medicamento();
                medicamento = repositorioMedicamento.ConsultarMedicamento(id);

                medicamento = VerificarIdCadastrado(medicamento);

                Cabecalho("Medicamento");

                Console.WriteLine();
                Console.WriteLine
                (
                    "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                    "Id", "Medicamento", "Genérico", "Descrição", "Apresentação", "Conteúdo", "Laboratório"
                );
                Console.WriteLine
                (
                    "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                    medicamento.IdMedicamento, medicamento.nomeMedicamento, medicamento.nomeGenerico, medicamento.descricao,
                    medicamento.apresentacao, medicamento.conteudo, medicamento.laboratorio
                );

                Console.WriteLine();
                Console.WriteLine("Editar medicamento?");
                Console.WriteLine("(1)SIM\t(2)NÂO");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                while ((opcao != "1") && (opcao != "2"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida, por favor digite novamente");
                    Console.WriteLine("(1)SIM\t(2)NÂO");
                    Console.WriteLine();
                    Console.Write("Opção: ");
                    opcao = Console.ReadLine();
                }

                if (opcao == "1")
                {
                    medicamento = FormularioEditarMedicamento(medicamento);
                    Program.ExibirMensagem("Cadastro medicamento 'ALTERADO' com sucesso!", ConsoleColor.Green);
                    MenuEditarMedicamento();
                }
                if (opcao == "2")
                    MenuEditarMedicamento();
            }

            if (opcao == "2")
                Menu();
        }
        #endregion

        #region Formulário edita medicamento
        private static Medicamento FormularioEditarMedicamento(Medicamento medicamento)
        {
            Cabecalho("Formulário de edição de medicamento!");
            Console.WriteLine();
            
            Console.WriteLine("Deseja editar o campo 'Medicamento'?");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Medicamneto: ");
                string nomeMedicamento = Console.ReadLine();
                medicamento.nomeMedicamento = nomeMedicamento;
            }

            Cabecalho("Formulário de edição de medicamento!");
            Console.WriteLine();

            Console.WriteLine("Deseja editar o campo 'Genérico?'");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Genérico: ");
                string nomeGenérico = Console.ReadLine();
                medicamento.nomeGenerico = nomeGenérico;
            }

            Console.WriteLine("Deseja editar o campo 'Descrição'?");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();
                medicamento.descricao = descricao;
            }

            Console.WriteLine("Desja editar o campo 'Apresentação'?");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Apresentação: ");
                string apresentacao = Console.ReadLine();
                medicamento.apresentacao = apresentacao;
            }

            Console.WriteLine("Deseja editar o campo 'Conteúdo'?");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Conteúdo: ");
                string conteudo = Console.ReadLine();
                medicamento.conteudo = conteudo;
            }

            Console.WriteLine("Deseja editar o campo 'Laboratório'?");
            Console.WriteLine("(1)SIM\t(2)NÂO");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();
            opcao = VerificarOpcaoDoFormularioEditarMedicamento(opcao);

            if (opcao == "1")
            {
                Console.Write("Laboratório: ");
                string laboratorio = Console.ReadLine();
                medicamento.laboratorio = laboratorio;
            }

            return medicamento;
        }
        #endregion

        #region Verifica, valida e retorna a opção do formulário de editar medicamento
        private static string VerificarOpcaoDoFormularioEditarMedicamento(string opcao)
        {
            while ((opcao != "1") && (opcao != "2"))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida, por favor diigte novamente!");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            return opcao;
        }
        #endregion

        #region Veririca e valida o id do medicamento e retorna o medicamento
        private static Medicamento VerificarIdCadastrado(Medicamento medicamento)
        {
            while (medicamento == null)
            {
                Console.Write("O ID solicitado não foi encontrado nos registros...");
                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Digite o ID do medicamento que deseja editar!");
                Console.Write("ID: ");
                string idMedicamento = Console.ReadLine();

                int id = VerificarValidarIdMedicamento(idMedicamento);

                medicamento = new Medicamento();
                medicamento = repositorioMedicamento.ConsultarMedicamento(id);

            }
            return medicamento;
        }
        #endregion

        #region Verifica, valida e retorna o id do medicamento
        private static int VerificarValidarIdMedicamento(string idMedicamento)
        {
            int id = 0;

            while ((!idMedicamento.All(char.IsDigit)) || (idMedicamento.Length == 0))
            {
                Console.WriteLine();
                Console.WriteLine("ID inválido, por favor diigte novamente!");
                Console.WriteLine();
                Console.Write("ID do medicamento: ");
                idMedicamento = Console.ReadLine();
            }
            
            id = int.Parse(idMedicamento);

            return id;
        }
        #endregion

        #region Verifica e valida a opção do menu editar
        private static string VerificaOpcaoMenuEditar(string opcao)
        {
            while ((opcao != "1") && (opcao != "2"))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida, por favor diigte novamente!");
                Console.WriteLine();
                Console.WriteLine("(1)Editar\t(2)Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }

            return opcao;
        }
        #endregion

        #region Lista de medicamentos
        private static void ListaMedicamentos()
        {
            Console.WriteLine
                        (
                            "{0, -5} | {1, -15} | {2, -15} | {3, -15} | {4, -15} | {5, -15} | {6, -10}",
                            "Id", "Medicamento", "Genérico", "Descrição", "Apresentação", "Conteúdo", "Laboratório"
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
            Console.WriteLine();
        }
        #endregion

    }
}
