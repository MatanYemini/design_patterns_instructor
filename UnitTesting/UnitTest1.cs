using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestFixture]
        public class FirstTestSuite
        {
            [Test]
            public void Test()
            {
                var pf = new PersonFactory();

                var p1 = pf.CreatePerson("Chris");
                Assert.That(p1.Name, Is.EqualTo("Chris"));
                Assert.That(p1.Id, Is.EqualTo(0));

                var p2 = pf.CreatePerson("Sarah");
                Assert.That(p2.Id, Is.EqualTo(1));
            }
        }
    }
}
}
