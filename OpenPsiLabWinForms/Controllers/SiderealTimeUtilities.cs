using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace OpenPsiLabWinForms
{
    public class SiderealTimeUtilities
    {
        public DateTime getSiderealTime(
            DateTimeOffset myDateToConvert, double longitude)
        {
            double jd;
            double jd0;
            double GMST;
            double D;
            double D0;
            double H;
            double T;
            double eqeq;
            double GAST;
            double Ω;
            double L;
            double ε;
            double Δψ;
            int sideHour;
            int sideMinute;
            int sideSecond;
            DateTime sideDateTime;

            // Based on the formulas from the US Naval Observatory
            // https://aa.usno.navy.mil/faq/GAST
            // Sideral time calculator https://aa.usno.navy.mil/data/siderealtime

            //jd = DateTimeLocal.ToJulianDateUT();
            jd = toJulianDate(myDateToConvert);

            if ((jd - Math.Floor(jd) > 0.5))
                jd0 = Math.Floor(jd) + 0.5;
            else
                jd0 = Math.Floor(jd) - 1 + 0.5;

            D = jd - 2451545.0;
            D0 = jd0 - 2451545.0;
            H = 24 * (jd - jd0);
            T = D / 36525;

            // Greenwich Mean Sidereal Time
            GMST = 6.697374558 + 0.06570982441908 * D0 + 1.00273790935 * H + 0.000026 * Math.Pow(T, 2);

            Ω = 125.04 - 0.052954 * D;
            L = 280.47 + 0.98565 * D;
            ε = 23.4393 - 0.0000004 * D;
            Δψ = -0.000319 * Math.Sin(degreesToRadians(Ω)) - 0.000024 * Math.Sin(degreesToRadians(2 * L));
            eqeq = Δψ * Math.Cos(degreesToRadians(ε));
            // Greenwich Apparent Sidereal Time
            GAST = GMST + eqeq;

            // Reduce GAST to 0 to 24 hour range
            while ((GAST > 24))
                GAST -= 24;
            while ((GAST < 0))
                GAST += 24;

            sideHour = (int)Math.Floor(GAST);
            GAST -= Math.Floor(GAST);
            GAST *= 60;
            sideMinute = (int)Math.Floor(GAST);
            GAST -= Math.Floor(GAST);
            GAST *= 60;
            sideSecond = (int)Math.Floor(GAST);

            sideDateTime = new DateTime(5, 5, 5, sideHour, sideMinute, sideSecond);
            sideDateTime = sideDateTime.AddHours(longitude / 15);

            return sideDateTime;
        }

        public DateTimeOffset getSidereal1300(DateTimeOffset sourceDate, double longitude)
        {
            DateTime currentDTInSidereal = getSiderealTime(sourceDate, longitude);

            //1 solar second = 1.0027430555555557 sidereal seconds
            //1 sidereal second = 0.99726444821496585 solar seconds
            //X = solar noon in sidereal time
            //y = sidereal difference between sidereal 1300 and solar noon in sidereal time
            DateTime side1300 =
                new DateTime(year: 5, month: 5, day: 5, hour: 13, minute: 0, second: 0);
            DateTime side100 =
                new DateTime(year: 5, month: 5, day: 5, hour: 1, minute: 0, second: 0);
            //double solarSecondsDiff;
            TimeSpan siderealTimeDifference = new TimeSpan();

            //Get time difference between DTO and 1300 sidereal 
            //then add or subtract the difference
            Double solarSeconds = 0;
            if (currentDTInSidereal.Hour > 13)
            {
                // x-13 = y
                siderealTimeDifference = -(currentDTInSidereal - side1300);
                //solarSecondsDiff = convertSiderealSecondsToSolar(siderealTimeDifference.TotalSeconds);
                solarSeconds = convertSiderealSecondsToSolar(siderealTimeDifference.TotalSeconds);
            }
            else if (currentDTInSidereal.Hour < 1)
            {
                // 11 hours + (1 - x hours)  = y
                siderealTimeDifference = (new TimeSpan(0, 11, currentDTInSidereal.Minute, 0));
                solarSeconds = - convertSiderealSecondsToSolar(siderealTimeDifference.TotalSeconds);
                //siderealTimeDifference = side100 - currentDTInSidereal;
                //siderealTimeDifference = -(siderealTimeDifference +
                //new TimeSpan(hours: 11, minutes: 0, seconds: 0));
            }
            else if (currentDTInSidereal.Hour <= 13 && currentDTInSidereal.Hour >= 1)
            {
                // 13 - x = y
                siderealTimeDifference = side1300 - currentDTInSidereal;
                solarSeconds = convertSiderealSecondsToSolar(siderealTimeDifference.TotalSeconds);
            }

            //Double solarSeconds = convertSiderealSecondsToSolar(siderealTimeDifference.TotalSeconds);
            long solarTicks = convertSecondsToTicks(solarSeconds);
            
            DateTimeOffset side1300InSolarTime = sourceDate.Add(new TimeSpan(solarTicks));

            //DateTimeOffset side1300InSolarTime2 = sourceDate.Add(new TimeSpan(-solarTicks));

            DateTimeOffset todays1300SideInSolarTime = new DateTimeOffset();
            if (side1300InSolarTime.Day == sourceDate.Day)
            {
                todays1300SideInSolarTime = side1300InSolarTime;
            }
            else if (side1300InSolarTime.Day > sourceDate.Day)
            {
                todays1300SideInSolarTime = subtractSideralDay(side1300InSolarTime);
            }
            else if (side1300InSolarTime.Day < sourceDate.Day)
            {
                todays1300SideInSolarTime = addSideralDay(side1300InSolarTime);
            }
            return todays1300SideInSolarTime;
        }

        private double convertSiderealSecondsToSolar(double siderealSeconds)
        {
            //1 sidereal second = 0.99726444821496585 solar seconds
            return Math.Round(siderealSeconds * 0.99726444821496585);
        }

        public static long convertSecondsToTicks(double seconds)
        {
            double wholeSeconds = Math.Truncate(seconds);
            double subseconds = seconds - wholeSeconds;
            return (long)(wholeSeconds * TimeSpan.TicksPerSecond) + (long)(subseconds * TimeSpan.TicksPerSecond);
        }

        private DateTimeOffset subtractSideralDay(DateTimeOffset sourceTime)
        {
            //86400 seconds in a day
            double sideDayInSolarSeconds = convertSiderealSecondsToSolar(86400);
            long sideDayInSolarTicks = convertSecondsToTicks(sideDayInSolarSeconds);
            return sourceTime.Subtract(new TimeSpan(sideDayInSolarTicks));
        }

        private DateTimeOffset addSideralDay(DateTimeOffset sourceTime)
        {
            //86400 seconds in a day
            double sideDayInSolarSeconds = convertSiderealSecondsToSolar(86400);
            long sideDayInSolarTicks = convertSecondsToTicks(sideDayInSolarSeconds);
            return sourceTime.Add(new TimeSpan(sideDayInSolarTicks));
        }

        private double toJulianDate(DateTimeOffset dateToConvert)
        {
            DateTimeOffset utcDateToConvert = dateToConvert.ToUniversalTime();

            double k = utcDateToConvert.Year;
            double m = utcDateToConvert.Month;
            double i = utcDateToConvert.Day;
            double hour = utcDateToConvert.Hour;
            double minute = utcDateToConvert.Minute;
            double second = utcDateToConvert.Second;
            double millisecond = utcDateToConvert.Millisecond;
            double JD;

            // Formula from US Naval Observatory
            // https://aa.usno.navy.mil/faq/JD_formula
            // Julian date calculator https://aa.usno.navy.mil/data/JulianDate

            // JD = 367K -             <(7     (K+            <(M + 9  )  /12  >)) / 4  > +           <(275     M) / 9  > + I + 1721013.5 +  UT                                                               / 24   - 0.5          sign(100     K + M - 190002.5) + 0.5
            JD = 367.0 * k - Math.Floor((7.0 * (k + Math.Floor((m + 9.0) / 12.0))) / 4.0) + Math.Floor((275.0 * m) / 9.0) + i + 1721013.5 + (hour + (minute / 60) + (second / 3600)) / 24.0 - 0.5 * extractSign(100.0 * k + m - 190002.5) + 0.5;

            return JD;
        }

        private int extractSign(double number)
        {
            if (number < 0)
                return -1;
            else
                return 1;
        }

        private double degreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

    }
}
