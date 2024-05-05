


namespace ControleMedicamentos.ConsoleApp.ModuloCompartilhado
{
    public class TelaPrincipal
    {
        public CabecalhoGeral cabecalho = new CabecalhoGeral();

        #region Apresenta menu principal
        public char MenuPrincipal()
        {
            cabecalho.tipoEntidade = "Menu principal";
            cabecalho.Cabecalho();
            Console.WriteLine("(1) Medicamentos");
            Console.WriteLine("(2) Pacientes");
            Console.WriteLine("(3) Requisição de saída");
            Console.WriteLine();
            Console.WriteLine("(S) Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcaoEntrada = Console.ReadLine();
            char opcao = ValidarOpcao(opcaoEntrada);

            return opcao;
        }
        #endregion

        #region Valida a opção do menu principal
        private char ValidarOpcao(string opcaoEntrada)
        {
            while 
                ((opcaoEntrada != "s") && (opcaoEntrada != "S") && 
                (opcaoEntrada != "1") && (opcaoEntrada != "2") &&
                (opcaoEntrada != "3") && (opcaoEntrada != "4")
                )
            {
                ExibirMensagem("Opção inválida, por favor digite novamente...", ConsoleColor.DarkRed);
                opcaoEntrada = MenuPrincipal().ToString();
            }

            char opcao = char.Parse(opcaoEntrada);

            return opcao;
        }
        #endregion

        #region Mensagem de aviso sem retorno
        private void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.Write(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        #endregion

        #region Mensagem de aviso com retorno
        public bool ExibirMensagemConfimacao(string mensagem, ConsoleColor cor)
        {
            cabecalho.Cabecalho();

            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.Write(mensagem);
            Console.ResetColor();
            Console.ReadLine();
            Console.WriteLine("(1)SIM\t\t(2)NÃO");
            Console.WriteLine();
            Console.Write("Opção: ");
            string opcaoEntrada = Console.ReadLine();

            char opcao = ValidarOpcaoConfirmacao(opcaoEntrada);

            if (VerificarOpcaoConfirmacao(opcao))
                return true;
            else
                return false;
        }
        #endregion

        #region Validar opção de confirmação
        private char ValidarOpcaoConfirmacao(string opcaoEntrada)
        {
            while ((opcaoEntrada != "1") && (opcaoEntrada != "2"))
            {
                ExibirMensagem("Opção inválida, por favor digite novamente...", ConsoleColor.DarkRed);
                opcaoEntrada = MenuPrincipal().ToString();
            }

            char opcao = char.Parse(opcaoEntrada);

            return opcao;
        }
        #endregion

        #region Verificação de confirmação
        private bool VerificarOpcaoConfirmacao(char opcao)
        {
            bool confirmacao = false;
            if(opcao == '1')
                confirmacao = true;
            
            return confirmacao;
        }
        #endregion
    }
}
