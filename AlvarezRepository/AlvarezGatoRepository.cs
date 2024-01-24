using AlvarezExamenProgreso3.AlvarezModels;
using AlvarezExamenProgreso3.AlvarezViewModels;
using Microsoft.VisualBasic;
using SQLite;


namespace AlvarezExamenProgreso3.AlvarezRepository
{
    public class AlvarezGatoRepository
    {
        SQLiteConnection AlvarezConnection;
        private string StatusMessageAlvarez;

        public AlvarezGatoRepository()
        {
            AlvarezConnection = new SQLiteConnection(AlvarezConstants.DatabasePath, AlvarezConstants.Flags);

            AlvarezConnection.CreateTable<AlvarezGato.Root>();
        }

        public void AlvarezAdd(AlvarezGato.Root newGato)
        {
            try
            {
                AlvarezConnection.Insert(newGato);
                StatusMessageAlvarez = $"Se agrego un nuevo gato";
            }
            catch
            {

                StatusMessageAlvarez = $"Lastima no se agrego un nuevo gato";
            }
        }

        public void AlvarezUpdate(AlvarezGato.Root newGato)
        {
            try
            {
                if (newGato.id == "0")
                {
                    AlvarezConnection.Update(newGato);
                    StatusMessageAlvarez = $"Se actualizo el gato";
                }
               
            }
            catch
            {

                StatusMessageAlvarez = $"Lastima no se actualizo el gato";
            }
        }

        public void AlvarezDelete(string id)
        {
            var gato = Get(id);
            AlvarezConnection.Delete(gato);
        }

        public List<AlvarezGato> GetAll()
        {
            return AlvarezConnection.Table<AlvarezGato>().ToList();
        }
        public AlvarezGato Get(string id)
        {
            return AlvarezConnection.Table<AlvarezGato>().FirstOrDefault();
        }
    }
}
