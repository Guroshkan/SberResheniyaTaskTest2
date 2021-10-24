using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SberResheniyaTestTask2
{
    class Employee
    {
        public string Name { get; } 
        private Profession _Profession;
        private List<DayOfWeek> _WeekendDay;
        private List<DateTime> _SickLeaveDays;
        private Company _Company;

        public Employee(string name, Profession profession)
        {
            this.Name = name;
            this._Profession = profession;
            this._SickLeaveDays = new List<DateTime>();
            this._WeekendDay = new List<DayOfWeek>();
        }

        public Profession GetProfession()
        {
            return this._Profession;
        }

        public void SetSickLeaveDays(List<DateTime> sickLeaveDays)
        {
            this._SickLeaveDays = sickLeaveDays;
        }

        public void SetCompany(Company company)
        {
            this._Company = company;
            this._WeekendDay = company.WeekendDays[this._Profession];
        }

        private List<DateTime> WorkedDays(DateTime startPeriod, DateTime endPeriod)
        {
            List<DateTime> workingDays = new List<DateTime>(); 
            for (DateTime currecntDay = startPeriod; currecntDay <= endPeriod; currecntDay = currecntDay.AddDays(1))
            {
                workingDays.Add(currecntDay);
            }

            return workingDays.Where(d => !(this._WeekendDay.Contains(d.DayOfWeek) || this._SickLeaveDays.Contains(d))).ToList();
        }

        public int CountWorkingDays(DateTime startPeriod, DateTime endPeriod)
        {
            return this.WorkedDays(startPeriod, endPeriod).Count;
        }
    }
}
