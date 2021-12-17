using Xunit;
using Student_Enroll_REAL.SQLInteraction;
using System;
using System.Data;

public class testSqlData {
    
    [Fact]
    public void TestCase1()
    {
        DataTable result = ExecuteQuery.SqlDataTableFromQuery("select * from test2");

        Assert.Equal(3,result.Rows.Count);

        DataRow row1 = result.Rows[0];

        Assert.Equal("nam",row1["name"]);
        Assert.Equal(20,row1["age"]);

        DataRow row2 = result.Rows[1];

        Assert.Equal("hai",row2["name"]);
        Assert.Equal(23,row2["age"]);

        DataRow row3 = result.Rows[2];

        Assert.Equal("binh",row3["name"]);
        Assert.Equal(21,row3["age"]);

    }

    
    public void TestCase2()
    {
        DataTable result = ExecuteQuery.SqlDataTableFromQuery("select * from test2 where name = 'nam'");

        Assert.Equal(1,result.Rows.Count);

        DataRow row1 = result.Rows[0];

        Assert.Equal("nam",row1["name"]);
        Assert.Equal(20,row1["age"]);

        

    }
   
    public void TestCase3()
    {
        DataTable result = ExecuteQuery.SqlDataTableFromQuery("select * from test2 where name = 'invalid");

        Assert.Equal(0,result.Rows.Count);


    }
}