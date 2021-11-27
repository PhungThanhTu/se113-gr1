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

       

        int Id = -1; // id = -1 mean invalid student
        string Name = "";
        string Sex = "";
        
        string DateOfBirth = "";

        int Benchmark_Id = 0;

        float TotalScore = 0;

        // properties
        

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
            fetchData();

        }
        // get data from class inside
        public int getId() {return this.Id;}
        public string getName(){return this.Name;}
        public string getSex() {return this.Sex;}
        public string getDateOfBirth(){return this.DateOfBirth;}
        public int getBenchmarkId() {return this.Benchmark_Id;}
        public float getTotalScore(){ return this.TotalScore;}

        // get data from SQL database to object
        public bool fetchData() {
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

        public string toString()
        {
            return "[ID:"+this.getId().ToString()+",Name:"+this.getName()+",Sex:"+this.getSex()+",DOB:"+this.getDateOfBirth()+",BenchmarkID:"+this.getBenchmarkId().ToString()+",Score:"+this.getTotalScore().ToString()+"]";
        }
        public void logConsole()
        {
            Console.WriteLine(this.toString());
        }
    }

    


    class Students {
        
        public List<Student> AllStudents;


        

        public Students()
        {   
            try {
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
            catch 
            {
                Console.WriteLine("Cannot get data from server");
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

        public int Length { get => AllStudents.Count;}
        
        public Student at(int index){ return AllStudents[index];}

        public void fetchData()
        {
            foreach(Student singleStudent in AllStudents)
            {
                singleStudent.fetchData();
            }
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

        // update from databases
        public void Update()
        {   
            StudentScoreSetter.SendUpdateQuery(this);
        }

        // remember, validate the score before use this function
        public void setScore(float score)
        {
            this.Score = score;
        }

        // fetch data of a record from SQL datatable
        public void FetchData()
        {
            string score = ExecuteQuery.GetStringFromQuery("select * from " + StudentScoreConst.TABLE_NAME + " where " + StudentScoreConst.TABLE_FIELD_STUDENT_ID_NAME + " = " + this.StudentId.ToString() + " AND " + StudentScoreConst.TABLE_FIELD_SUBJECT_ID_NAME + " = " + this.SubjectId.ToString());
            this.Score = float.Parse(score);


        }
    }

    public class StudentScores {
        List<StudentScore> allScores;

        

    }
}