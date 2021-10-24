using System;
using System.Collections.Generic;
using System.Text;

namespace SberResheniyaTestTask2
{
    struct DateRecruitmentDismissal
    {
        public DateTime DateRecruitment { get; }
        public DateTime? DateDismissal { get; }
        public DateRecruitmentDismissal(DateTime dateRecruitment, DateTime? dateDismissal)
        {
            this.DateRecruitment = dateRecruitment;
            this.DateDismissal = dateDismissal;
        }
    }
}
