using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SonarQubeExperiments.Tests
{
    public class ModelX : ModelWrapperBase
    {
        public string XField { get; set; }
    }

    public class ModelY : ModelWrapperBase
    {
        public string YField { get; set; }
    }

    public class ModelZ : ModelWrapperBase
    {
        public string ZField { get; set; }
    }

    [TestFixture]
    public class ExampleUsageTests
    {
        [Test]
        public void ExampleUsageTest()
        {
            var a = new ModelX() { XField = "A", Id = Guid.NewGuid(), Name = "A" };
            var b = new ModelY() { YField = "B", Id = Guid.NewGuid(), Name = "B", Parent = a};
            var c = new ModelZ() { ZField = "C", Id = Guid.NewGuid(), Name = "C", Parent = b};
            var d = new ModelY() { YField = "D", Id = Guid.NewGuid(), Name = "D", Parent = b};

            var x = c.GetAncestorOrSelf<ModelX>();
            var y = d.GetAncestorOrSelf<ModelY>();

            Assert.AreSame(a, x);
            Assert.AreSame(d, y);
        }
    }
}
