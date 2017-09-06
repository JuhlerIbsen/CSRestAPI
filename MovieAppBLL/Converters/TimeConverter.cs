namespace MovieAppBLL.Converters
{
    public class TimeConverter
    {
        /// <summary>
        ///     Convert seconds to a line of text
        ///     containing hours, minutes and seconds.
        /// </summary>
        /// <param name="duration">Seconds to convert.</param>
        /// <returns>String of hours, minutes and seconds.</returns>
        public static string GetMovieDuration(long duration)
        {
            var second = string.Format("{0}", (duration % 60).ToString("00"));
            var minute = string.Format("{0}", (duration / 60 % 60).ToString("00"));
            var hour = string.Format("{0}", (duration / (60 * 60) % 24).ToString("00"));

            return $"{hour} hours {minute} minutes {second} seconds";
        }
    }
}