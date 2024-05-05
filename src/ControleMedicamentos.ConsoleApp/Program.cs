using ControleMedicamentos.ConsoleApp.ModuloCompartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal tealaPrincipal = new TelaPrincipal();

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.tipoEntidade = "Medicamentos";

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Pacientes";

            TelaRequisicaoSaida telaREquisicaoSaida = new TelaRequisicaoSaida();
            telaREquisicaoSaida.tipoEntidade = "Requisição de Saída";

            while (true)
            {
                //apresenta o menu da tela principal e retorna um valor do tipo char já validado
                char opcaoMenuPrincipal = tealaPrincipal.MenuPrincipal();

                //verifica se o valor de retorno indica a opção de saída do sistema, se sim cham a mensagem de confirmação de saída
                if ((opcaoMenuPrincipal == 's') || (opcaoMenuPrincipal == 'S'))
                    //confirmação de saída do sistema, se o retorno for verdadeiro encerra a aplicação
                    if(tealaPrincipal.ExibirMensagemConfimacao("Deseja mesmo sair do sistema?", ConsoleColor.DarkMagenta))
                        Environment.Exit(0);

                //caso não seja encerrada a plicação segue verificando qual item de menu o usuário escolheu
                TelaBase telaBase = null;

                if (opcaoMenuPrincipal == '1')
                    telaBase = telaMedicamento;

                else if (opcaoMenuPrincipal == '2')
                    telaBase = telaPaciente;
                else if (opcaoMenuPrincipal == '3')
                    telaBase = telaREquisicaoSaida;

                //de acordo com o menu uma instância do objeto tela é criada e um novo menu é apresentado ao usuário
                char opcaoMenuEntidade = telaBase.MenuPrincipal();

                //se o valor de retorno do menu for 'v' ou 'V' o sistema volta ao menu principal se não segue analizando as opções
                if ((opcaoMenuEntidade == 'v') || (opcaoMenuEntidade == 'V'))
                    continue;

                if (opcaoMenuEntidade == '1')
                    telaBase.Registrar();

                else if (opcaoMenuEntidade == '2')
                    telaBase.Editar();

                else if (opcaoMenuEntidade == '3')
                    telaBase.Excluir();

                else if (opcaoMenuEntidade == '4')
                    telaBase.VisualizarRegistros(true);
            }
        }
    }
}
