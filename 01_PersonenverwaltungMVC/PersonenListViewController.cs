using System.Windows.Forms;

namespace TimoKluser.PersonenverwaltungMVC
{
    class PersonenListViewController
    {
        PersonenListViewModel model;
        PersonenListView view;
        ListView  listView;

        public PersonenListViewController(PersonenListViewModel model, PersonenListView view, ListView listView)
        {
            this.model = model;
            this.view = view;
            this.listView = listView;
        }

        public void Update()
        {
            listView.Items.Clear();
            foreach (Person person in model.People)
            {
                ListViewItem item = new ListViewItem(person.Name);
                item.SubItems.Add(person.Vorname);
                item.SubItems.Add(person.TelefonNr);
                listView.Items.Add(item);
            }
        }
    }
}
