using System;
using System.Windows.Forms;

//View Part of MVC

namespace TimoKluser.PersonenverwaltungMVC
{
    public partial class PersonenView : Form,  IPersonenView
    {
        PersonenViewModel personenModel;
        PersonenViewController personenViewController;

        public PersonenView(PersonenViewModel model)
        {
            InitializeComponent();
            personenModel = model;
            personenViewController = new PersonenViewController(model, this, listBoxPersons);
        }

        public PersonenView(PersonenModel model) : this(new PersonenViewModel() { People = model })
        {

        }

        #region Observer
        private void PersonenView_Load(object sender, EventArgs e)
        {
            //register observer
            personenModel.People.AddView(this);
        }

        private void PersonenView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //deregister observer
            personenModel.People.RemoveView(this);
        }

        public void UpdateView()
        {
            personenViewController.UpdateView();
        }
        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Person person = new Person(textBoxName.Text, textBoxPrename.Text, textBoxPhoneNbr.Text);
            personenViewController.AddPerson(person);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            personenViewController.RemoveSelectedPerson();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Person newPerson = new Person(textBox1.Text, textBox2.Text, textBox3.Text);
            personenViewController.ChangeSelectedPerson(newPerson);
        }

        private void checkBoxSorted_CheckedChanged(object sender, EventArgs e)
        {
            personenViewController.Sort(checkBoxSorted.Checked);
        }

        private void listBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            personenViewController.SelectionChanged();
        }

        public void ResetEditMasks()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        public void SetEditmask(Person person, int index)
        {
            textBox1.Text = person.Name;
            textBox2.Text = person.Vorname;
            textBox3.Text = person.TelefonNr;
            textBox4.Text = index.ToString();
        }

        private void buttonShowView_Click(object sender, EventArgs e)
        {
            PersonenListView plv = new PersonenListView(personenModel.People);
            plv.Show();
        }
    }
}
