using System;
using System.Collections.Generic;

namespace SberResheniyaTestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company1 = GetCompany1();
            Employee employee1 = GetEmployee1();
            Company company2 = GetCompany2();
            Employee employee2 = GetEmployee2();

            DateTime DateRecruitmentEmployee1 = new DateTime(2020, 4, 1);//дата приема на работу сотрудника1
            DateTime? DateDismissalEmloyee1 = null;//дата увольнениясотрудника1
            uint SalaryEmployee1 = 50000;// зарплата сотрудника1
            company1.AddWorker(employee1, DateRecruitmentEmployee1, DateDismissalEmloyee1, SalaryEmployee1);//добавляем сотрудника1 в компанию1


            DateTime DateRecruitmentEmployee2 = new DateTime(2020, 5, 3);//дата приема на работу сотрудника2
            DateTime? DateDismissalEmloyee2 = null;//дата увольнения сотрудника2
            uint SalaryEmployee2 = 100000;// зарплата сотрудника2
            company2.AddWorker(employee2, DateRecruitmentEmployee2, DateDismissalEmloyee2, SalaryEmployee2);//добавляем сотрудника2 в компанию2

            DateTime FirstDayInMonth = new DateTime(2020, 5, 1);// первый день месяца рассчета
            DateTime LastDayInMonth = new DateTime(2020, 5, 31);// последний день месяца рассчета

            int PrepaymentEmployee1 = BookKeeping.CalculatePrepayment(employee1, company1, FirstDayInMonth, LastDayInMonth); // предоплата
            // для сотрудника 1 в компании 1 за определенный период
            Console.WriteLine($"Для работника {employee1.Name} в компании {company1.GetName()} аванс за период" +
                $" от {FirstDayInMonth} до {LastDayInMonth} составил {PrepaymentEmployee1}");
            int PrepaymentEmployee2 = BookKeeping.CalculatePrepayment(employee2, company2, FirstDayInMonth, LastDayInMonth); // предоплата
            // для сотрудника 2 в компании 2 за определенный период
            Console.WriteLine($"Для работника {employee2.Name} в компании {company2.GetName()} аванс за период" +
                $" от {FirstDayInMonth} до {LastDayInMonth} составил {PrepaymentEmployee2}");
        }

        static Company GetCompany1()
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

        static Employee GetEmployee1()
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

        static Company GetCompany2()
        {
            string NameCompany = "Company2";//наименование компании
            uint PersentPrepayment = 30;//процент допустимого аванса
            bool UseAdvanceDay = true;//назначается ли аванс в определенный день
            uint DayAdvancePayment = 8;//день назначения аванса
            uint MinWorkedDays = 5;//минимальное количество отработанных дней, необходимое для получения аванса
            Dictionary<Profession, List<DayOfWeek>> WeekendDays = new Dictionary<Profession, List<DayOfWeek>>();
            //стандартные выходные для различных профессий
            WeekendDays.Add(Profession.engineer, new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Saturday });
            WeekendDays.Add(Profession.cleaner, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            WeekendDays.Add(Profession.manager, new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Thursday });
            WeekendDays.Add(Profession.director, new List<DayOfWeek>() { });
            return new Company(NameCompany, PersentPrepayment, UseAdvanceDay, DayAdvancePayment, MinWorkedDays, WeekendDays);
        }

        static Employee GetEmployee2()
        {
            string NameEmployee = "Employee2";// наименование сотрудника
            Profession ProfessionEmployee = Profession.director; // профессия сотрудника
            DateTime FirstDaySick = new DateTime(2020, 5, 12);//начало болезни сотрудника
            DateTime LastDaySick = new DateTime(2020, 5, 14);//конец болезни сотрудника
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
