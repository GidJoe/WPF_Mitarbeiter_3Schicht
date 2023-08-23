using WPF_Mitarbeiter_3Schicht;

public class BusinessLayer
{
    private readonly DataAccessLayer _dal;

    public BusinessLayer(string databasePath)
    {
        _dal = new DataAccessLayer(databasePath);
    }

    public List<Mitarbeiter> GetMitarbeiterOlderThan(int age)
    {

        _dal.GetAllMitarbeiter();
        var allMitarbeiter = _dal.GetAllMitarbeiter();
        return allMitarbeiter.Where(m => m.Alter > age).ToList();
    }
}