using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
namespace BibloiTech
{
    partial class Program
    {

        public class Data
        {
            // readonly JsonSerializer serializer = new JsonSerializer(); //Создание объекта необходимого для сериализации информации об объекте

            readonly string Path; //Расположение JSON файла
            string json; //Содержание JSON документа
            readonly List<Book> books = new List<Book>();
            readonly List<Author> authors = new List<Author>();
            readonly List<Publ> publs = new List<Publ>();
            readonly StreamWriter file; //Файл с которым будем работать
            public Data(string path)
            {
                Path = path;
                file = File.CreateText(Path);
                file.Close();
            }
            public void Write(string key)//Запись в файл
            {
                switch (key)
                {
                    case "b":
                        {
                            json = JsonConvert.SerializeObject(books, Formatting.Indented);
                            File.WriteAllText(Path, json);
                        }
                    case "a":
                        {
                            json = JsonConvert.SerializeObject(authors, Formatting.Indented);
                            File.WriteAllText(Path, json);
                        }
                    case "p":
                        {
                            json = JsonConvert.SerializeObject(publs, Formatting.Indented);
                            File.WriteAllText(Path, json);
                        }
                }
            }
            public string Read()//Чтение JSON документа
            {
                string S = "";
                List<Book> deserializedProduct = JsonConvert.DeserializeObject<List<Book>>(json);
                for (int i = 0; i < deserializedProduct.Count; i++)
                {
                    S += deserializedProduct[i].Info() + "\n";
                }
                return S;
            }
            public void Add(Book book) //Добавление новой книги
            {
                books.Add(book);
            }
            public void Remove(ulong id) //Удаление книги
            {
                Book book = books.Find(x => x.Id == id); //Нахождение книги по id с помощью предиката
                books.Remove(book);
                Write();
            }
            public void Info(ulong id)
            {
                Book book = books.Find(x => x.Id == id);
                book.Info();
                Write();
            }
        }
        public class DataAuthors
        {
            //  readonly JsonSerializer serializer = new JsonSerializer();
            readonly string Path;
            string json;
            
            readonly StreamWriter file;
            public DataAuthors(string path)
            {
                Path = path;
                file = File.CreateText(Path);
                file.Close();
            }
            public void Write()
            {
                json = JsonConvert.SerializeObject(authors, Formatting.Indented);
                File.WriteAllText(Path, json);
            }
            public string Read()
            {
                string S = "";
                List<Author> deserializedProduct = JsonConvert.DeserializeObject<List<Author>>(json);
                for (int i = 0; i < deserializedProduct.Count; i++)
                {
                    S += deserializedProduct[i].Info() + "\n";
                }
                return S;
            }
            public void Add(Author author)
            {
                authors.Add(author);
            }
            public void Remove(ulong id)
            {
                Author author = authors.Find(x => x.Id == id);
                authors.Remove(author);
                Write();
            }
            public void Info(ulong id)
            {
                Author author = authors.Find(x => x.Id == id);
                author.Info();
                Write();
            }
        }
        public class DataPubls
        {
            // readonly JsonSerializer serializer = new JsonSerializer();

            readonly string Path;
            string json;
           
            readonly StreamWriter file;
            public DataPubls(string path)
            {
                Path = path;
                file = File.CreateText(Path);
                file.Close();
            }
            public void Write()
            {
                json = JsonConvert.SerializeObject(publs, Formatting.Indented);
                File.WriteAllText(Path, json);
            }
            public string Read()
            {
                string S = "";
                List<Publ> deserializedProduct = JsonConvert.DeserializeObject<List<Publ>>(json);
                for (int i = 0; i < deserializedProduct.Count; i++)
                {
                    S += deserializedProduct[i].Info() + "\n";
                }
                return S;
            }
            public void Add(Publ publ)
            {
                publs.Add(publ);
            }
            public void Remove(ulong id)
            {
                Publ publ = publs.Find(x => x.Id == id);
                publs.Remove(publ);
                Write();
            }
            public void Info(ulong id)
            {
                Publ Publ = publs.Find(x => x.Id == id);
                Publ.Info();
                Write();
            }
        }
        public class DB
        {
            private String dbFileName;
            private SQLiteConnection m_dbConn;
            private SQLiteCommand m_sqlCmd;
            public DB(string path)
            {
                dbFileName = path;
                SQLiteConnection.CreateFile(dbFileName);
                Console.WriteLine(File.Exists(dbFileName) ? "База данных создана" : "Возникла ошибка при создании базы данных");
               m_dbConn =
                    new SQLiteConnection(string.Format("Data Source={0};", dbFileName));
                m_sqlCmd =
                    new SQLiteCommand(@"PRAGMA foreign_keys = 0;
                CREATE TABLE Book(
                    Id      INTEGER PRIMARY KEY
                                    REFERENCES Authors (IdBook),
                    Name    TEXT,
                    Img     TEXT,
                    Pages   INTEGER,
                    Year    INTEGER,
                    Publ    TEXT REFERENCES Publ (id),
                    Authors TEXT
                );
              
                PRAGMA foreign_keys = 1;
                ", m_dbConn);
                m_dbConn.Open();
                m_sqlCmd.ExecuteNonQuery();
                m_dbConn.Close();

                m_sqlCmd = new SQLiteCommand(@" PRAGMA foreign_keys = 0;
                CREATE TABLE Author(
                    Id           INTEGER PRIMARY KEY,
                    Name         TEXT,
                    Shortname    TEXT,
                    Secname      TEXT,
                    Shortsecname TEXT,
                    Surname      TEXT
                );
 PRAGMA foreign_keys = 1;", m_dbConn);
                m_dbConn.Open();
                m_sqlCmd.ExecuteNonQuery();
                m_dbConn.Close();

                m_sqlCmd = new SQLiteCommand(@"PRAGMA foreign_keys = 0;

CREATE TABLE Publ (
    id        INTEGER PRIMARY KEY,
    Name      TEXT,
    Shortname TEXT
);

 PRAGMA foreign_keys = 1;", m_dbConn);
                m_dbConn.Open();
                m_sqlCmd.ExecuteNonQuery();
                m_dbConn.Close();

                m_sqlCmd = new SQLiteCommand(@"PRAGMA foreign_keys = 0;
CREATE TABLE Authors (
    IdBook   INTEGER,
    IdAuthor INTEGER
);
PRAGMA foreign_keys = 1;
", m_dbConn);
                m_dbConn.Open();
                m_sqlCmd.ExecuteNonQuery();
                m_dbConn.Close();
                Console.ReadKey(true);
            }
            public void Write()
            {
                var data = JsonConvert.DeserializeObject<json>
            }
        }
    }
}
