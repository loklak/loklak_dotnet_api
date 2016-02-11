using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoklakDotNet;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LoklakDotNetTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task status()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.status();
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("system"));
        }

        [TestMethod]
        public async Task hello()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.hello();
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("status"));
        }

        [TestMethod]
        public async Task peers()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.peers();
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("peers"));
            Assert.IsTrue(((JArray)d.GetValue("peers")).Count >= 0);
        }

        [TestMethod]
        public async Task geocode()
        {
            Loklak loklak = new Loklak();
            var p = new List<string>();
            p.Add("Delhi");
            p.Add("Berlin");
            var result = await loklak.geocode(p);
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("locations"));
            Assert.AreEqual(((JObject)(((JObject)d.GetValue("locations")).GetValue("Delhi"))).GetValue("country_code").ToString(),"IN");
            Assert.AreEqual(((JObject)(((JObject)d.GetValue("locations")).GetValue("Berlin"))).GetValue("country_code").ToString(), "DE");
        }

        [TestMethod]
        public async Task user()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.user("loklak_app", 5, 5);
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("user"));
            Assert.AreEqual(((JObject)(((JObject)d.GetValue("user")))).GetValue("id").ToString(), "3090229939");
            Assert.IsNotNull(d.Property("topology"));
            Assert.IsTrue(((JArray)(((JObject)(d.GetValue("topology"))).GetValue("following"))).Count >= 5);
            Assert.IsTrue(((JArray)(((JObject)(d.GetValue("topology"))).GetValue("followers"))).Count >= 5);
        }

        [TestMethod]
        public async Task search()
        {
            Loklak loklak = new Loklak();
            var st = new LoklakSearchTerm();
            st.terms = "loklak";
            //st.since = DateTime.Now;
            //st.until = DateTime.Now;
            //st.since.AddMonths(-2);
            var result = await loklak.search(st);
            var d = JObject.Parse(result);
            Assert.IsNotNull(d.Property("search_metadata"));
            Assert.IsTrue(((JArray)d.GetValue("statuses")).Count > 0);

        }

        [TestMethod]
        public async Task markdown()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.markdown("hello");
            Assert.IsNotNull(result);

        }
    }
}
