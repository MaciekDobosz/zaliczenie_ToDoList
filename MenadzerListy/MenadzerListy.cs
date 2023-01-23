using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Models
{
    public class MenadzerListy : IMenadzerListy
    {
        ToDoListContext toDo = new ToDoListContext();


        public List<Zadania> ListaZadan(bool zrobione)
        {
            
            var zadania = toDo.Zadania.ToList();
            List<Zadania> zadanka;
            if (zrobione)
                zadanka = zadania.Where(x => x.Status == 1).ToList();
            else
                zadanka = zadania.Where(x => x.Status == 0).ToList();

            return zadanka;
        }

        public void DodajZadanie(Zadania zadania)
        {
            Zadania noweZadanie = zadania;
            noweZadanie.Status = 0;
            toDo.Zadania.Add(noweZadanie);
            toDo.SaveChanges();
        }

        public void UsunZadanie(Zadania zadania)
        {
            toDo.Zadania.Remove(toDo.Zadania.FirstOrDefault(x => x.IdZadania == zadania.IdZadania));
            toDo.SaveChanges();
        }

        public void EdytujZadanie(Zadania zadania)
        {
            Zadania zadanie = toDo.Zadania.FirstOrDefault(x => x.IdZadania == zadania.IdZadania);

            zadanie.Tytul = zadania.Tytul;
            zadanie.Opis = zadania.Opis;

            toDo.SaveChanges();
        }

        public void Zrobione(Zadania zadania)
        {
            Zadania zadanie = toDo.Zadania.FirstOrDefault(x => x.IdZadania == zadania.IdZadania);
            zadanie.Status = 1;
            toDo.SaveChanges();
        }

        public Zadania PojedynczeZadanie(int id)
        {
            return toDo.Zadania.FirstOrDefault(x => x.IdZadania == id);
        }
    }
}
