namespace MVC_CS_API.Utils
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime dateOfBirth)
        {
            try
            {
                var today = DateTime.Now;
                var date = today.Year - dateOfBirth.Year;
                return date;
            }
            catch
            {
                return 0;
            }
        }
    }
}
