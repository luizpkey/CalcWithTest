using BasicCalc;
using System;
namespace BasicCalcTest
{
    public class CalcTest
    {
        public Calc CalcBuild()
        {
            Calc calc = new Calc(DateTime.Now.ToString());
            return calc;
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(5, 3, 8)]
        public void Sum(int x, int y, int expect)
        {
            Calc calc = CalcBuild();
            int res = calc.Sum(x, y);
            Assert.Equal(expect, res);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(27, 14, 13)]
        public void Subtract(int x, int y, int expect)
        {
            Calc calc = CalcBuild();
            int res = calc.Subtract(x, y);
            Assert.Equal(expect, res);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        public void Multiply(int x, int y, int expect)
        {
            Calc calc = CalcBuild();
            int res = calc.Multiply(x, y);
            Assert.Equal(expect, res);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        public void Divide(int x, int y, int expect)
        {
            Calc calc = CalcBuild();
            int res = calc.Divide(x, y);
            Assert.Equal(expect, res);
        }

        [Fact]
        public void DivideByZero()
        {
            int x = 1;
            int y = 0;
            Calc calc = CalcBuild();
            Assert.Throws<DivideByZeroException>(()=>calc.Divide(x,y));
        }

        [Fact]
        public void History()
        {
            Calc calc = CalcBuild();
            calc.Sum(1, 2);
            calc.Subtract(3, 1);
            calc.Multiply(3, 0);
            calc.Divide(0, 3);
            List<string> history = calc.GetHistory();
            Assert.NotEmpty(history);
            Assert.Equal(3, history.Count);

        }
    }
}