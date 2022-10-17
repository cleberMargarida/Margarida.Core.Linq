using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Margarida.Core.Linq.Tests
{
    [TestClass]
    public class ForEntensionsTests
    {
        public class Foo { public int Bar { get; set; } };

        [TestMethod]
        public void TestIterationInteger()
        {
            var list = new List<int>();

            foreach (var i in 0..9)
            {
                list.Add(i);
            }

            list.Contains(0, 1, 2, 3).Should().BeTrue();
        }

        [TestMethod]
        public void TestIterationReferencedType()
        {
            var foos1 = new[] { new Foo { Bar = 1 } };
            var foos2 = new[] { new Foo { Bar = 2 } };

            foreach (var i in (foos1, foos2))
            {
                i.Item1.Bar.Should().Be(1);
                i.Item2.Bar.Should().Be(2);
            }
        }

        [TestMethod]
        public void TestIterationReferencedTypeWithDifferentSizeOfList()
        {
            var foos1 = new[] { new Foo { Bar = 1 } };
            var foos2 = new[] { new Foo { Bar = 2 }, new Foo { Bar = 3 } };

            foreach (var i in (foos1, foos2))
            {
                i.Item1.Bar.Should().Be(1);
                i.Item2.Bar.Should().Be(2);
            }
        }
    }
}
