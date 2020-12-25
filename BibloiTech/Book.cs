using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; //Библиотека для работы с JSON форматом
using System.Web.Helpers;

namespace BibloiTech
{
    [Serializable] //Возможность записи класса в JSON, сериализация
    class Book
    {
        static ulong id = 0; //id книги
        private string _img; //место хранения файла изображения
        private int _pages;//кол-во страниц
        private int _year;//год издания
        private Publ _publ;//Издатель книги
        protected string _name; //Название
        
        private List<Author> _authors = new List<Author>();//Список авторов книги
        public Book(string name, ushort pages, ushort year, List<Author> authors, Publ publ)//Конструктор
        {
            Name = name;
            Id = ++id;
            Pages = pages;
            Year = year;
            Authors = authors;
            Publ = publ;
        }
        [JsonPropertyName("Id")] //Создание имени свойства обьекта в JSON файле
        public ulong Id
        {
            get;
            private set;
        }
        [JsonPropertyName("Name")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        [JsonPropertyName("Img")]
        public string Img
        {
            get => _img;
            set => _img = value;
        }
        [JsonPropertyName("Pages")]
        public int Pages
        {
            get => _pages;
            set => _pages = value;
        }
        [JsonPropertyName("Year")]
        public int Year
        {
            get => _year;
            set => _year = value;
        }
        public Publ Publ
        {
            get => _publ;
            set => _publ = value;
        }
        public List<Author> Authors
        {
            get => _authors;
            set => _authors = value;
        }
        public string Info()//Получение информации об объекте
        {
            string S = String.Format("Название: {0}\n" +
                                     "Количество страниц: {1}\n" +
                                     "Год: {2}\n" +
                                     "Издательство: {3}\n" +
                                     "Авторы:\n", Name, Pages, Year, Publ.Info());//String.Format Позволяет как в языке Python подставлять нужные значения по ключу в C# это '{номер}'
            for(int i = 0; i < _authors.Count; i++)//Информация об авторах
            {
              S+=_authors[i].Info();
            }
            return S;
        }
    }
}
