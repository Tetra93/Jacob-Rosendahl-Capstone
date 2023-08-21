using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jacob_Rosendahl_C969_Scheduling_Application.Classes;
using Jacob_Rosendahl_C969_Scheduling_Application.Database;

namespace Jacob_Rosendahl_C969_Scheduling_Application
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
			Customer.PopulateCustomers();
			Consultant.PopulateConsultants();
			Admin.PopulateAdmins();
			Appointment.PopulateAppointments();
			Application.Run(new Intro());
			DBConnection.CloseConnection();
		}
	}
}
