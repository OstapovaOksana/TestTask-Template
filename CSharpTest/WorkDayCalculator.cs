using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            List<DateTime> allDatesInWeekends = new List<DateTime>();

            DateTime currentDate = new DateTime();
            if (startDate != null && dayCount > 0)
            {
                currentDate = startDate;
                if (weekEnds != null)
                {
                    foreach (WeekEnd weekends in weekEnds)
                    {
                        for (DateTime date = weekends.StartDate; date <= weekends.EndDate; date = date.AddDays(1))
                        {
                            allDatesInWeekends.Add(date);
                        }
                    }

                    while (dayCount > 0)
                    {
                        if (allDatesInWeekends.Contains(currentDate))
                        {
                            currentDate = currentDate.AddDays(1);
                        }
                        else
                        {
                            dayCount -= 1;
                            if (dayCount > 0)
                            {
                                currentDate = currentDate.AddDays(1);
                            }
                        }

                    }
                }
                else
                {
                    currentDate = currentDate.AddDays(dayCount - 1);
                }
            }

            return currentDate;
        }
    }
}
