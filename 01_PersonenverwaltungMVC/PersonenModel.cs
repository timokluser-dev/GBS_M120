using System;
using System.Collections;
using System.Collections.Generic;

//Model Part of MVC

namespace TimoKluser.PersonenverwaltungMVC
{
    public class PersonenModel  : IEnumerable<Person>
    {
        List<Person> personen;
        #region Observer
        List<IPersonenView> views;
        #endregion

        public PersonenModel()
        {
            personen = new List<Person>();

            #region Observer
            views = new List<IPersonenView>();
            #endregion
        }

        #region Observer
        public void AddView(IPersonenView view)
        {
            views.Add(view);
            view.UpdateView();
        }

        public void RemoveView(IPersonenView view)
        {
            views.Remove(view);
        }

        public void UpdateAllViews()
        {
            foreach (IPersonenView view in views)
            {
                view.UpdateView();
            }
        }
        #endregion

        public void AddPerson(Person person)
        {
            personen.Add(person);
            UpdateAllViews();
        }

        public void RemovePerson(Person person)
        {
            personen.Remove(person);
            UpdateAllViews();
        }

        public void ChangePerson(Person person, Person newPerson)
        {
            int index = personen.IndexOf(person);
            personen[index] = newPerson;
            UpdateAllViews();
        }

        #region Implement Interface IEnumerator<Person>
        //damit direkt über PersonenModel iteriert werden kann
        //z.B. mit foreach()
        public IEnumerator<Person> GetEnumerator()
        {
            return personen.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return personen.GetEnumerator();
        }
        #endregion
    }
}
