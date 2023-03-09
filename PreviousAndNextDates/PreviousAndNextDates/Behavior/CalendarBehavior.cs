using Syncfusion.Maui.Calendar;

namespace PreviousAndNextDates
{
    public class CalendarBehavior : Behavior<SfCalendar>
    {
        private SfCalendar calendar;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable as SfCalendar;
            this.calendar.SelectionChanged += Calendar_SelectionChanged;
        }

        private void Calendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (this.calendar.SelectedDateRange != null)
            {
                var dateRange = (CalendarDateRange)e.NewValue;
                if (dateRange.EndDate == null)
                {
                    dateRange.EndDate = dateRange.StartDate.Value.AddDays(2);
                    dateRange.StartDate = dateRange.StartDate.Value.AddDays(-2);
                }
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.calendar != null)
            {
                this.calendar.SelectionChanged -= Calendar_SelectionChanged;
            }

            this.calendar = null;
        }
    }
}
