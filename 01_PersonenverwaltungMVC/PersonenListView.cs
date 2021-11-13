using System;
using System.Windows.Forms;

namespace TimoKluser.PersonenverwaltungMVC
{
    public partial class PersonenListView : Form, IPersonenView
    {
        PersonenListViewModel personenModel;
        PersonenListViewController personelListViewController;

        public PersonenListView(PersonenListViewModel model)
        {
            InitializeComponent();
            personenModel = model;
            personelListViewController = new PersonenListViewController(personenModel, this, listView1);
        }

        public PersonenListView(PersonenModel model) : this(new PersonenListViewModel() { People = model })
        {
            
        }


        #region Observer
        private void PersonenListView_Load(object sender, EventArgs e)
        {
            //register observer
            personenModel.People.AddView(this);
        }

        private void PersonenListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //deregister observer
            personenModel.People.RemoveView(this);
        }

        public void UpdateView()
        {
            personelListViewController.Update();
        }

        #endregion
    }
}
