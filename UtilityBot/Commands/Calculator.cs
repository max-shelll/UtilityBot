using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBot.Commands
{
    public class Calculator
    {
        public static int Calc(string message)
        {
            int result = 0;
            try
            {
                string s = message.ToString();

                string[] subs = s.Split(' ');

                foreach (var item in subs)
                {
                    int num = Convert.ToInt32(item);
                    result += num;
                }
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось приобразовать строку в число {ex}");
            }
            return result;
        }
    }
}
