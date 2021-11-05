using Xunit;
using Xunit.Abstractions;
using student_enrolment_system;


public class InputAccountTest {

   

    [Fact]
    public void test1()
    {
        //input
        string username = "daxuadeptrai123";
        string password = "1e23bc";
        //expected output
        Account expected = new Account("daxuadeptrai123","1e23bc");
        
        Assert.Equal(expected, Login.inputAccount(username,password));

    }
    [Fact]
    public void test2()
    {
        //input
        string username = "daxuadeptrai123";
        string password = "";
        //expected output
        Account expected = null;
        
        Assert.Equal(expected, Login.inputAccount(username,password));

    }
    
    [Fact]
    public void test3()
    {
        //input
        string username = "";
        string password = "1e23bc";
        //expected output
        Account expected = null;
        
        Assert.Equal(expected, Login.inputAccount(username,password));

    }

    [Fact]
    public void test4()
    {
        //input
        string username = "";
        string password = "";
        //expected output
        Account expected = null;
        
        Assert.Equal(expected, Login.inputAccount(username,password));

    }

}

public class LoginResultTest
{   
    // init
    Account inputVerifiedAccount = new Account("samplename","samplepassword");

    [Fact]
    public void test1(){
        // input
        inputVerifiedAccount.AccountType = "teacher";
        // expected
        string expected = "teacher";

        // assert
        Assert.Equal(expected,Login.LoginResult(inputVerifiedAccount));
    }

    [Fact]
    public void test2(){
        // input
        inputVerifiedAccount.AccountType = "admin";
        // expected
        string expected = "admin";

        // assert
        Assert.Equal(expected,Login.LoginResult(inputVerifiedAccount));
    }

    [Fact]
    public void test3(){
        // input
        inputVerifiedAccount.AccountType = "error";
        // expected
        string expected = "error";

        // assert
        Assert.Equal(expected,Login.LoginResult(inputVerifiedAccount));
    }
}

