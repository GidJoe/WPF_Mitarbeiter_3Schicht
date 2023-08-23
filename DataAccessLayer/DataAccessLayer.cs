using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WPF_Mitarbeiter_3Schicht
{
    public class DataAccessLayer
    {
        private readonly string _connectionString;

        public DataAccessLayer()
        {
            _connectionString = @"Data Source=C:\Users\marc1\source\repos\WPF_Mitarbeiter_3Schicht\DataAccessLayer\Mitarbeiter.db;";
        }

        public List<Mitarbeiter> GetAllMitarbeiter()
        {
            var mitarbeiters = new List<Mitarbeiter>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Mitarbeiter";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var mitarbeiter = new Mitarbeiter
                        {
                            MID = reader.GetInt32(0),
                            Vorname = reader.GetString(1),
                            Nachname = reader.GetString(2),
                            Geburtstag = reader.GetString(3),
                            Age = reader.GetInt32(4),
                            Strasse = reader.GetString(5),
                            Hausnummer = reader.GetString(6),
                            Urlaubstage = reader.GetDouble(7),
                            Krankheitstage = reader.GetInt32(8),
                            Gehalt = reader.GetDouble(9),
                            Krankenkasse = reader.GetString(10),
                            Parkplatz = reader.GetString(11),
                            Steuerklasse = reader.GetString(12)
                        };

                        mitarbeiters.Add(mitarbeiter);
                    }
                }
            }

            return mitarbeiters;
        }

        // Add methods for Create, Update, Delete, etc., as needed.
    }
}
