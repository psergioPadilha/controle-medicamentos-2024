namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = MenuPrincipal();
                VeificaOpcaoMenuPrincipal(opcao);


                Console.ReadKey();
            }
        }

        #region Cabeçalho
        static void Cabecalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("**********        CONTROLE DE MEDICAMENTOS        **********");
            Console.WriteLine("************************************************************");
            Console.WriteLine(titulo);
            Console.WriteLine();
        }
        #endregion

        #region Menu principal
        static string MenuPrincipal()
        {
            Cabecalho("Qual a atividade que deseja realizar?");

            Console.WriteLine("(1)Cadastro\t(2)Consulta\t(3)Excluir\t(4)Alterar\t(5)Entregar Medicamento\t(6)Sair");
            Console.Write("Opção: ");

            return Console.ReadLine();
        }
        #endregion

        #region Valida e verifica a opção de entrada do menu principal
        static void VeificaOpcaoMenuPrincipal(string opcao)
        {
            while ((opcao != "1") && (opcao != "2") && (opcao != "3") && (opcao != "4") && (opcao != "5") && (opcao != "6"))
            {
                Cabecalho("Opção inválida, digite novamente...");

                Console.WriteLine("(1)Cadastro\t(2)Consulta\t(3)Excluir\t(4)Alterar\t(5)Entregar Medicamento\t(6)Sair");
                Console.Write("Opção: ");
            }
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Opção de Cadastro!");
                    break;
                case "2":
                    Console.WriteLine("Opção de Consulta!");
                    break;
                case "3":
                    Console.WriteLine("Opção de Excluir!");
                    break;
                case "4":
                    Console.WriteLine("Opção de Alterar");
                    break;
                case "5":
                    Console.WriteLine("Opção de Entrega de Medicamento!");
                    break;
                default:
                    OpcaoSairDoSistema();
                    break;
            }
        }
        #endregion

        #region
        static bool OpcaoSairDoSistema()
        {
            bool sair = false;
            Cabecalho("Deseja mesmo sair do sistema?");

            Console.WriteLine("(1)Sair\t(2)Continuar");


            return sair;
        }
        #endregion
    }
}
