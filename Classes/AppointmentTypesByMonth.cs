using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacob_Rosendahl_C969_Scheduling_Application.Classes
{
    class AppointmentTypesByMonth
    {

        public string Month { set; get; }

        public int Presentation { set; get; }

        public int Planning { set; get; }

        public int Scrum { set; get; }

        public int Review { set; get; }

        public static BindingList<AppointmentTypesByMonth> appointmentMonthsBindingList = new BindingList<AppointmentTypesByMonth>();

        public static void CountMonths()
        {                
            appointmentMonthsBindingList.Clear();
            AppointmentTypesByMonth newMonths1 = new AppointmentTypesByMonth
            {
                Month = "January",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths1);
            AppointmentTypesByMonth newMonths2 = new AppointmentTypesByMonth
            {
                Month = "February",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths2);

            AppointmentTypesByMonth newMonths3 = new AppointmentTypesByMonth
            {
                Month = "March",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths3);
            AppointmentTypesByMonth newMonths4 = new AppointmentTypesByMonth
            {
                Month = "April",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths4);
            AppointmentTypesByMonth newMonths5 = new AppointmentTypesByMonth
            {
                Month = "May",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths5);
            AppointmentTypesByMonth newMonths6 = new AppointmentTypesByMonth
            {
                Month = "June",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths6);
            AppointmentTypesByMonth newMonths7 = new AppointmentTypesByMonth
            {
                Month = "July",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths7);

            AppointmentTypesByMonth newMonths8 = new AppointmentTypesByMonth
            {
                Month = "August",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths8);
            AppointmentTypesByMonth newMonths9 = new AppointmentTypesByMonth
            {
                Month = "September",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths9);
            AppointmentTypesByMonth newMonths10 = new AppointmentTypesByMonth
            {
                Month = "October",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths10);
            AppointmentTypesByMonth newMonths11 = new AppointmentTypesByMonth
            {
                Month = "November",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths11);
            AppointmentTypesByMonth newMonths12 = new AppointmentTypesByMonth
            {
                Month = "December",
                Presentation = 0,
                Planning = 0,
                Scrum = 0,
                Review = 0
            };
            appointmentMonthsBindingList.Add(newMonths12);
            foreach (Appointment appointment in Appointment.AllAppointments)
            {
                int i = appointment.Date.Month - 1;
                switch (appointment.Type)
                {
                    case "Presentation":
                        appointmentMonthsBindingList[i].Presentation++;
                        break;
                    case "Planning":
                        appointmentMonthsBindingList[i].Planning++;
                        break;
                    case "Scrum":
                        appointmentMonthsBindingList[i].Scrum++;
                        break;
                    case "Review":
                        appointmentMonthsBindingList[i].Review++;
                        break;
                }
            }
        }

        public override string ToString() =>
            $"{Month}, " +
            $"{Presentation}, " +
            $"{Planning}, " +
            $"{Scrum}, " +
            $"{Review}";
    }
}
