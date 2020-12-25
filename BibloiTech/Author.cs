using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BibloiTech
{
    [Serializable]
    class Author
    {
        
        static ulong id = 0;
        private string _name;
        private string _surname;
        private string _secname;
        private string _shortname;
        private string _shortsecname;
        public Author(string surname, string name, string secname)
        {
            Name = name;
            Id = ++id;
            Surname = surname;
            Secname = secname;
            Shortname = Convert.ToString(name[0]);
            if (secname != "")
                Shortsecname = Convert.ToString(secname[0]);
            else Shortsecname = "";
        }
        [JsonPropertyName("Id")]
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
        [JsonPropertyName("Surname")]
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        [JsonPropertyName("Secname")]
        public string Secname
        {
            get => _secname;
            set => _secname = value;
        }
        [JsonPropertyName("Shortname")]
        public string Shortname
        {
            get => _shortname;
            set => _shortname = value;
        }
        [JsonPropertyName("Shortsecname")]
        public string Shortsecname
        {
            get => _shortsecname;
            set => _shortsecname = value;
        }

        public string Info()
        {
            string S;
            if(Shortsecname!="")
                S = String.Format("{0}. {1}. {2}.\n", Surname, Shortname, Shortsecname);
            else
                S = String.Format("{0}. {1}.\n", Surname, Shortname);
            return S;
        }
    }
}
