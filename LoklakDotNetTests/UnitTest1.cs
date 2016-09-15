using System;
using Xunit;
using LoklakDotNet;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LoklakDotNetTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task status()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.status();
            var d = JObject.Parse(result);
            Assert.NotNull(d.Property("system"));
        }

        [Fact]
        public async Task hello()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.hello();
            var d = JObject.Parse(result);
            Assert.NotNull(d.Property("status"));
        }

        [Fact]
        public async Task peers()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.peers();
            var d = JObject.Parse(result);
            Assert.NotNull(d.Property("peers"));
            Assert.True(((JArray)d.GetValue("peers")).Count >= 0);
        }

        [Fact]
        public async Task geocode()
        {
            Loklak loklak = new Loklak();
            var p = new List<string>();
            p.Add("Delhi");
            p.Add("Berlin");
            var result = await loklak.geocode(p);
            var d = JObject.Parse(result);
            Assert.NotNull(d.Property("locations"));
            Assert.Equal(((JObject)(((JObject)d.GetValue("locations")).GetValue("Delhi"))).GetValue("country_code").ToString(),"IN");
            Assert.Equal(((JObject)(((JObject)d.GetValue("locations")).GetValue("Berlin"))).GetValue("country_code").ToString(), "DE");
        }

        [Fact]
        public async Task user()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.user("loklak_app", 5, 5);
            var d = JObject.Parse(result);
            Assert.NotNull(d.Property("user"));
            Assert.Equal(((JObject)(((JObject)d.GetValue("user")))).GetValue("id").ToString(), "3090229939");
            Assert.NotNull(d.Property("topology"));
            Assert.True(((JArray)(((JObject)(d.GetValue("topology"))).GetValue("following"))).Count >= 5);
            Assert.True(((JArray)(((JObject)(d.GetValue("topology"))).GetValue("followers"))).Count >= 5);
        }

        [Fact]
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
            Assert.NotNull(d.Property("search_metadata"));
            Assert.True(((JArray)d.GetValue("statuses")).Count > 0);

        }

        [Fact]
        public async Task markdown()
        {
            Loklak loklak = new Loklak();
            var result = await loklak.markdown("hello");
            Assert.NotNull(result);

        }
    }
}
