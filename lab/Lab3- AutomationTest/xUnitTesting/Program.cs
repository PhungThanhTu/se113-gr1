using System;
using System.Linq;

namespace xUnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // check date in month
        public static int checkDateInMonth(int Year,int Month)
        {
            int[] MonthWith31 = {1,3,5,7,8,12}; // month with 31 days 
            int[] MonthWith30 = {4,6,9,11};     // month with 30 days


            if(MonthWith31.Contains(Month)) return 31;
            if(MonthWith30.Contains(Month)) return 30;
            if(Month == 2){
                // leap year is divisible by 400
                if(Year%400 == 0) return 29;
                // year which is divisible by 400 but not by 400 is not leap year
                if(Year%100 == 0) return 28;
                // year which is divisible by 4 is leap year
                if(Year%4 == 0) return 29;
                // the rest is not leap year
                else return 28;
            }
            else return 0; // month is invalid

        }

        // check date
        public static bool checkDate(int Year,int Month, int Day)
        {

            if(Month >= 1 && Month <= 12) // valid month
            {
                if(Day >= 1) // valid day
                {
                    if(Day <= checkDateInMonth(Year,Month)) // compare to maximum days in month
                    {
                        return true;
                    }
                    else return false;
                }
                else return false; // invalid day
            }
            else return false; // invalid month
        }



    }
    
}
