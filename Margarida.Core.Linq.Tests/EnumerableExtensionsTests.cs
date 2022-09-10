using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Margarida.Core.Linq.Tests
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void Most_SmallestAndBiggest_ShouldReturnTheSmallestNdBiggest()
        {
            var list = new[] { 1, 3, 2, 4, 0, -1 };
            int top;
            top = list.Most((x, y) => x < y);
            top.Should().Be(-1);
            
            top = list.Most((x, y) => x > y);
            top.Should().Be(4);
        }

        [TestMethod]
        public void ChunkyByTwo_ShouldReturnTwoListsContainingDiffItens()
        {
            new[] { 1, 3, 2, 4, 0, -1 }
                .ChunkBy(2)
                .Should()
                .HaveCount(3)
                .And
                .Match(lists => lists
                .ToCompare((x,y) => x
                .Intersect(y).Any()).Any);
        }

        [TestMethod]
        public void ForEach_ShouldIncrement()
        {
            int i = 0;
            new[] { 1, 2, 3, 4, 5 }.ForEach(x => i++);
            i.Should()
             .Be(5);
        }

        [TestMethod]
        public void InsertAt_ShouldInsertValueAtIndex()
        {
            new[] { 1, 2, 3, 4 }
                .InsertAt(5, 4)
                .Select(x => x[4]
                .Should()
                .Be(5));
        }
    }
}
