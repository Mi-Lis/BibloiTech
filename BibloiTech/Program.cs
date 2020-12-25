using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

using Newtonsoft.Json; //Стороняя библиотека полностью совместимая с System.Text.Json.Serialization
namespace BibloiTech
{
    partial class Program
    {
        static void Main()
        {
            
            Author author = new Author("Лисюткин", "Михаил", "Юрьевич");
            Author author1 = new Author("Живодер", "Илья", "");
            Publ publ = new Publ("Mir");
            List<Author> authors = new List<Author>
            {
                author,
                author1
            };
            Book book = new Book("Книга", 123, 1904, authors, publ);

            
            string json = JsonConvert.SerializeObject(authors, Formatting.Indented); //Оформление JSON файла и заполнение информацией об авторах
            Console.WriteLine(json);
            Data data = new Data("F:/books.json");
            data.Add(book);

          DataAuthors dataAuthors = new DataAuthors("F:/authors.json");
            dataAuthors.Add(author);
            dataAuthors.Add(author1);
  
            DataPubls dataPubls = new DataPubls("F:/publs.json");
            dataPubls.Add(publ);

            DB dB = new DB("F:/Database.db");
        }
    }
}