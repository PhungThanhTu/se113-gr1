using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace student_enrolment_system {

     static class StudentConst {
        public const string STUDENT_TABLE_NAME = "student";
        public const string COLUMN_ID = "id";
        public const string COLUMN_NAME = "name";
        public const string COLUMN_SEX = "sex";
        public const string COLUMN_DOB = "dob";
        public const string COLUMN_TOTAL_SCORE = "total_score";
        public const string COLUMN_BENCHMARK_ID = "benchmark_id";
    }

    public static class StudentScoreConst
    {
         // query-related data
        public const string TABLE_NAME = "student_score";
        public const string TABLE_FIELD_SCORE_NAME = "score";
        public const string TABLE_FIELD_STUDENT_ID_NAME="student_id";
        public const string TABLE_FIELD_SUBJECT_ID_NAME ="subject_id";
    }
    public class Student 
    {

       


    }
}