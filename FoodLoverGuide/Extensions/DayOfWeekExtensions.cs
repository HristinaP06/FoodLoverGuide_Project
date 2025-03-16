namespace FoodLoverGuide.Extensions
{
    public static class DayOfWeekExtensions
    {
        private static readonly Dictionary<DayOfWeek, string> BulgarianDays = new()
        {
            { DayOfWeek.Sunday, "Неделя" },
            { DayOfWeek.Monday, "Понеделник" },
            { DayOfWeek.Tuesday, "Вторник" },
            { DayOfWeek.Wednesday, "Сряда" },
            { DayOfWeek.Thursday, "Четвъртък" },
            { DayOfWeek.Friday, "Петък" },
            { DayOfWeek.Saturday, "Събота" }
        };

        public static string ToBulgarian(this DayOfWeek day) => BulgarianDays[day];
    }
}
