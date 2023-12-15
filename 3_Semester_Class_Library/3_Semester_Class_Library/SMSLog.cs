using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    public class SMSLog
    {
        public const int ValidId = 1;
        public const int InvalidId = 0;
        public const int ValidTlf = 53343773;
        public const int ShortTlf = 1234;
        public const int LongTlf = 1234567890;

        public int Id { get; set; }
        public int Tlf { get; set; }

        public SMSLog() { }

        public void Validate()
        {

        }

        public void ValidateId()
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id cannot be below 1");
            }
        }

        public void ValidateTlf()
        {
            if (Tlf.ToString().Length > 8)
            {
                throw new ArgumentOutOfRangeException("Phone number can't be more than 8 digits.");
            }

            if (Tlf.ToString().Length < 8)
            {
                throw new ArgumentOutOfRangeException("Phone number can't be less than 8 digits.");
            }
        }
    }
}
