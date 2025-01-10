using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public enum ExamType
    {
        ExamPractical,
        ExamFinal 
    }
    internal static class ExamFactory
    {

        public static Exam CreateExam(ExamType examType, Subject subject, int examId, double timeExam)
        {
            // Determine which exam to create based on the provided exam type
            switch (examType)
            {
                case ExamType.ExamPractical:
                    return new ExamPractical(examId, timeExam, subject);

                case ExamType.ExamFinal:
                    return new ExamFinal(examId, timeExam, subject);

                default:
                    throw new ArgumentException("Invalid exam type");
            }
        }
       
        
    }
}
