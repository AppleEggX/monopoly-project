using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Monopoly;


namespace MonopolyTests
{
    [TestFixture]
    public class DieTest
    {
        RollingDie rollingDie;

        [SetUp]
        public void SetUp()
        {
            rollingDie = new RollingDie();
        }

        [Test]
        public void CheckSidesCount_a([Range(6, 10, 1)] int dieSize)
        {
            //arrange


            //act
            rollingDie.SetDieSideCount(dieSize);

            //assert
            Assert.That(rollingDie.sidesCount, Is.EqualTo(dieSize));
        }

        [Test]
        public void CheckOutcomeIsRandomNumber([Range(1, 100, 1)] int tryTimes)
        {

            //arrange
            rollingDie.sidesCount = 6; //rollingDie is the class 
            int numberGet;

            //Act
            numberGet = rollingDie.Roll(); //put the value of the method into the numberGet variable

            //Assert

            Assert.That(numberGet, Is.TypeOf<int>());
        }
    }
}

