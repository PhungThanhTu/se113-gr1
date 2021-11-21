
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace student_enrolment_system
{   
    static class StudentConst {
        public const string STUDENT_TABLE_NAME = "";
        public const string COLUMN_ID = "";
        public const string COLUMN_NAME = "";
        public const string COLUMN_SEX = "";
        public const string COLUMN_DOB = "";
        public const string COLUMN_TOTAL_SCORE = "";
        public const string COLUMN_BENCHMARK_ID = "";
    }
    public class Student 
    {

       

        int Id = -1; // id = -1 mean invalid student
        string Name = "";
        string Sex = "";
        
        string DateOfBirth = "";

        int Benchmark_Id = 0;

        float TotalScore = 0;

        public Student(int Id, string Name, string Sex, string DateOfBirth , int Benchmark_Id, float TotalScore)
        {
            this.Id = Id;
            this.Name = Name;
            this.Sex = Sex;
            this.DateOfBirth = DateOfBirth;
            this.Benchmark_Id = Benchmark_Id;
            this.TotalScore = TotalScore;
        }
        public Student(int id)
        {   
            this.Id = id;
            updateData();

        }
        // get data from class inside
        public int getId() {return this.Id;}
        public string getName(){return this.Name;}
        public string getSex() {return this.Sex;}
        public string getDateOfBirth(){return this.DateOfBirth;}
        public int getBenchmarkId() {return this.Benchmark_Id;}
        public float getTotalScore(){ return this.TotalScore;}

        // get data from SQL database to object
        public bool updateData() {
             DataTable dt = ExecuteQuery.getSqlDataTableFromQuery("SELECT * from "+ StudentConst.STUDENT_TABLE_NAME + " + where "+ StudentConst.COLUMN_ID + " = "+ this.Id.ToString());

            if(dt == null)
            {
                return false;
            }
            else
            {   
                DataRow row = dt.Rows[0];
                this.Name = row[StudentConst.COLUMN_NAME].ToString();
                this.Sex = row[StudentConst.COLUMN_SEX].ToString();
                this.DateOfBirth = row[StudentConst.COLUMN_DOB].ToString();
                this.Benchmark_Id = int.Parse(row[StudentConst.COLUMN_BENCHMARK_ID].ToString());
                this.TotalScore = float.Parse(row[StudentConst.COLUMN_TOTAL_SCORE].ToString());
                return true;
            }
        }

        // save data to SQL database, only total score is editable by logic code
        public bool saveData()
        {   
            try 
            {
                ExecuteQuery.executeQuery("update table " + StudentConst.STUDENT_TABLE_NAME + " set" + 
                " " + StudentConst.COLUMN_TOTAL_SCORE + " = " + this.TotalScore.ToString() +
                " where " + StudentConst.COLUMN_ID + " = " + this.Id);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void setTotalScore(float total_score)
        {
            this.TotalScore = total_score;
        }


    }

    


    class Students {
        
        public List<Student> AllStudents;


        

        public Students()
        {
            DataTable QueriedStudentTable = ExecuteQuery.getSqlDataTableFromQuery("SELECT * from " + StudentConst.STUDENT_TABLE_NAME);

            for(int i = 0; i < QueriedStudentTable.Rows.Count; i++)
            {
                DataRow SingleStudentRow = QueriedStudentTable.Rows[i];
                int id = int.Parse(SingleStudentRow[StudentConst.COLUMN_ID].ToString());
                string Name = SingleStudentRow[StudentConst.COLUMN_NAME].ToString();
                string Sex = SingleStudentRow[StudentConst.COLUMN_SEX].ToString();
                string DateOfBirth = SingleStudentRow[StudentConst.COLUMN_DOB].ToString();
                int Benchmark_Id = int.Parse(SingleStudentRow[StudentConst.COLUMN_BENCHMARK_ID].ToString());
                float TotalScore = float.Parse(SingleStudentRow[StudentConst.COLUMN_TOTAL_SCORE].ToString());

                Student newStudent = new Student(id,Name,Sex,DateOfBirth,Benchmark_Id,TotalScore);
                this.AllStudents.Add(newStudent);

            }
        }
        public Student getSingleStudent(int id)
        {
            foreach( Student student in AllStudents)
            {
                if(student.getId() == id)
                {
                    return student;
                }
            }
             return new Student(-1);
        }
    }
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

    public class StudentScores {
        List<StudentScore> allScores;

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