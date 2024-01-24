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

            AlvarezConnection.CreateTable<AlvarezGatosViewsModels>();
        }

        public void AlvarezAdd(AlvarezGato newGato)
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
        
        public List<AlvarezGato> GetAll()
        {
            return AlvarezConnection.Table<AlvarezGato>().ToList();
        }
        public AlvarezGato Get(int id)
        {
            return AlvarezConnection.Table<AlvarezGato>().FirstOrDefault();
        }
    }
}
