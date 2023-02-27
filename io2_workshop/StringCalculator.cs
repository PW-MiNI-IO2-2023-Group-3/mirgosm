using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io2_workshop
{
    public class StringCalculator
    {
        public static int SumString(string str)
        {
            if (str == String.Empty)
            {
                return 0;
            }


            List<char> sums = new List<char>(){',','\n'};
            if (str.Length > 4)
            {
                if (str.Substring(0,2) =="//")
                {
                    sums.Add(str[2]);
                    str = str.Substring(4);
                }
            }
            
            int retval=0;

            
            string[] arr = str.Split(sums.ToArray());
            
            foreach (string s in arr)
            {
                if (int.Parse(s)<0)
                {
                    throw new ArgumentException();
                }

                if (int.Parse(s) > 1000)
                {
                    retval += 0;
                }
                else
                {
                    retval += int.Parse(s);
                }
                
            }

            return retval;
            //return Int32.Parse(str);
        }
    }
}
