using System.Windows.Forms;

//Controller Part of MVC

namespace TimoKluser.PersonenverwaltungMVC
{
    class PersonenViewController
    {
        PersonenViewModel model;
        PersonenView view;
        ListBox listBox; 

        public PersonenViewController(PersonenViewModel model, PersonenView view, ListBox listBox)
        {
            this.model = model;
            this.view = view;
            this.listBox = listBox;
            listBox.DisplayMember = nameof(Person.Name);
        }

        public void UpdateView()
        {
            view.ResetEditMasks();
            listBox.Items.Clear();
            foreach (Person person in model.People)
            {
                listBox.Items.Add(person);
            }
        }

        public void Sort(bool isSorted)
        {
            listBox.Sorted = isSorted;
            //no change in model, but update all views
            model.People.UpdateAllViews();
        }

        public void AddPerson(Person person)
        {
            model.People.AddPerson(person);
        }

        public void RemoveSelectedPerson()
        {
            Person person = listBox.SelectedItem as Person;
            if (person != null)
              model.People.RemovePerson(person);
        }

        public void ChangeSelectedPerson(Person newPerson)
        {
            Person person = listBox.SelectedItem as Person;
            if (person != null)
              model.People.ChangePerson(person, newPerson);
        }

        public void SelectionChanged()
        {
            Person person = listBox.SelectedItem as Person;
            if (person != null)
            {
                view.SetEditmask(person, listBox.SelectedIndex);
            }
            else
            {
                view.ResetEditMasks();
            }
        }

    }
}
