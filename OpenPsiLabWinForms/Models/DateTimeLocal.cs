using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPsiLabWinForms
{
    internal class DateTimeLocal
    {        
        public DateTime LocalDateTime { get; set; }

        public int Day
        {
            get
            {
                return LocalDateTime.Day;
            }
        }

        public int Hour
        {
            get
            {
                return LocalDateTime.Hour;
            }
        }

        public double HourOffsetFromUT { get; set; }
        
        public int Millisecond
        {
            get
            {
                return LocalDateTime.Millisecond;
            }
        }

        public int Minute
        {
            get
            {
                return LocalDateTime.Minute;
            }
        }

        public int Month
        {
            get
            {
                return LocalDateTime.Month;
            }
        }

        public int Second
        {
            get
            {
                return LocalDateTime.Second;
            }
        }

        public int Year
        {
            get
            {
                return LocalDateTime.Year;
            }
        }

        public DateTimeLocal(DateTime dateTimeLocal, double hourOffsetFromUT)
        {
            LocalDateTime = dateTimeLocal;
            HourOffsetFromUT = hourOffsetFromUT;
        }

        private int extractSign(double number)
        {
            if (number < 0)
                return -1;
            else
                return 1;
        }

        public double ToJulianDateUT()
        {
            DateTime dateToConvert = new DateTime(LocalDateTime.Year, LocalDateTime.Month, LocalDateTime.Day,
            LocalDateTime.Hour, LocalDateTime.Minute, LocalDateTime.Second, LocalDateTime.Millisecond, DateTimeKind.Unspecified);

            dateToConvert = dateToConvert.Subtract(new TimeSpan(0, (int)HourOffsetFromUT, 0, 0, 0));

            double k = dateToConvert.Year;
            double m = dateToConvert.Month;
            double i = dateToConvert.Day;
            double hour = dateToConvert.Hour;
            double minute = dateToConvert.Minute;
            double second = dateToConvert.Second;
            double millisecond = dateToConvert.Millisecond;
            double JD;

            // Formula from US Naval Observatory
            // http://aa.usno.navy.mil/faq/docs/JD_Formula.php
            // http://www.usno.navy.mil/USNO/astronomical-applications/astronomical-information-center/julian-date-form
            // JD = 367K -             <(7     (K+            <(M + 9  )  /12  >)) / 4  > +           <(275     M) / 9  > + I + 1721013.5 +  UT                                                               / 24   - 0.5          sign(100     K + M - 190002.5) + 0.5
            JD = 367.0 * k - Math.Floor((7.0 * (k + Math.Floor((m + 9.0) / 12.0))) / 4.0) + Math.Floor((275.0 * m) / 9.0) + i + 1721013.5 + (hour + (minute / 60) + (second / 3600)) / 24.0 - 0.5 * extractSign(100.0 * k + m - 190002.5) + 0.5;

            return JD;
        }

        public DateTimeLocal ToUniversalTime()
        {
            DateTime dt;
            DateTimeLocal dtUT;

            dt = new DateTime(Year, Month, Day, Hour, Minute, Second, DateTimeKind.Unspecified);
            dt = dt.AddHours(System.Convert.ToDouble(-1 * HourOffsetFromUT + Hour));
            dtUT = new DateTimeLocal(dt, 0);

            return dtUT;
        }
    }
}
