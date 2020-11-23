// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//     This file in the main logic for the whole application. This file is the main view of the form
//     the form allows users to enter a vehicle (Boat or Car), with the mileage, manufacturer, model, and product year.
//      when the user is satisfied with what they entered they can press and and it will add the data to the database.
//      At the top of the form there is another tab called Summary, which allows the users to view all the vehicles in the database.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLAR_P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtManufacturer.Focus();
        }

        /// <summary>
        /// Reset the entry box background color on value change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            var txtModifiedBox = (TextBox)sender;
            txtModifiedBox.Background = Brushes.White;
        }

        /// <summary>
        /// When a textbox is in an error state, highlight the textbox and focus
        /// </summary>
        /// <param name="txtErrorBox">Text box that is in an error state</param>
        private void HighlightTextbox(TextBox txtErrorBox)
        {
            txtErrorBox.Background = Brushes.Red;
            txtErrorBox.SelectAll();
            txtErrorBox.Focus();
        }

        /// <summary>
        /// Disables the interaction for the text fields and buttons
        /// </summary>
        private void disableInteraction()
        {
            txtManufacturer.IsEnabled = false;
            txtMileage.IsEnabled = false;
            txtModel.IsEnabled = false;
            txtProductYear.IsEnabled = false;
            btnAdd.IsEnabled = false;
            btnClear.IsEnabled = false;
        }

        /// <summary>
        /// Resets all the elements on screen to their default state.
        /// </summary>
            private void resetValues()
        {
            //Clear the text fields
            this.txtManufacturer.Clear();
            this.txtMileage.Clear();
            this.txtModel.Clear();
            this.txtProductYear.Clear();

            //Enable the text fields
            txtManufacturer.IsEnabled = true;
            txtMileage.IsEnabled = true;
            txtModel.IsEnabled = true;
            txtProductYear.IsEnabled = true;

            //Resets the error labels text color to white
            lblManufacturerError.Background = Brushes.White;
            lblMileageError.Background = Brushes.White;
            lblModelError.Background = Brushes.White;
            lblMileageError.Background = Brushes.White;

            //Reset the error labels content to empty string
            this.lblManufacturerError.Content = "";
            this.lblModelError.Content = "";
            this.lblProductYearError.Content = "";
            this.lblMileageError.Content = "";

            //Recheck the car radio button
            this.radioBtnCar.IsChecked = true;

            //enable the buttons
            this.btnAdd.IsEnabled = true;
            this.btnClear.IsEnabled = true;
            //Reset focus to the manufacturer text field
            txtManufacturer.Focus();

        }

        /// <summary>
        /// When the boat radio button is checked, hide the mileage fields and labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnBoat_Checked(object sender, RoutedEventArgs e)
        {
            txtMileage.Visibility = Visibility.Hidden;
            lblMileage.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// When the car radiobutton is checked, show the mileage fields and labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnCar_Checked(object sender, RoutedEventArgs e)
        {
          if (this.IsInitialized)
            {
               this.txtMileage.Visibility = Visibility.Visible;
               this.lblMileage.Visibility = Visibility.Visible;
            }
          
        }

        /// <summary>
        /// Action for the clear button. Resets the values and sets the status text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            resetValues();
            lblStatusText.Content = "Cleared values.";
        }

        /// <summary>
        /// Action when the user clicks the 'Add' button. Attempts to Check if it is a car or boat object
        /// disables the interaction, inserts into the database. If it fails put the error on the respected field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Check if txtMileage is visable, if it is the object should be a car.
                if (this.txtMileage.Visibility == Visibility.Visible)
                {
                    //Create a car object 
                    var carObject = new Car(this.txtManufacturer.Text, this.txtModel.Text, this.txtProductYear.Text, this.txtMileage.Text);
                    //Disable the interaction of the fields
                    disableInteraction();
                    //Attempt to insert the car into the database
                    DBL.InsertCar(carObject);
                    //Update the status text
                    lblStatusText.Content = "Inserted a car";
                } 
                else
                {
                    //Create the boat object
                    var boatObject = new Boat(this.txtManufacturer.Text, this.txtModel.Text, this.txtProductYear.Text);
                    //Disable the user interaction
                    disableInteraction();
                    //Attemp to insert the boat object
                    DBL.InsertBoat(boatObject);
                    //Update the status text
                    lblStatusText.Content = "Inserted a boat";
                }
                // Set focus to the Clear button to facilitate data entry.
                btnClear.IsEnabled = true;
                btnClear.Focus();

            }
            //Catch any errors
            catch (ArgumentException ex)
            {
                //Each if:
                //  Check the parameter name
                //   If the parameter name matches, set the content to the error message,
                //   Highlight the textbox
                if (ex.ParamName == "Manufacturer")
                {

                    lblManufacturerError.Content = "Manufacturer entry error! " + ex.Message;
                    HighlightTextbox(txtManufacturer);
                }
                else if (ex.ParamName == "ProductYear")
                {
                    lblProductYearError.Content = "Product Year entry error! " + ex.Message;
                    HighlightTextbox(txtProductYear);

                }
                else if (ex.ParamName == "Model")
                {
                    lblModelError.Content = "Model entry error! " + ex.Message;
                    HighlightTextbox(txtModel);
                }
                else if (ex.ParamName == "Mileage")
                {
                    lblMileageError.Content = "Mileage entry error! " + ex.Message;
                    HighlightTextbox(txtMileage);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical Error " + ex.Message);
            }
        }

        /// <summary>
        /// On tab selection change, update the status text and if needed reload the views.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = (TabControl)sender;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    lblStatusText.Content = "Vehicle entry displayed.";
                    break;
                case 1:
                    //Refetch the data from the database
                    tabItemSummary.ReloadData();
                    lblStatusText.Content = "Summary data displayed.";
                    break;

                default:
                    break;
            };
        }
        /// <summary>
        /// Close the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
