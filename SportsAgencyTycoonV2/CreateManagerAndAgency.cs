using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public partial class CreateManagerAndAgency : Form
    {
        private string _AgencyName;
        public string AgencyName
        {
            get { return _AgencyName; }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
        }
        private bool _RandomLicenseOrder;
        public bool RandomLicenseOrder
        {
            get { return _RandomLicenseOrder; }
        }

        public CreateManagerAndAgency()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //check if all text boxes are filled
            if (txtManagerLastName.Text == "" || txtManagerFirstName.Text == "" || txtAgencyName.Text == "")
                MessageBox.Show("Make sure you've given an agency name and first and last names for your agent!");
            else
            {
                // set AgencyName, FirstName and LastName
                _AgencyName = txtAgencyName.Text.Trim();
                _FirstName = txtManagerFirstName.Text.Trim();
                _LastName = txtManagerLastName.Text.Trim();
                // check if licenses will be randomized
                if (cbRandomLicenseOrder.Checked)
                    _RandomLicenseOrder = true;
                else _RandomLicenseOrder = false;

                this.Close();
            }
        }
    }
}
