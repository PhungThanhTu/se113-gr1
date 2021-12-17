using Xunit;
using Student_Enroll_REAL.SQLInteraction;

public class testSqlString {
    public testSqlString(){}

    [Fact]
    void testcase1()
    {
        string result = ExecuteQuery.GetStringFromQuery("select * from test2");
        Assert.Equal("nam",result);
    }
}