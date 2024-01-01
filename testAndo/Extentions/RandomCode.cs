using API_INDIA.Models;

namespace testAndo.Extentions
{
    public class RandomCode
    {
        private static Random random = new Random();

        public static string GenerateUniqueCode(int length)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string code = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return code;
        }
    }
}
