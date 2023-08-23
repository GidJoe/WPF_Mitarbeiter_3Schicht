using System.Collections.Generic;
using WPF_Mitarbeiter_3Schicht; // Ensure you've added a reference to the DAL project!

namespace BusinessLayerSec
{
    public class DataAccessLayer
    {
        private readonly WPF_Mitarbeiter_3Schicht.DataAccessLayer _dal;

        public DataAccessLayer(string databasePath)
        {
            _dal = new WPF_Mitarbeiter_3Schicht.DataAccessLayer();
        }

        public List<Mitarbeiter> GetAllMitarbeiter()
        {
                // Passthrough to the DAL schreiben
                // und hier die neuen Mehtoden aufrufen
            return _dal.GetAllMitarbeiter();
        }

                
        //public void RemoveMitarbeiter(Mitarbeiter mitarbeiter)
        //{
        //    _dal.RemoveMitarbeiter(mitarbeiter);
        //}

    }
}
