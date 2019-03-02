using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMySQLC969
{
    class RndmApptAvlblTimeGen
    {
        static Random rand = new Random();
        int howManyAppointmentsExist = rand.Next(0, 4);
        public string appointment;
        public RndmApptAvlblTimeGen()
        {
        }
        public string ReturnAppointment()
        {
            int appointmentHour = rand.Next(10, 19);
            int appointmentMinute = rand.Next(1, 5);
            {
                if (appointmentHour == 18)
                { appointmentMinute = 00; } // 4pm is last hour. We wouldnt want an appointment being past 4:00 if close at 5:00
                if (appointmentMinute == 1)
                { appointmentMinute = 15; }
                else if (appointmentMinute == 2)
                { appointmentMinute = 00; }
                else if (appointmentMinute == 3)
                { appointmentMinute = 00; } // Two 0s here to increase the chance of an appointment being rounded to the hour.
                else if (appointmentMinute == 4)
                { appointmentMinute = 30; }
                else if (appointmentMinute == 5)
                { appointmentMinute = 45; }
            }

            if (appointmentMinute == 0)
            {
                appointment = appointmentHour.ToString() + ":" + appointmentMinute.ToString() + appointmentMinute.ToString() + ":00"; // Since were using ints.. int x = 00 would actually change to 19:"0":00 in the date format. This forces 19:00:00
            }
            else if (appointmentMinute != 0)
            {
                appointment = appointmentHour.ToString() + ":" + appointmentMinute.ToString() + ":00"; // Add together hour+minute+seconds to make a time.
            }
            return appointment;
        }
    }
}
