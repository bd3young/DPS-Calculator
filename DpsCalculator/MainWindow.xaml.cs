using System;
using System.Collections.Generic;
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

namespace DPSCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        string _time;

		public MainWindow()
		{
			InitializeComponent();
            InitializeWindowElements();
		}

        private void InitializeWindowElements()
        {
            _time = "Second";
            UpdateTime(); 
        }

        private void UpdateTime()
        {
            if (RadioButton_Second.IsChecked == true)
            {
                _time = "Second";
            }
            else if (RadioButton_Minute.IsChecked == true)
            {
                _time = "Minute";
            }
            Label_Dps.Content = "Damage Per " + _time;
        }

        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
		{
            string gunType;
            double dps;

            if (validateInputs())
            {
                gunType = ComboBox_GunType.SelectionBoxItem as string;

                switch (gunType)
                {
                    case "Rifle/Pistol":
                        dps = double.Parse(TextBox_Rounds.Text) * double.Parse(TextBox_Dpb.Text) / (double.Parse(TextBox_ReloadTime.Text) + double.Parse(TextBox_Rounds.Text) / double.Parse(TextBox_Bps.Text));

                        if (RadioButton_Second.IsChecked == true)
                        {
                            TextBox_Dps.Text = dps.ToString();
                        }
                        else if (RadioButton_Minute.IsChecked == true)
                        {
                            dps = dps * 60;
                            TextBox_Dps.Text = dps.ToString();
                        }
                        break;
                    case "Shotgun":
                        dps = double.Parse(TextBox_Rounds.Text) * (double.Parse(TextBox_Dpb.Text) * 12) / (double.Parse(TextBox_ReloadTime.Text) + double.Parse(TextBox_Rounds.Text) / double.Parse(TextBox_Bps.Text));

                        if (RadioButton_Second.IsChecked == true)
                        {

                            TextBox_Dps.Text = dps.ToString();
                        }
                        else if (RadioButton_Minute.IsChecked == true)
                        {
                            dps = dps * 60;
                            TextBox_Dps.Text = dps.ToString();
                        }
                        break;
                    case "Fusion Rifle":
                        dps = double.Parse(TextBox_Rounds.Text) * (double.Parse(TextBox_Dpb.Text) * 7) / (double.Parse(TextBox_ReloadTime.Text) + double.Parse(TextBox_Rounds.Text) / double.Parse(TextBox_Bps.Text));

                        if (RadioButton_Second.IsChecked == true)
                        {

                            TextBox_Dps.Text = dps.ToString();
                        }
                        else if (RadioButton_Minute.IsChecked == true)
                        {
                            dps = dps * 60;
                            TextBox_Dps.Text = dps.ToString();
                        }
                        break;
                    default:

                        break;
                }

            }
		}

		private void Exit_Button_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

        private bool validateInputs()
        {
            bool validInputs = true;

            if (!double.TryParse(TextBox_ReloadTime.Text, out double reloadTime) || !double.TryParse(TextBox_Rounds.Text, out double rounds) || !double.TryParse(TextBox_Dpb.Text, out double dpb) || !double.TryParse(TextBox_Bps.Text, out double bps))
            {
                MessageBox.Show("Please enter numbers for each of the following feilds");
                validInputs = false;
                ResetInputs();
            }
            
            return validInputs;
        }

        private void ResetInputs()
        {
            TextBox_ReloadTime.Text = "";
            TextBox_Rounds.Text = "";
            TextBox_Dpb.Text = "";
            TextBox_Bps.Text = "";
            TextBox_ReloadTime.Focus();
        }

        private void RadioButton_Time_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateTime();
            }
        }

        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            DpsCalculator.HelpWindow helpWindow = new DpsCalculator.HelpWindow();

            helpWindow.ShowDialog();
        }
    }
}
