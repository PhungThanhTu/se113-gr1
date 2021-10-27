using Xunit;

public class test {
    // test CheckDateInMonth
    [Fact]
    public void Testcase1()
    {
        Assert.Equal(28,xUnitTesting.Program.checkDateInMonth(2100,2));
    }
    [Fact]
    public void Testcase2()
    {
        Assert.Equal(29,xUnitTesting.Program.checkDateInMonth(2004,2));
    }
    [Fact]
    public void Testcase3()
    {
        Assert.Equal(28,xUnitTesting.Program.checkDateInMonth(2009,2));
    }
    [Fact]
    public void Testcase4()
    {
        Assert.Equal(29,xUnitTesting.Program.checkDateInMonth(1600,2));
    }
    [Fact]
    public void Testcase5()
    {
        Assert.Equal(30,xUnitTesting.Program.checkDateInMonth(2004,4));
    }
    [Fact]
    public void Testcase6()
    {
        Assert.Equal(31,xUnitTesting.Program.checkDateInMonth(2009,3));
    }
    [Fact]
    public void Testcase7()
    {
        Assert.Equal(0,xUnitTesting.Program.checkDateInMonth(2009,0));
    }

    // test valid date
    [Theory]
    [InlineData(2000,2,29)]
    [InlineData(2000,1,30)]
    [InlineData(2004,2,29)]
    [InlineData(2009,2,28)]
    [InlineData(2000,1,31)]
    [InlineData(2000,4,30)]
    public void TestValidDate(int Year,int Month,int Day)
    {
        Assert.True(xUnitTesting.Program.checkDate(Year,Month,Day));
    }

    [Theory]
    [InlineData(2100,2,29)]
    [InlineData(2009,2,29)]
    [InlineData(2009,2,30)]
    [InlineData(2000,4,31)]
    [InlineData(2000,0,30)]
    [InlineData(2000,13,29)]
    [InlineData(2000,1,32)]
    [InlineData(2000,4,32)]
    
    public void TestInvalidDate(int Year,int Month,int Day)
    {
        Assert.False(xUnitTesting.Program.checkDate(Year,Month,Day));
    }

}