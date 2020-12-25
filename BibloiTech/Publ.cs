using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BibloiTech
{
    [Serializable]
    class Publ
    {
        static ulong id = 0;
        private string _name;
        private string _shortname;
        public Publ(string name)
        {
            Id = ++id;
            Name = name;
            Shortname = Convert.ToString(name[0]);
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
        [JsonPropertyName("Shortname")]
        public string Shortname
        {
            get => _shortname;
            set => _shortname = value;
        }
        public string  Info()
        {
            string S = String.Format("{0}: {1}.\n", Name, Shortname);
            return S;
        }
    }
}
