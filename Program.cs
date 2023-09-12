using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_Appointed_Program.Classes;
using Jacob_Rosendahl_Appointed_Program.Database;

namespace Jacob_Rosendahl_Appointed_Program
{
	static class Program
	{
		public static string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			DBConnection.StartConnection();
			User.PopulateUsers();
			Customer.PopulateCustomers();
			Consultant.PopulateConsultants();
			Admin.PopulateAdmins();
			Appointment.PopulateAppointments();
			Application.Run(new Intro());
			DBConnection.CloseConnection();
		}
	}
}
