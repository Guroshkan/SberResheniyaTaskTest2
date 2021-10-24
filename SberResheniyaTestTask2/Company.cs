using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SberResheniyaTestTask2
{
    class Company
    {
        private const int MaxPersentAdvancePayment = 100;
        private const int MaxDayAdvancePayment = 28;
        private const int MinWorkedDaysValue = 1;
        private string _Name;
        private uint _PersentPrepayment;
        private Dictionary<Employee, DateRecruitmentDismissal> _Workers;
        private bool _UseAdvanceDay;
        private uint _DayAdvancePayment;
        private uint _MinWorkedDays;
        private Dictionary<Employee, uint> _Salaries;
        public Dictionary<Profession,List<DayOfWeek>> WeekendDays { get; }
        public Company(string name, uint persent, bool useAdvanceDay, uint dayAdvancePayment, uint minWorkedDays, Dictionary<Profession, List<DayOfWeek>> weekendDays)
        {
            this._Name = name;
            this._PersentPrepayment = persent <= MaxPersentAdvancePayment ? persent : MaxPersentAdvancePayment;
            this._UseAdvanceDay = useAdvanceDay;
            this._DayAdvancePayment = dayAdvancePayment <= MaxDayAdvancePayment ? dayAdvancePayment : MaxDayAdvancePayment;
            this._MinWorkedDays = minWorkedDays < MinWorkedDaysValue ? MinWorkedDaysValue :
                                    minWorkedDays > MaxDayAdvancePayment ? MaxDayAdvancePayment : minWorkedDays;
            this.WeekendDays = weekendDays;
            this._Workers = new Dictionary<Employee, DateRecruitmentDismissal>();
            this._Salaries = new Dictionary<Employee, uint>();
        }
        public string GetName()
        {
            return this._Name;
        }
        public uint GetPersentPrapayment()
        {
            return this._PersentPrepayment;
        }
        public void AddWorker(Employee employee, DateTime dateRecruitment, DateTime? dateDismissal, uint salary)
        {
            this._Workers.Add(employee, new DateRecruitmentDismissal(dateRecruitment, dateDismissal));
            this._Salaries.Add(employee, salary);
            employee.SetCompany(this);
        }
        public bool EmployeeIsWorker(Employee employee)
        {
            return this._Workers.ContainsKey(employee);
        }
        public bool IsAdvanceDayUsing()
        {
            return this._UseAdvanceDay;
        }
        public uint GetDayAdvancePayment()
        {
            return this._DayAdvancePayment;
        }
        public uint GetMinWorkedDays()
        {
            return this._MinWorkedDays;
        }
        public DateTime? GetDayDismissalWorker(Employee employee)
        {
            return this._Workers[employee].DateDismissal;
        }
        public DateTime GetDayRecruitmentWorker(Employee employee)
        {
            return this._Workers[employee].DateRecruitment;
        }
        public uint GetSalary(Employee employee)
        {
            return this._Salaries[employee];
        }
        private List<DateTime> WorkedDays(Employee employee, DateTime startPeriod, DateTime endPeriod)
        {
            List<DateTime> workingDays = new List<DateTime>(); 
            for (DateTime currecntDay = startPeriod; currecntDay <= endPeriod; currecntDay = currecntDay.AddDays(1))
            {
                workingDays.Add(currecntDay);
            }
            return workingDays.Where(d => !this.WeekendDays[employee.GetProfession()].Contains(d.DayOfWeek)).ToList();
        }

        public int CountWorkingDays(Employee employee, DateTime startPeriod, DateTime endPeriod)
        {
            return this.WorkedDays(employee, startPeriod, endPeriod).Count;
        }
    }
}
