using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Margarida.Core.Linq.Tests
{
    [TestClass]
    public class SelectExtensionsTests
    {
        public class Person { public string Name { get; set; } }

        [TestMethod]
        public void Select_GetProperty_ShouldGenerateANewInstanceOfThatProperty()
        {

            Person person = new Person { Name = "Jonh Wick" };
            var name = person.Select(x => x.Name);
            name.Should().Be("Jonh Wick");
        }

        [TestMethod]
        public void Select_SetProperty_ShouldChangeTheValue()
        {
            var person = new Person { Name = "jonh" };
            person.Select(x => x.Name = "jonh wick");
            person.Name.Should().Be("jonh wick");
        }
    }


}
