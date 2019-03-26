using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaTaekwonDo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Validation.Tests
{
    [TestClass()]
    public class NevEllenorzesTests
    {
        [TestMethod()]
        public void uresNev()
        {
            try
            {
                NevEllenorzes ne = new NevEllenorzes("");
                ne.Ellenorzes();
            }
            catch (myException.nevEllenorzoKivetel nek)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Üres névre nem jó kivételt dob!");
            }
            Assert.Fail("Üres névre nem dob kivételt!");
        }
        [TestMethod()]
        public void elsoNemNagybetu()
        {
            try
            {
                NevEllenorzes ne = new NevEllenorzes("admin");
                ne.Ellenorzes();
            }
            catch (myException.nevEllenorzoKivetel nek)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Kisbetűvel kezdődő névre nem jó kivételt dob.");
            }
            Assert.Fail("Kisbetűs névre nem dob kivételt!");
        }
        [TestMethod()]
        public void tobbiNagyBetu()
        {
            try
            {
                NevEllenorzes ne = new NevEllenorzes("ADMIN");
                ne.Ellenorzes();
            }
            catch (myException.nevEllenorzoKivetel nek)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Ha nem csak az első betű nagybetű, akkor nem jó kivételt dob");
            }
            Assert.Fail("Nagybetűs névre nem dob kivételt");
        }
        [TestMethod()]
        public void tartalmazSzamot()
        {
            try
            {
                NevEllenorzes ne = new NevEllenorzes("Adm1n");
                ne.Ellenorzes();
            }
            catch (myException.nevEllenorzoKivetel nek)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Ha számot tartalmaz, akkor nem jó kivételt dob");
            }
            Assert.Fail("Számos névre nem dob kivételt");
        }
    }
}