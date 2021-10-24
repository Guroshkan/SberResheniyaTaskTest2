using System;
using System.Collections.Generic;

namespace SberResheniyaTestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = GetCompany();
            Employee employee = GetEmployee();

            DateTime DateRecruitment = new DateTime(2020, 4, 1);//дата приема на работу
            DateTime? DateDismissal = null;//дата увольнения
            uint Salary = 50000;// зарплата
            company.AddWorker(employee, DateRecruitment, DateDismissal, Salary);//добавляем сотрудника в компанию

            DateTime FirstDayInMonth = new DateTime(2020, 5, 1);// первый день месяца рассчета
            DateTime LastDayInMonth = new DateTime(2020, 5, 31);// последний день месяца рассчета

            int Prepayment = BookKeeping.CalculatePrepayment(employee, company, FirstDayInMonth, LastDayInMonth); // предоплата
            // для сотрудника в компании за определенный период
            Console.WriteLine($"Для работника {employee.Name} в компании {company.GetName()} аванс за период" +
                $" от {FirstDayInMonth} до {LastDayInMonth} составил {Prepayment}");
        }

        static Company GetCompany()
        {
            string NameCompany = "Company1";//наименование компании
            uint PersentPrepayment = 50;//процент допустимого аванса
            bool UseAdvanceDay = true;//назначается ли аванс в определенный день
            uint DayAdvancePayment = 20;//день назначения аванса
            uint MinWorkedDays = 5;//минимальное количество отработанных дней, необходимое для получения аванса
            Dictionary<Profession, List<DayOfWeek>> WeekendDays = new Dictionary<Profession, List<DayOfWeek>>();
            //стандартные выходные для различных профессий
            WeekendDays.Add(Profession.engineer, new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Saturday });
            WeekendDays.Add(Profession.cleaner, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            WeekendDays.Add(Profession.manager, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Thursday });
            WeekendDays.Add(Profession.director, new List<DayOfWeek>() { });
            return new Company(NameCompany, PersentPrepayment, UseAdvanceDay, DayAdvancePayment, MinWorkedDays, WeekendDays);
        }

        static Employee GetEmployee()
        {
            string NameEmployee = "Employee1";// наименование сотрудника
            Profession ProfessionEmployee = Profession.engineer; // профессия сотрудника
            DateTime FirstDaySick = new DateTime(2020, 5, 6);//начало болезни сотрудника
            DateTime LastDaySick = new DateTime(2020, 5, 12);//конец болезни сотрудника
            List<DateTime> sickLeave = new List<DateTime>();// больничный сотрудника
            for (DateTime currentDay = FirstDaySick; currentDay <= LastDaySick; currentDay = currentDay.AddDays(1))
            {
                sickLeave.Add(currentDay);
            }
            Employee employee = new Employee(NameEmployee, ProfessionEmployee);
            employee.SetSickLeaveDays(sickLeave);//учитываем больничные дни
            return employee;
        }
    }
}
