using System;
using System.Collections.Generic;

namespace SberResheniyaTestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string NameCompany = "Company1";
            uint PersentPrepayment = 50;
            bool UseAdvanceDay = true;
            uint DayAdvancePayment = 20;
            uint MinWorkedDays = 5;
            Dictionary<Profession, List<DayOfWeek>> WeekendDays = new Dictionary<Profession, List<DayOfWeek>>();
            WeekendDays.Add(Profession.engineer, new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Saturday });
            WeekendDays.Add(Profession.cleaner, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            WeekendDays.Add(Profession.manager, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Thursday });
            WeekendDays.Add(Profession.director, new List<DayOfWeek>() { });
            Company company = new Company(NameCompany, PersentPrepayment, UseAdvanceDay, DayAdvancePayment, MinWorkedDays, WeekendDays);

            string NameEmployee = "Employee1";
            Profession ProfessionEmployee = Profession.engineer;

            Employee employee = new Employee(NameEmployee,ProfessionEmployee);

            DateTime DateRecruitment = new DateTime(2020, 4, 1);
            DateTime? DateDismissal = null;
            uint Salary = 50000;

            company.AddWorker(employee, DateRecruitment, DateDismissal, Salary);

            DateTime FirstDayInMonth = new DateTime(2020, 5, 1);
            DateTime LastDayInMonth = new DateTime(2020, 6, 1);

            int Prepayment = BookKeeping.CalculatePrepayment(employee, company, FirstDayInMonth, LastDayInMonth);
            Console.WriteLine($"Для работника {employee.Name} в компании {company.GetName()} аванс за период" +
                $" от {FirstDayInMonth} до {LastDayInMonth} составил {Prepayment}");
        }
    }
}
