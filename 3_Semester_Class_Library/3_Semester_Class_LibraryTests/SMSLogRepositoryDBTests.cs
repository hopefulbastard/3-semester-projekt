using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3_Semester_Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library.Tests
{
    //Magnus + Milo

    [TestClass()]
    public class SMSLogRepositoryDBTests
    {
        [TestMethod()]
        public void SMSLogTest()
        {
            SMSLog smsl = new SMSLog()
            {
                Id = SMSLog.ValidId,
                Tlf = SMSLog.ValidTlf
            };

            Assert.AreEqual(SMSLog.ValidId, smsl.Id);
            Assert.AreEqual(SMSLog.ValidTlf, smsl.Tlf);
        }

        [TestMethod()]
        public void ValidateTestSuccess()
        {
            SMSLog smsl = new SMSLog()
            {
                Id = SMSLog.ValidId,
                Tlf = SMSLog.ValidTlf
            };

            smsl.Validate();
        }

        [TestMethod()]
        [DataRow(SMSLog.InvalidId, SMSLog.ValidTlf)]
        [DataRow(SMSLog.ValidId, SMSLog.ShortTlf)]
        [DataRow(SMSLog.ValidId, SMSLog.LongTlf)]
        public void ValidateTestOutOfRange(int id, int tlf)
        {
            SMSLog smsl = new SMSLog()
            {
                Id = id,
                Tlf = tlf
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => smsl.Validate());
        }

        [TestMethod()]
        public void ValidateIdTestSuccess()
        {
            {
                SMSLog smsl = new SMSLog()
                {
                    Id = SMSLog.ValidId,
                    Tlf = SMSLog.ValidTlf
                };

                smsl.ValidateId();
            }
        }

        [TestMethod()]
        public void ValidateIdTestOutOfRange()
        {
            SMSLog smsl = new SMSLog()
            {
                Id = SMSLog.InvalidId,
                Tlf = SMSLog.ValidTlf
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => smsl.ValidateId());
        }

        [TestMethod()]
        public void ValidateTlfTestSuccess()
        {
            SMSLog smsl = new SMSLog()
            {
                Id = SMSLog.ValidId,
                Tlf = SMSLog.ValidTlf
            };

            smsl.ValidateTlf();
        }

        [TestMethod()]
        [DataRow(SMSLog.ShortTlf)]
        [DataRow(SMSLog.LongTlf)]
        public void ValidateTlfTestOutOfRange(int tlf)
        {
            SMSLog smsl = new SMSLog()
            {
                Id = SMSLog.ValidId,
                Tlf = tlf
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => smsl.ValidateTlf());
        }
    }
}