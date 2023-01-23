using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public partial class Zadania
    {
        public int IdZadania { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; }
        public int? Status { get; set; }
    }
}
