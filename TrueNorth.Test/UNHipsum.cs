using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrueNorth.Core.Hipsum;

namespace TrueNorth.Test
{
    public class UNHipsum
    {
        public HttpClient client { get; set; }
        [SetUp]
        public void Setup()
        {
            client = new HttpClient() { BaseAddress = new System.Uri("https://hipsum.co/") };

        }

        [Test]
        public void Hipsum_GetMany_one()
        {
            var a = new Hipsum();

            var b = a.GetMany(client, 1);

            Assert.IsNotNull(b);
            Assert.AreEqual(1, b.Count);
        }

        public void Hipsum_GetMany_three()
        {
            var a = new Hipsum();

            var b = a.GetMany(client, 3);

            Assert.IsNotNull(b);
            Assert.AreEqual(3, b.Count);
        }
        public void Hipsum_GetMany_null()
        {
            var a = new Hipsum();

            var b = a.GetMany(client, null);

            Assert.IsNotNull(b);
            Assert.AreEqual(3, b.Count);
        }
    }
}
