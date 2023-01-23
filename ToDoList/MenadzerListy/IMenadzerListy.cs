using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Models
{
    public interface IMenadzerListy
    {
        List<Zadania> ListaZadan(bool zrobione);
        void DodajZadanie(Zadania zadania);
        void UsunZadanie(Zadania zadania);
        void EdytujZadanie(Zadania zadania);
        void Zrobione(Zadania zadania);
        Zadania PojedynczeZadanie(int id);
    }
}
