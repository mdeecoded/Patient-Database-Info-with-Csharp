using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientInfo
{
    public partial class Dashboard : Form
    {
        // Declare patientsList as a class-level field
        private List<Patient> patientsList = new List<Patient>();

        public Dashboard()
        {
            InitializeComponent();


        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Set the data source for the DataGridView
            gridView.DataSource = patientsList;
            // Add items to Blood Group combo box
            cmbBloodGroup.Items.Add("A");
            cmbBloodGroup.Items.Add("B");
            cmbBloodGroup.Items.Add("AB");
            cmbBloodGroup.Items.Add("O+");
            cmbBloodGroup.Items.Add("O-");

            // Add items to Genotype combo box
            cmbGenotype.Items.Add("AA");
            cmbGenotype.Items.Add("AS");
            cmbGenotype.Items.Add("SS");
            cmbGenotype.Items.Add("AC");
            // Add more items as needed

            gridView.Columns["Title"].Name = "Title";
            gridView.Columns["IdNo"].Name = "IdNo";
            gridView.Columns["FirstName"].Name = "FirstName";
            gridView.Columns["MiddleName"].Name = "MiddleName";
            gridView.Columns["LastName"].Name = "LastName";
            gridView.Columns["Email"].Name = "Email";
            gridView.Columns["MobileNumber"].Name = "MobileNumber";
            gridView.Columns["BloodGroup"].Name = "BloodGroup";
            gridView.Columns["Genotype"].Name = "Genotype";
            gridView.Columns["AdmissionDate"].Name = "AdmissionDate";
            gridView.Columns["EmergencyNumber"].Name = "EmergencyNumber";
            gridView.Columns["HomeAddress"].Name = "HomeAddress";
            gridView.Columns["Remarks"].Name = "Remarks";



        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Handle label click event
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Handle radio button checked changed event
        }

        private void lblidentityNo_Click(object sender, EventArgs e)
        {
            // Handle label click event
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            // Handle label click event
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label click event
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle text box text changed event
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Handle label click event
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                // Determine the selected radio button in TitleGroup
                string selectedTitle = "";
                if (mrRadioButton.Checked)
                {
                    selectedTitle = mrRadioButton.Text;
                }
                else if (mrsRadioButton.Checked)
                {
                    selectedTitle = mrsRadioButton.Text;
                }
                else if (missRadioButton.Checked)
                {
                    selectedTitle = missRadioButton.Text;
                }

                // Create a new patient with the entered details
                Patient newPatient = new Patient
                {
                    Title = selectedTitle,
                    IdNo = txtIdNo.Text,
                    FirstName = txtFirstname.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    MobileNumber = txtMN.Text,
                    BloodGroup = cmbBloodGroup.Text,
                    Genotype = cmbGenotype.Text,
                    AdmissionDate = DateTime.Now,
                    EmergencyNumber = txtEmergency.Text,
                    HomeAddress = txtHomeAddress.Text,
                    Remarks = txtRemark.Text
                };

                // Add the new patient to the list
                patientsList.Add(newPatient);

                // Bind the patientsList to the DataGridView
                gridView.DataSource = null; // Clear the existing data source
                gridView.DataSource = patientsList; // Set the new data source

                // Clear the input fields
                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearFormFields()
        {
            TitleGroup.Text = "";
            txtIdNo.Text = "";
            txtFirstname.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtMN.Text = "";
            cmbBloodGroup.SelectedIndex = -1;
            cmbGenotype.SelectedIndex = -1;
            txtEmergency.Text = "";
    txtHomeAddress.Text = "";
    txtRemark.Text = "";

            // Add other controls and their default values here
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            // Add the code for handling the Clear button here
            DialogResult result = MessageBox.Show("Are you sure you want to clear all fields?", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearFormFields();
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
{
            // Check if there are any entries in the list
            if (patientsList.Count > 0)
            {
                // Remove the last entry from the list
                patientsList.RemoveAt(patientsList.Count - 1);

                // Bind the updated data to the DataGridView
                gridView.DataSource = null; // Clear the previous data source
                gridView.DataSource = patientsList;

                // Optionally update the DataGridView here to reflect the changes
            }
            else
            {
                MessageBox.Show("No entry to delete.", "No Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnexit_Click(object sender, EventArgs e)
        {
            // Add the code for handling the Exit button here
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= gridView.Rows.Count)
                {
                    MessageBox.Show("No row selected or index out of range.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (e.ColumnIndex >= 0 && e.ColumnIndex < gridView.Columns.Count)
                {
                    DataGridViewCell clickedCell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (clickedCell != null && clickedCell.Value != null)
                    {
                        // Access the cell data here
                        var cellData = clickedCell.Value.ToString();
                        MessageBox.Show(cellData);
                    }
                    else
                    {
                        MessageBox.Show("Clicked cell or its value is null.", "Cell Data Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Column index out of range.", "Column Index Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnExportToCsv_Click(object sender, EventArgs e)
        {

        }

    

        private void gridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }



    }
}
