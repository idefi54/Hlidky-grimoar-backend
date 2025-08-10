using SQLite;

namespace GrimoarBackend.Database
{
    public class Postava
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;


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
        static List<Postava> GetCharactersByName(string name, SQLiteConnection db)
        {
            return db.Table<Postava>().Where(p => p.Name == name).ToList();
        }

        static void IWannaUseSQL(string SQLCommand, SQLiteConnection db)
        {
           db.Execute(SQLCommand);
        }
    }
}
