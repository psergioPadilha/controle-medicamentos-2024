

using System;
using System.Runtime.ConstrainedExecution;

namespace ControleMedicamentos.ConsoleApp.ModuloCompartilhado
{
    internal abstract class TelaBase
    {
        public CabecalhoGeral cabecalho = new CabecalhoGeral();
        public string tipoEntidade = "";

        //public RepositorioBase repositorio = null; Apresentava erro no método Registrar() na linha - repositorio.Registrar(entidade);
        //Mudei o código e tive que mudar a classe RepositorioBase retirando o abstract da assinatura da classe
        public RepositorioBase repositorio = new RepositorioBase();

        #region Cabecalho
        public void ApresentarCabecalho()
        {
            cabecalho.tipoEntidade = tipoEntidade;
            cabecalho.Cabecalho();
        }
        #endregion

        #region Menu principal
        public char MenuPrincipal()
        {
            ApresentarCabecalho();

            Console.WriteLine($"(1) Registrar {tipoEntidade}");
            Console.WriteLine($"(2) Editar {tipoEntidade}");
            Console.WriteLine($"(3) Excluir {tipoEntidade}");
            Console.WriteLine($"(4) Visualizar {tipoEntidade}s");
            Console.WriteLine();
            Console.WriteLine("(V) Voltar");
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
            while ((opcaoEntrada != "v") && (opcaoEntrada != "V") &&
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

        #region Exibe mensagem
        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.Write(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        #endregion

        #region Cadastrar
        public virtual void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastro de {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            /////////////////////////////////////
            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }
        #endregion

        #region Excluir entidade
        public void Excluir()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Excluindo {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine($"Digite o ID do {tipoEntidade} que deseja excluir!");
            Console.Write("ID: ");
            string idEntidade = Console.ReadLine();
            int idEntidadeEscolhida = VerificarIdValido(idEntidade);

            if (!repositorio.Existe(idEntidadeEscolhida))
            {
                ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idEntidadeEscolhida);

            if (!conseguiuExcluir)
            {
                ExibirMensagem($"Houve um erro durante a exclusão do {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O {tipoEntidade} foi excluído com sucesso!", ConsoleColor.Green);
        }
        #endregion

        protected void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        protected int VerificarIdValido(string id)
        {
            while (!id.All(char.IsDigit))
            {
                ExibirMensagem("Valor do ID inválido, por favor digite novamente...", ConsoleColor.DarkRed);
                Console.Write("ID: ");
                id = Console.ReadLine();
            }
            int idValido = int.Parse(id);

            return idValido;
        }

        protected abstract EntidadeBase ObterRegistro();

        public abstract void VisualizarRegistros(bool exibirTitulo);

        public abstract void Editar();
    }
}
