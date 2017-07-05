using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter
{
    [TestFixture]
    public class CheckUtilityTest
    {
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void MustBeNotEmpty_Generic_Case1(IEnumerable<int> arg0)
        {
            // Arrange
            // Act
            // Assert
            CheckUtility.MustNotBeEmpty(arg0, "foo");
        }
        [TestCase(null)]
        [TestCase(new int[0])]
        public void MustBeNotEmpty_Generic_Case2(IEnumerable<int> arg0)
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() =>
            {
                CheckUtility.MustNotBeEmpty(arg0, "foo");
            }, arg0 == null ? Throws.TypeOf<ArgumentNullException>()
            : Throws.TypeOf<ArgumentException>());
        }
        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("abc")]
        public void MustBeNotEmpty_NotGeneric_Case1(string arg0)
        {
            // Arrange
            // Act
            // Assert
            CheckUtility.MustNotBeEmpty(arg0, "foo");
        }
        [TestCase(null)]
        [TestCase("")]
        public void MustBeNotEmpty_NotGeneric_Case2(string arg0)
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() =>
            {
                CheckUtility.MustNotBeEmpty(arg0, "foo");
            }, arg0 == null ? Throws.TypeOf<ArgumentNullException>()
            : Throws.TypeOf<ArgumentException>());
        }
        [TestCase(1, 0)]
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        public void MustBeGreaterThan_Case1(int arg0, int arg1)
        {
            // Arrange
            // Act
            // Assert
            CheckUtility.MustBeGreaterThan(arg0, arg1, "foo");
        }
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        public void MustBeGreaterThan_Case2(int arg0, int arg1)
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() =>
            {
                CheckUtility.MustBeGreaterThan(arg0, arg1, "foo");
            }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [TestCase(1, 0)]
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void MustBeGreaterThanOrEqual_Case1(int arg0, int arg1)
        {
            // Arrange
            // Act
            // Assert
            CheckUtility.MustBeGreaterThanOrEqual(arg0, arg1, "foo");
        }
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        public void MustBeGreaterThanOrEqual_Case2(int arg0, int arg1)
        {
            // Arrange
            // Act
            // Assert
            Assert.That(() =>
            {
                CheckUtility.MustBeGreaterThanOrEqual(arg0, arg1, "foo");
            }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
