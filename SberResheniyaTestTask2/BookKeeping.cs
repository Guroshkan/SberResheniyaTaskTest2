using System;
using System.Collections.Generic;
using System.Text;

namespace SberResheniyaTestTask2
{
    enum Profession { engineer, cleaner, manager, director}
    static class BookKeeping
    {
        
        static public int CalculatePrepayment(Employee employee, Company company, DateTime firstDayInMonth, DateTime lastDayInMonth)
        {
            int Prepayment = 0;
            uint PersentPrepayment = company.GetPersentPrapayment();
            if (PersentPrepayment == 0)
            {
                return Prepayment;
            }

            if (company.IsAdvanceDayUsing())
            {
                DateTime newLastDay = new DateTime(lastDayInMonth.Year, lastDayInMonth.Month, ((int)company.GetDayAdvancePayment()));
                lastDayInMonth = newLastDay;
            }

            DateTime? DayDismissal = company.GetDayDismissalWorker(employee);
            if (DayDismissal != null && DayDismissal < lastDayInMonth)
            {
                return Prepayment;
            }

            int countWorkedDays = employee.CountWorkingDays(firstDayInMonth, lastDayInMonth);
            if(countWorkedDays < ((int)company.GetMinWorkedDays()))
            {
                return Prepayment;
            }

            uint salary = company.GetSalary(employee);

            int playWorkingDays = company.CountWorkingDays(employee, firstDayInMonth, lastDayInMonth);

            Prepayment = ((int)salary) / playWorkingDays * countWorkedDays * ((int)PersentPrepayment) / 100;

            return Prepayment;
        }
    }
}
