using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {

        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(students.Models.Count +1 ,firstName ,lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully,firstName,lastName,nameof(StudentRepository));
            
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            throw new NotImplementedException();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            throw new NotImplementedException();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            var firstName = studentName.Split(" ")[0];
            var lastName = studentName.Split(" ")[1];

            var student = students.FindByName(firstName);
            var university = universities.FindByName(universityName);

            if (student == null) 
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            if (university == null) 
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x))) 
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);

            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            if (subjects.FindById(subjectId) == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            if (students.FindById(subjectId).CoveredExams.Any(x => x == subjectId)) 
            {
                return string.Format (OutputMessages.StudentAlreadyCoveredThatExam,
                    students.FindById(studentId).FirstName,
                    students.FindById(studentId).LastName,
                    subjects.FindById(subjectId).Name);
            }

            var student = students.FindById(studentId);
            var subject = subjects.FindById(subjectId);

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
