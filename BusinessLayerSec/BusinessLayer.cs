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
            // Here, you could potentially add any business rules or transformations
            // before returning the data to the UI. For now, we're simply retrieving 
            // the data from the DAL and passing it through.
            return _dal.GetAllMitarbeiter();
        }

        // Similarly, add methods for Create, Update, Delete, etc., and make sure to
        // add the appropriate business logic or rules in these methods, if needed.
    }
}
