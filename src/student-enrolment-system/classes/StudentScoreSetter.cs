
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace student_enrolment_system
{   
   
    public class StudentScoreSetter
    {   
       

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
            ExecuteQuery.executeQuery("UPDATE table "+ StudentScoreConst.TABLE_NAME+" set "+ StudentScoreConst.TABLE_FIELD_SCORE_NAME +" = "+student_score.Score+" where "+StudentScoreConst.TABLE_FIELD_STUDENT_ID_NAME+ " = " + student_score + " and "+ StudentScoreConst.TABLE_FIELD_SUBJECT_ID_NAME+" = " + student_score.SubjectId);
        }

    }


}