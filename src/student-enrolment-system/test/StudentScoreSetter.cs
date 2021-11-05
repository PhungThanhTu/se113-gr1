using Xunit;
using Xunit.Abstractions;
using student_enrolment_system;

public class CheckDatatypeTest{
    [Theory]
    [InlineData("-1")]
    [InlineData("1")]
    [InlineData("0")]
    [InlineData("2.45")]
    public void testValidDataType(string data)
    {  
        Assert.True(StudentScoreSetter.checkDatatype(data));
    }


    [Theory]
    [InlineData("string")]
    public void testInvalidDataType(string data)
    {  
        Assert.False(StudentScoreSetter.checkDatatype(data));
    }

}

public class CheckScoreValidTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    public void testValidScore(float score)
    {
        Assert.True(StudentScoreSetter.isScoreValid(score));
    }
    [Theory]
    [InlineData(-1)]
    [InlineData(-0.01)]
    [InlineData(10.01)]
    [InlineData(12)]
    public void testinvalidScore(float score)
    {
        Assert.False(StudentScoreSetter.isScoreValid(score));
    }

}

public class TestInputData
{
    [Fact]
    public void test1()
    {
        // input
        float score = 3;
        int studentID = 101;
        int subjectID = 4;

        // expected output
        StudentScore expected = new StudentScore(101,4,3);

        // assert
        Assert.Equal(expected,StudentScoreSetter.inputData(studentID,subjectID,score));


    }
    [Fact]
    public void test2()
    {
        // input
        float score = 3;
        int studentID = 101;
        int subjectID = 4;

        // expected output
        StudentScore expected = new StudentScore(101,4,4.2f);

        // assert
        Assert.Equal(expected,StudentScoreSetter.inputData(studentID,subjectID,score));


    }

   
}