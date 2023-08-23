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
            _connectionString = @"Data Source=C:\Users\MWB\Source\Repos\GidJoe\WPF_Mitarbeiter_3Schicht\DataAccessLayer\Mitarbeiter.db;";
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

        public void AddMitarbeiter(Mitarbeiter mitarbeiter)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Mitarbeiter (Vorname, Nachname, Geburtstag, Age, Strasse, Hausnummer, 
                             Urlaubstage, Krankheitstage, Gehalt, Krankenkasse, Parkplatz, Steuerklasse)
                             VALUES (@Vorname, @Nachname, @Geburtstag, @Age, @Strasse, @Hausnummer,
                             @Urlaubstage, @Krankheitstage, @Gehalt, @Krankenkasse, @Parkplatz, @Steuerklasse)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Vorname", mitarbeiter.Vorname);
                    command.Parameters.AddWithValue("@Nachname", mitarbeiter.Nachname);
                    command.Parameters.AddWithValue("@Geburtstag", mitarbeiter.Geburtstag);
                    command.Parameters.AddWithValue("@Age", mitarbeiter.Age);
                    command.Parameters.AddWithValue("@Strasse", mitarbeiter.Strasse);
                    command.Parameters.AddWithValue("@Hausnummer", mitarbeiter.Hausnummer);
                    command.Parameters.AddWithValue("@Urlaubstage", mitarbeiter.Urlaubstage);
                    command.Parameters.AddWithValue("@Krankheitstage", mitarbeiter.Krankheitstage);
                    command.Parameters.AddWithValue("@Gehalt", mitarbeiter.Gehalt);
                    command.Parameters.AddWithValue("@Krankenkasse", mitarbeiter.Krankenkasse);
                    command.Parameters.AddWithValue("@Parkplatz", mitarbeiter.Parkplatz);
                    command.Parameters.AddWithValue("@Steuerklasse", mitarbeiter.Steuerklasse);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMitarbeiter(Mitarbeiter mitarbeiter)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Mitarbeiter 
                             SET Vorname = @Vorname, 
                                 Nachname = @Nachname, 
                                 Geburtstag = @Geburtstag, 
                                 Age = @Age, 
                                 Strasse = @Strasse,
                                 Hausnummer = @Hausnummer,
                                 Urlaubstage = @Urlaubstage,
                                 Krankheitstage = @Krankheitstage,
                                 Gehalt = @Gehalt,
                                 Krankenkasse = @Krankenkasse,
                                 Parkplatz = @Parkplatz,
                                 Steuerklasse = @Steuerklasse
                             WHERE MID = @MID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MID", mitarbeiter.MID);
                    command.Parameters.AddWithValue("@Vorname", mitarbeiter.Vorname);
                    command.Parameters.AddWithValue("@Nachname", mitarbeiter.Nachname);
                    command.Parameters.AddWithValue("@Geburtstag", mitarbeiter.Geburtstag);
                    command.Parameters.AddWithValue("@Age", mitarbeiter.Age);
                    command.Parameters.AddWithValue("@Strasse", mitarbeiter.Strasse);
                    command.Parameters.AddWithValue("@Hausnummer", mitarbeiter.Hausnummer);
                    command.Parameters.AddWithValue("@Urlaubstage", mitarbeiter.Urlaubstage);
                    command.Parameters.AddWithValue("@Krankheitstage", mitarbeiter.Krankheitstage);
                    command.Parameters.AddWithValue("@Gehalt", mitarbeiter.Gehalt);
                    command.Parameters.AddWithValue("@Krankenkasse", mitarbeiter.Krankenkasse);
                    command.Parameters.AddWithValue("@Parkplatz", mitarbeiter.Parkplatz);
                    command.Parameters.AddWithValue("@Steuerklasse", mitarbeiter.Steuerklasse);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMitarbeiter(int MID)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM Mitarbeiter WHERE MID = @MID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MID", MID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Mitarbeiter> SearchMitarbeiterByName(string name)
        {
            var mitarbeiters = new List<Mitarbeiter>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM Mitarbeiter WHERE Vorname LIKE @name OR Nachname LIKE @name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");

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
            }
            return mitarbeiters;
        }
    }
}
