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
            if(firstDayInMonth.Month != lastDayInMonth.Month)
            {
                throw new IncorrectDateIntervalException("Interval should only be within one month.");
            }
            int Prepayment = 0;
            uint PersentPrepayment = company.GetPersentPrapayment();
            if (PersentPrepayment == 0)// если процент аванса равен 0 - то и аванса нет
            {
                return Prepayment;
            }

            if (company.IsAdvanceDayUsing())// если аванс назначается в отдельный день - сдвигаем границу до этого дня
            {
                DateTime newLastDay = new DateTime(lastDayInMonth.Year, lastDayInMonth.Month, ((int)company.GetDayAdvancePayment()));
                lastDayInMonth = newLastDay;
            }

            DateTime DayRecruitment = company.GetDayRecruitmentWorker(employee);
            if (DayRecruitment > firstDayInMonth)//если сотрудник принят после даты начала интервала - сдвигаем границу
            {
                firstDayInMonth = DayRecruitment;
            }

            DateTime? DayDismissal = company.GetDayDismissalWorker(employee);
            if (DayDismissal != null && DayDismissal < lastDayInMonth)//если сотрудник уволен до даты назначения аванса - он его не получает
            {
                return Prepayment;
            }

            int countWorkedDays = employee.CountWorkingDays(firstDayInMonth, lastDayInMonth);//количество отработанных дней сотрудником
            if(countWorkedDays < ((int)company.GetMinWorkedDays())) // если количество отработанных дней меньше необходимого для получения аванса
            {                                                       // сотрудник его не получает
                return Prepayment;
            }

            uint salary = company.GetSalary(employee); // зарплата сотрудника

            int planWorkingDays = company.CountWorkingDays(employee, firstDayInMonth, lastDayInMonth);//максимальное количество рабочих дней для сотрудника
                                                                                                      // по рабочему плану
            Prepayment = Convert.ToInt32((Convert.ToDouble((int)salary)) / planWorkingDays * countWorkedDays * ((int)PersentPrepayment) / 100);
            //сумма аванса
            return Prepayment;
        }
    }
    class IncorrectDateIntervalException : Exception
    {
        public IncorrectDateIntervalException(string message) : base(message){}
    }
}
