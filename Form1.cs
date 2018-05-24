using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamRoster
{
    public partial class TeamRosterForm : Form
    {
        /// <summary>
        /// Indicates whether or not the form is currently being used to edit and existing player.
        /// </summary>
        private bool isBeingEdited = false;

        /// <summary>
        /// Indicates whether or not the form is currently being used to add a new player.
        /// </summary>
        private bool isBeingAdded = false;

        /// <summary>
        /// The number of the player that is currently selected on the form.
        /// </summary>
        private int selectedPlayerNumber;

        /// <summary>
        /// A roster of the players in the Roster table in the PlayerRoster database.
        /// </summary>
        public Roster PlayerRoster { get; set; } = new Roster();

        /// <summary>
        /// Initializes the TeamRosterForm.
        /// </summary>
        public TeamRosterForm() => InitializeComponent();

        /// <summary>
        /// The TeamRosterForm load.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void TeamRosterForm_Load(object sender, EventArgs e)
        {
            LoadRoster();
        }

        /// <summary>
        /// Binds the PlayerRoster to the combo box.
        /// </summary>
        private void BindComboBox()
        {
            this.SelectPlayerComboBox.DataSource = null;
            this.SelectPlayerComboBox.DataSource = this.PlayerRoster;

            this.SelectPlayerComboBox.DisplayMember = "FullPlayerTitle";
            this.SelectPlayerComboBox.ValueMember = "Number";

            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;
        }

        /// <summary>
        /// Fills the PlayerRoster with the players currently in the Roster table.
        /// </summary>
        private void LoadRoster()
        {
            this.PlayerRoster = Roster.GetAll();
            this.BindComboBox();
        }

        /// <summary>
        /// Clears the form and sets all elements back to their default status. The results label is the only
        /// property not reset.
        /// </summary>
        private void ClearForm()
        {
            this.AddButton.Enabled = true;
            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;

            this.AcceptButton.Enabled = false;
            this.CancelButton.Enabled = false;

            this.FirstNameTextBox.Clear();
            this.LastNameTextBox.Clear();
            this.NumberMaskedTextBox.Clear();

            this.FirstNameTextBox.Enabled = false;
            this.LastNameTextBox.Enabled = false;
            this.NumberMaskedTextBox.Enabled = false;

            this.isBeingEdited = false;
            this.isBeingAdded = false;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Enables the Edit and Delete buttons when a player is selected from the combo box.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void SelectPlayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EditButton.Enabled = true;
            this.DeleteButton.Enabled = true;
        }

        /// <summary>
        /// Handles the click event for the Edit button.  Disables the Add, edit, and delete button. Enables the
        /// Accept and Cancel buttons. Enables the LastName, FirstName, and Number text boxes for the user to
        /// input player info to be edited. Sets isBeingEdited to true.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            this.AddButton.Enabled = false;
            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;

            this.AcceptButton.Enabled = true;
            this.CancelButton.Enabled = true;

            this.FirstNameTextBox.Enabled = true;
            this.LastNameTextBox.Enabled = true;
            this.NumberMaskedTextBox.Enabled = true;

            this.isBeingEdited = true;

            if (this.SelectPlayerComboBox.SelectedIndex >= 0)
            {
                this.selectedPlayerNumber = PlayerRoster[this.SelectPlayerComboBox.SelectedIndex].Number;
                var player = this.PlayerRoster[this.SelectPlayerComboBox.SelectedIndex];
                this.NumberMaskedTextBox.Text = player.Number.ToString();
                this.LastNameTextBox.Text = player.LastName;
                this.FirstNameTextBox.Text = player.FirstName;


            }
        }

        /// <summary>
        /// Handles the click event for the Add button. Disables the Add, edit, and delete button. Enables the
        /// Accept and Cancel buttons. Enables the LastName, FirstName, and Number text boxes for the user to
        /// input player info to be edited. Sets isBeingAdded to true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            this.AddButton.Enabled = false;
            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;

            this.AcceptButton.Enabled = true;
            this.CancelButton.Enabled = true;

            this.FirstNameTextBox.Enabled = true;
            this.LastNameTextBox.Enabled = true;
            this.NumberMaskedTextBox.Enabled = true;

            this.isBeingAdded = true;

            this.NumberMaskedTextBox.Clear();
            this.LastNameTextBox.Clear();
            this.FirstNameTextBox.Clear();
        }

        /// <summary>
        /// Handles the click event for the Accept button.  Validates the data entered. All fields must be entered.
        /// Number must be greater than zero and cannot already be taken by a player currently in the roster. If the
        /// input is not valid, feedback is given to the user in the results label. If the data is valid, the player
        /// will either be added or edited, depending on the values of isBeingEdited and isBeingAdded. If unsuccessful,
        ///  the user is given feedback in the results label. If successful, the form is cleared.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var isSuccessful = false;

            var isValidNumber = Int32.TryParse(this.NumberMaskedTextBox.Text, out int number);
            var lastName = this.LastNameTextBox.Text;
            var firstName = this.FirstNameTextBox.Text;

            if (number < 0 || !isValidNumber)
            {
                this.ResultLabel.Text = "Invalid number.";
            }

            if (!this.PlayerRoster.IsAvailableNumber(number))
            {
                this.ResultLabel.Text = "Number already taken.";
                return;
            }

            if (lastName.CompareTo("") == 0 || firstName.CompareTo("") == 0)
            {
                this.ResultLabel.Text = "All fields must be entered.";
                return;
            }

            var player = new Player()
            {
                Number = number,
                LastName = lastName,
                FirstName = firstName
            };

            if (isBeingEdited)
            {
                isSuccessful = player.Update(this.selectedPlayerNumber);
                this.ResultLabel.Text = isSuccessful ? $"Player {number} updated."
                    : "Not updated.";
            }

            if (isBeingAdded)
            {
                isSuccessful = player.Insert();
                this.ResultLabel.Text = isSuccessful ? $"Player {number} added." : "Not added.";
            }

            if (isSuccessful)
            {
                this.ClearForm();
                this.LoadRoster();
            }
        }

        /// <summary>
        /// Handles the click event for the Cancel button. Clears the form and results label.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.ResultLabel.Text = "";
        }

        /// <summary>
        /// Handles the click event for the Delete button. Deletes the currently selected Player in the combo
        /// box from the Roster table.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (this.SelectPlayerComboBox.SelectedIndex >= 0)
            {
                this.ResultLabel.Text =
                    Player.Delete(PlayerRoster[this.SelectPlayerComboBox.SelectedIndex].Number) ? "Deleted" : "Not Deleted.";

                this.LoadRoster();
            }
        }

        /// <summary>
        /// Gives the user feedback if invalid data is input is given in the Number Masked Text Box. Only two
        /// integer digits are accepted.
        /// </summary>
        /// <param name="sender">The control that generated the event.</param>
        /// <param name="e">The event arguments instance that contains the event data.</param>
        private void NumberMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.ResultLabel.Text = "Invalid Number.";
        }
    }
}
