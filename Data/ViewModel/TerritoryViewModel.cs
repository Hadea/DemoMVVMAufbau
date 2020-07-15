using Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;

namespace Data.ViewModel
{
    public class TerritoryViewModel
    {
        public TerritoryViewModel()
        {
            TerritoryCollection = new ObservableCollection<TerritoryModel>();
            loadSQLData();
        }

        public ObservableCollection<TerritoryModel> TerritoryCollection { get; set; }

        private void loadSQLData()
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = @"Datenbank\northwindEF.db";
            builder.Version = 3;

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select TerritoryID, TerritoryDescription, RegionDescription from Territories join regions on (Territories.RegionID = regions.RegionID);";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    TerritoryCollection.Clear();
                    while (reader.Read())
                    {
                        TerritoryModel nm = new TerritoryModel();
                        nm.TerritoryID = reader.GetInt32(0);
                        nm.TerritoryDescription = reader.GetString(1);
                        nm.RegionDescription = reader.GetString(2);
                        TerritoryCollection.Add(nm);

                    }
                } 
            }

            // Datenbank öffnen
            // kommando vorbereiten
            // kommando abschicken
            // zeilenweise ergebnis lesen und in Colletion speichern
        }
    }
}
