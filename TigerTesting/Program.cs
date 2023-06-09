// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Diagnostics.Metrics;
using TigerTesting;

Services services = new Services();
//to do 1: Write a query to retrieve all students and their enrolled courses.
var reader = services.ExecuteReader("Select s.Name,s.Age,isnull(c.CourseName,'Mashrooot') as courseName  from Students s left join Courses c on s.Id = c.StudentId");

//to do 2: Write a query to retrieve the count of courses each student has enrolled in.
Services services2 = new Services();
var reader2 = services2.ExecuteReader("SELECT Students.ID, Students.Name, COUNT(Courses.Id) AS CourseCount FROM Students LEFT JOIN Courses ON Students.Id = Courses.StudentID GROUP BY Students.ID, Students.Name");

//to do 3:Write a query to retrieve the students who have not enrolled in any course.
Services services3 = new Services();
var reader3 = services3.ExecuteReader("select s.Id,s.Name from students s left join Courses c on s.Id = c.StudentId where c.StudentId is null");


//to do 4: Write a query to retrieve the students who are enrolled in a specific course.
Services services4 = new Services();
var reader4 = services4.ExecuteReader("select s.Id,s.Name from students s inner join Courses c on s.Id = c.StudentId where c.CourseName = 'gaming'");

//to do5: Update the age of a student with a specific ID.
Services services5 = new Services();
var reader5 = services5.ExecuteNonQuery("update students set Age = 22 where Id = 1");

//to do 7: Delete a student and all their enrolled courses from the database based on their ID.
Services services6 = new Services();
//var reader6 = services6.ExecuteNonQuery("ALTER TABLE Courses ADD CONSTRAINT FK_Student_Courses " +
//    "FOREIGN KEY(StudentID) REFERENCES Students(ID) " +
//    "ON DELETE CASCADE");
var reader6_1 = services6.ExecuteNonQuery("delete from students where Id = 4 " +
                                        "delete from courses where StudentId = 4");

while (reader.Read())
{
    Console.WriteLine($"Name: {reader.GetString(0)}\t Age:{reader.GetInt32(1)}\t Course:{reader["CourseName"]}");
}
while (reader2.Read())
{
    Console.WriteLine($"StudentId: {reader2.GetInt32(0)}\tStudentName:{reader2.GetString(1)}\t CourseCount:{reader2.GetInt32(2)}");
}
Console.WriteLine("********************");
while (reader3.Read())
{
    Console.WriteLine($"StudentId: {reader3.GetInt32(0)}\tStudentName:{reader3.GetString(1)}");
}
Console.WriteLine("********************");
while (reader4.Read())
{
    Console.WriteLine($"StudentId: {reader4.GetInt32(0)}\tStudentName:{reader4.GetString(1)}");
}
Console.WriteLine("********************");
Console.WriteLine(reader5.ToString());
Console.WriteLine("********************");
//Console.WriteLine(reader6.ToString());
Console.WriteLine(reader6_1.ToString());






//Console.WriteLine("Id={0}\tName={1}\tAge={2}\tMajor={3}\t ",reader.GetInt32(0),reader.GetSqlString(1),reader.GetInt32(2),reader.GetSqlString(3),);