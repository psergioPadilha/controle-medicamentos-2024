
namespace ControleMedicamentos.ConsoleApp.ModuloCompartilhado
{
    public class CabecalhoGeral
    {
        public string tipoEntidade;

        #region Cabecalho
        public void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("##################################################");
            Console.WriteLine("#######      CONTROLE DE MEDICAMENTOS      #######");
            Console.WriteLine("##################################################");
            Console.WriteLine($"{tipoEntidade}");
            Console.WriteLine();
        }
        #endregion
    }
}
