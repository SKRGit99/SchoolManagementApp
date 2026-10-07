using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;
using SchoolManagementApplicationDAL.Repository;

namespace SchoolManagementApplicationBAL
{
    /*
      SuperAdminRepo : StudentRepo

      StudentRepo : DepartmentRepo

      StudentDetails : DepartmentDetails

      EducatorDetails : EmployeeDetails

      EmployeeDetails : DepartmentDetails

      DepartmentRepo : DepartmentDetails

      DepartmentDetails : OrganizationRepo

      OrganizationRepo : OrganizationDetails

  */
    public class StudentDetailsBAL
    {
        //IStudent stdet = new StudentRepo();

        // Dependency Injection for the Student Repository
        private readonly IStudent stdet;

        public StudentDetailsBAL(IStudent studentRepo)
        {
            stdet = studentRepo;
        }

        public List<StudentDetails> GetStudentDetailsByRegistrationId(int selectedStudentRegId)
        {
            List<StudentDetails> detStudentbyRegId = new List<StudentDetails>();
            detStudentbyRegId = stdet.getStudentDetailsByRegistrationId(selectedStudentRegId);
            return detStudentbyRegId;
        }

        //public List<StudentDetailsADO> fetchStdDetails()
        //{
        //    List<StudentDetailsADO> lstt = new List<StudentDetailsADO> ();
        //    foreach (StudentDetailsADO student in stdet.getAllStudentDetails())
        //    {
        //        lstt.Add(student);
        //    }

        //    return lstt;
        //}

        //public List<StudentDetails> fetchIndvStdDetails(int inputStdId)
        //{
        //    List<StudentDetails> lsttt = new List<StudentDetails>();
        //    foreach (StudentDetails student in stdet.getStudentDetailsForDropDown(inputStdId))
        //    {
        //        lsttt.Add(student);
        //    }

        //    return lsttt;
        //}

        



    }
}
