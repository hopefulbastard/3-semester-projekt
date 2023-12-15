using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    public class SikkerhedsLog
    {

        public const int ValidId = 1;
        public const int InvalidId = 0;
        public const string ValidTidspunkt = "14-06-2024 15:13";
        public const string LongTidspunkt = "01-01-2023 00:00.";
        public const string ShortTidspunkt = "1-01-2023 00:00";
        public const string ArgumentTidspunkt = "Ol-Ol-SOSE OO:OO";
        public const string NullTidspunkt = null;

        public int Id { get; set; }
        public string Tidspunkt { get; set; }

        public SikkerhedsLog() { }

        public void Validate()
        {
            ValidateId();
            ValidateTidspunkt();
        }
        public void ValidateId()
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id cannot be below 1");
            }
        }
        public void ValidateTidspunkt()
        {
            if (Tidspunkt == null)
            {
                throw new ArgumentNullException("Time cannot be null");
            }

            if (Tidspunkt.Length < 16)
            {
                throw new ArgumentOutOfRangeException("Time must be described with exactly 16 characters");
            }
            else if (Tidspunkt.Length > 16)
            {
                throw new ArgumentOutOfRangeException("Time must be described with exactly 16 characters");
            }

            if (Regex.IsMatch(Tidspunkt, ".*?[a-zA-Z].*?") == true)
            {
                throw new ArgumentException("Time cannot contain letters");
            }
        }
    }
}
