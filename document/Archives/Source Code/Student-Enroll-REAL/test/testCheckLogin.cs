using Xunit;
using Student_Enroll_REAL.SQLInteraction;

public class testCheckLogin
{   
    public testCheckLogin()
    {
        CheckLogin.ConnectToSQL();
    }
    [Fact]
    public void Testcase1()
    {
        string result = CheckLogin.checkLogin("admin","admin");
        Assert.Equal("admin",result);
    }

    [Fact]
    public void Testcase2()
    {
        string result = CheckLogin.checkLogin("ngotvjpr0","benhuhatvung");
        Assert.Equal("user",result);
    }
    [Fact]
    public void Testcase3()
    {
        string result = CheckLogin.checkLogin("admin","wrongpassword");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase4()
    {
        string result = CheckLogin.checkLogin("ngotvjpr0","wrongpassword");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase5()
    {
        string result = CheckLogin.checkLogin("unavailableaccount","admin");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase6()
    {
        string result = CheckLogin.checkLogin("admin","");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase7()
    {
        string result = CheckLogin.checkLogin("ngotvjpr0","");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase8()
    {
        string result = CheckLogin.checkLogin("unavailableaccount","");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase9()
    {
        string result = CheckLogin.checkLogin("","admin");
        Assert.Equal("failed",result);
    }
    [Fact]
    public void Testcase10()
    {
        string result = CheckLogin.checkLogin("n","");
        Assert.Equal("failed",result);
    }
}