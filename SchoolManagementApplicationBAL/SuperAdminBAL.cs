using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;
using SchoolManagementApplicationDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class SuperAdminBAL
    {
        //ISuperAdmin adminSup = new SuperAdminRepo();

        // Dependency Injection for the SuperAdmin Repository
        private readonly ISuperAdmin stdet;

        public SuperAdminBAL(ISuperAdmin superAdminRepo)
        {
            stdet = superAdminRepo;
        }
        public List<StudentDetails> fetchStudentDetails(int _inputStudentId)
        {
            List<StudentDetails> detStudent = new List<StudentDetails>();
            detStudent = stdet.fetchStudentDetails(_inputStudentId);
            return detStudent;
        }

        public List<StudentDetailsForDropDown> GetStudentDetailsForDropdown(int studentId)
        {
            List<StudentDetailsForDropDown> detStudentDrpDwn = new List<StudentDetailsForDropDown>();
            detStudentDrpDwn = stdet.getStudentDetailsForDropDown(studentId);
            return detStudentDrpDwn;
        }

        public List<StudentDetails> GetStudentDetailsByRegistrationId(int selectedStudentRegId)
        {
            List<StudentDetails> detStudentbyRegId = new List<StudentDetails>();
            detStudentbyRegId = stdet.getStudentDetailsByRegistrationId(selectedStudentRegId);
            return detStudentbyRegId;
        }

        public List<EducatorDetails> fetchEducatorDetails(int educatorid)
        {
            List<EducatorDetails> eduDetails = new List<EducatorDetails>();
            eduDetails = stdet.fetchEducatorDetails(educatorid);
            return eduDetails;
        }

        public List<EducatorDetailsForDropDown> fetchEducatorDetailsForDropDown(int educatorid)
        {
            List<EducatorDetailsForDropDown> lstEduDetDrpDwn = new List<EducatorDetailsForDropDown>();
            lstEduDetDrpDwn = stdet.getEducatorDetailsForDropDown(educatorid);
            return lstEduDetDrpDwn;
        }

        public List<EducatorDetails> fetchEducatorDetailsByRegistrationId(int educatorid)
        {
            List<EducatorDetails> eduDetRegId = new List<EducatorDetails>();
            eduDetRegId = stdet.getEducatorDetailsByRegistrationId(educatorid);
            return eduDetRegId;
        }



    }
}
