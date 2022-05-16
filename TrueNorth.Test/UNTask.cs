using NUnit.Framework;
using System.Net.Http;
using TrueNorth.Core.Hipsum;

namespace TrueNorth.Test
{
    public class UNTask
    {
        public HttpClient client { get; set; }
        [SetUp]
        public void Setup()
        {
            client = new HttpClient() { BaseAddress = new System.Uri("https://hipsum.co/") };

        }

        [Test]
        public void GetTask()
        {
             
        }

        public void Hipsum_GetMany_three()
        {
            var a = new Hipsum();

            var b = a.GetMany(client, 3);

            Assert.IsNotNull(b);
            Assert.AreEqual(3, b.Count);
        }
        public void Hipsum_GetMany_Cero()
        {
            var a = new Hipsum();

            var b = a.GetMany(client, 0);

            Assert.IsNotNull(b);
            Assert.AreEqual(3, b.Count);
        }

    }
}