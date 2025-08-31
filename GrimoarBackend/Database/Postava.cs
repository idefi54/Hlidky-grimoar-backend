using GrimoarBackend.DTOs;
using SQLite;

namespace GrimoarBackend.Database
{
    public class Postava
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Jmeno { get; set; } = string.Empty;


        // https://github.com/praeclarum/sqlite-net/wiki
        static void ExampleDatabaseSetup()
        {
            // the database should be made only once
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyDatabaseNameHoHoHo.db");
            var db = new SQLiteConnection(path);

            // each table class needs to have this function called 
            db.CreateTable<Postava>();
        }

        static void StoreCharacter(Postava postava, SQLiteConnection db)
        {
            // gotta ensure that your primary key is unique though when inserting something new 
            db.Insert(postava);
        }
        static List<Postava> GetCharacters(SQLiteConnection db)
        {
            return db.Table<Postava>().ToList();
        }
        static List<Postava> GetCharactersByName(string Jmeno, SQLiteConnection db)
        {
            return db.Table<Postava>().Where(p => p.Jmeno == Jmeno).ToList();
        }

        static void IWannaUseSQL(string SQLCommand, SQLiteConnection db)
        {
            db.Execute(SQLCommand);
        }
        static List<Postava> VypisPostavy(SQLiteConnection db, PostavyFiltrDto filtr, int stranka)
        {
            int VysledkuNaStranku = 25;
            bool filtered = false;
            string query = "SELECT * from POSTAVA ";
            if (filtr.jmeno != null)
            {
                query += "WHERE POSTAVA.JMENO=" + filtr.jmeno;
                filtered = true;
            }
            if (filtr.strana != null)
            {
                if (filtered) { query += " AND"; } else { query += " WHERE"; filtered = true; }
                query += " POSTAVA.STRANA=" + filtr.strana.ToString();
            }
            if (filtr.strana != null)
            {
                if (filtered) { query += " AND"; } else { query += " WHERE"; filtered = true; }
                query += " POSTAVA.STRANA=" + filtr.strana.ToString();
            }
            if (filtr.specializace != null)
            {
                if (filtered) { query += " AND"; } else { query += " WHERE"; filtered = true; }
                query += " POSTAVA.SPECIALIZACE=" + filtr.specializace.ToString();
            }
            if (filtr.frakce != null)
            {
                if (filtered) { query += " AND"; } else { query += " WHERE"; filtered = true; }
                query += " POSTAVA.FRAKCE=" + filtr.frakce.ToString();
            }

            if (filtr.kategorie != null)
            {
                if (filtered) { query += " AND"; } else { query += " WHERE"; filtered = true; }
                query += " POSTAVA.KATEGORIE=" + filtr.kategorie.ToString();
            }
            List<Postava> result = db.Query<Postava>(query);
            //Kterou část chci/můžu vrátit? 
            int PossibleMaxRange = 1 + ((result.Count - 1) / VysledkuNaStranku); // (0-25) vysledku -> 1, (26-50) -> 2 etc.
            if (stranka > PossibleMaxRange) { result.Clear(); return result; } //Uživatel chce moc výsledků, máme jich málo. Nevrátím nic.
            return result.GetRange(
                (stranka - 1) * VysledkuNaStranku, //Minimum je od indexu 0, 25, 50 etc
                Math.Min(result.Count - 1, stranka * VysledkuNaStranku -1) //Vrátí buď poslední postavu nebo to na indexu 24, 49, 74 etc.
                );
        }
    }
}
