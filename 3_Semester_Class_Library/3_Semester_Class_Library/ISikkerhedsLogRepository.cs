using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    //Magnus + Milo

    public interface ISikkerhedsLogRepository
    {

        public IEnumerable<SikkerhedsLog> Get(int? idFørst = null,
                                              int? idSidst = null,
                                              string? orderBy = null,
                                              bool descending = false);
        public SikkerhedsLog Add(SikkerhedsLog sl);
        public SikkerhedsLog? Delete(int id);

    }
}
