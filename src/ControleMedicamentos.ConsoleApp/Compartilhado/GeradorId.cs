
namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class GeradorId
    {
        private static int idMedicamento = 0;

        public static int GerarIdMedicamento()
        {
            return ++ idMedicamento;
        }

    }
}
