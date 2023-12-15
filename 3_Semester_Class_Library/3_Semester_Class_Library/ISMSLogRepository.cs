using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    public interface ISMSLogRepository
    {

        public IEnumerable<SMSLog> Get(int? idFørst = null,
                                              int? idSidst = null,
                                              string? orderBy = null,
                                              bool descending = false);
        public SMSLog Add(SMSLog smsl);
        public SMSLog? Delete(int id);

    }
}
