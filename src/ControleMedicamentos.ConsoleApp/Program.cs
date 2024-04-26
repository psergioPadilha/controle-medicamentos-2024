using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.Repositorio;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                string opcao = MenuPrincipal();

                VeificaOpcaoMenuPrincipal(opcao);
            }
        }

        #region Cabeçalho
        static void Cabecalho(string titulo)
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("**********        CONTROLE DE MEDICAMENTOS        **********");
            Console.WriteLine("************************************************************");
            Console.WriteLine();
            Console.WriteLine(titulo);
        }
        #endregion

        #region Menu principal
        public static string MenuPrincipal()
        {
            Cabecalho("Digite a opção que desejar!");
            Console.WriteLine();

            Console.WriteLine("(1)Medicamento;");
            Console.WriteLine("(2)Paciente;");
            Console.WriteLine("(3)Entregar Medicamentos;");
            Console.WriteLine("(4)Sair.");
            Console.WriteLine();
            Console.Write("Opção: ");

            return Console.ReadLine();
        }
        #endregion

        #region Valida e verifica a opção de entrada do menu principal
        static void VeificaOpcaoMenuPrincipal(string opcao)
        {
            while ((opcao != "1") && (opcao != "2") && (opcao != "3") && (opcao != "4"))
            {
                Cabecalho("");
                Console.Write("Opção inválida, digite novamente...");
                Console.ReadLine();
                Cabecalho("Digite a opção que desejar!");
                Console.WriteLine();

                Console.WriteLine("(1)Medicamento;");
                Console.WriteLine("(2)Paciente;");
                Console.WriteLine("(3)Entregar Medicamentos;");
                Console.WriteLine("(4)Sair.");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            switch (opcao)
            {
                case "1":
                    TelaMedicamento.Menu();
                    break;
                case "2":
                    Cabecalho("Opção de Paciente!");
                    break;
                case "3":
                    Cabecalho("Opção de Entregar Medicamento!");
                    break;
                case "4":
                    OpcaoSairDoSistema();
                    break;
            }
        }
        #endregion

        #region Valida e verifica a confirmação de sair do sistema
        static void OpcaoSairDoSistema()
        {
            Console.WriteLine();
            Cabecalho("Deseja mesmo sair do sistema?");
            Console.WriteLine();

            Console.WriteLine("(1)Sair\t\t(2)Continuar");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            while ((opcao != "1") && (opcao != "2"))
            {
                Cabecalho("");
                Console.Write("Opção inválida, digite novamente...");
                Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("(1)Sair\t\t(2)Continuar");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            switch (opcao)
            {
                case "1":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Mesnsagem
        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
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
