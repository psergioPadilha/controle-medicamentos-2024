
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.Repositorio
{
    public class RepositorioMedicamento
    {
        private Medicamento[] medicamentos = new Medicamento[5];

        #region Cadastra medicamento no repositório
        public void CadastrarMedicamento(Medicamento medicamento)
        {
            medicamento.IdMedicamento = GeradorId.GerarIdMedicamento();

            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] != null)
                    continue;
                else
                    medicamentos[i] = medicamento;
                break;
            }
        }
        #endregion


        //Método provisório, apenas para alimentar array
        public void CadastrarMedicamento()
        {
            Medicamento medicamento = new Medicamento();

            medicamento.IdMedicamento = GeradorId.GerarIdMedicamento();
            medicamento.nomeMedicamento = "LORATAMED";
            medicamento.nomeGenerico = "LORATADINA";
            medicamento.descricao = "ANTIALÉRGICO";
            medicamento.apresentacao = "10 mg";
            medicamento.conteudo = "12 COMPRIMIDOS";
            medicamento.laboratorio = "CIMED";
            medicamentos[0] = medicamento;

            medicamento = new Medicamento();
            medicamento.IdMedicamento = GeradorId.GerarIdMedicamento();
            medicamento.nomeMedicamento = "BUDECORT AQUA";
            medicamento.nomeGenerico = "BUDEZONIDA";
            medicamento.descricao = "ANTIALÉRGICO";
            medicamento.apresentacao = "64 mcg/DOSE";
            medicamento.conteudo = "120 DOSES";
            medicamento.laboratorio = "ASTRA-ZENECA";
            medicamentos[1] = medicamento;
        }

        #region Lista medicamentos
        public Medicamento[] ListarMedicamentos()
        {
            return medicamentos;
        }
        #endregion

        #region Consulta medicamento
        public Medicamento ConsultarMedicamento(int id)
        {
            Medicamento medicamento = new Medicamento();
            medicamento = null;
            
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] != null)
                {
                    if (medicamentos[i].IdMedicamento == id)
                        medicamento = medicamentos[i];
                    else
                        continue;
                }
                else
                    continue;
            }
            return medicamento;
        }
        #endregion

        #region
        public Medicamento EditarMedicamento(Medicamento medicamento)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;
                if(medicamento.IdMedicamento == medicamentos[i].IdMedicamento)
                {
                    medicamentos[i] = medicamento;
                }
            }

            return medicamento;
        }
        #endregion

        #region Excluir medicamento
        internal void ExcluirMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;
                if (medicamentos[i].IdMedicamento == id)
                {
                    medicamentos[i] = null;
                }
            }
        }
        #endregion
    }
}
