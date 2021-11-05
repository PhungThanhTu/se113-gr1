


namespace student_enrolment_system
{   
    
    public class StudentScore
    {
        public int StudentId;
        public int SubjectId;

        public float Score;

        public StudentScore(int id,int sid,float score)
        {
            this.StudentId =  id;
            this.SubjectId = sid;
            this.Score = score;
        }

        public override bool Equals(object obj)
        {
            StudentScore o = (StudentScore) obj;
            return this.StudentId == o.StudentId && this.Score == o.Score && this.SubjectId == o.SubjectId;
        }
    }

    public class StudentScoreSetter
    {   
        // query-related data
        const string TABLE_NAME = "student_score";
        const string TABLE_FIELD_SCORE_NAME = "score";
        const string TABLE_FIELD_STUDENT_ID_NAME="student_id";
        const string TABLE_FIELD_SUBJECT_ID_NAME ="subject_id";

        // check if datatype valid
        public static bool checkDatatype(string score)
        {
            if(float.TryParse(score,out float n))
                return true;
            return false;
        }

        // check if score valid
        public static bool isScoreValid(float score)
        {
            if(score < 0)
                return false;
            if(score >10)
                return false;
            return true;
        }
        
        // get inputdata from UI
        public static StudentScore inputData(int StudentId,int SubjectId,float Score)
        {
            return new StudentScore(StudentId,SubjectId,Score);
        }

        // send update query to database
        public static void SendUpdateQuery(StudentScore student_score)
        {
            ExecuteQuery.executeQuery("UPDATE table "+TABLE_NAME+" set "+ TABLE_FIELD_SCORE_NAME +" = "+student_score.Score+" where "+TABLE_FIELD_STUDENT_ID_NAME+ " = " + student_score + " and "+ TABLE_FIELD_SUBJECT_ID_NAME+" = " + student_score.SubjectId);
        }

    }


}