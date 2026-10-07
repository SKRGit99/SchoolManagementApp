using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApplicationDAL.Repository
{
    /*
       
       SuperAdminRepo : StudentRepo

       StudentRepo : DepartmentRepo
       
       DepartmentRepo : OrganizationRepo

       
       EducatorRepo : EmployeeRepo

       EmployeeRepo : DepartmentRepo



       StudentDetails : DepartmentDetails

       EducatorDetails : EmployeeDetails

       EmployeeDetails : DepartmentDetails

       DepartmentDetails : OrganizationDetails

       public class StudentRepo : IStudent, DepartmentRepo -- This will throw error.Base Class should come before any Interface.
  */

    public class StudentRepo : DepartmentRepo, IStudent
    {
        //SqlConnection conObj = new SqlConnection("Server=LAPTOP-K1PVP9J6\\;Database=SchoolManagementAppDevDb;Integrated Security=True;");

        private readonly string _connString = "Server=SAMPAT-PC\\;Database=SchoolManagementAppDevDb;Integrated Security=True;";

        public StudentRepo()
        {

        }

        public override OrganizationDetails getOrganizationDetails()
        {
            OrganizationDetails lstOrg = new OrganizationDetails();

            return lstOrg;

        }

        public override void getOrganizationRelationshipDetails(int studentId, int? stuRollNum)
        {
            OrganizationDetails orgStuDet = new OrganizationDetails();
            Console.WriteLine($"Relationship Id : {orgStuDet.StudentRelationShipId} Relationship Category Id: {orgStuDet.SchoolRelationShipCategoryId} Relationship Category Name : {orgStuDet.SchoolRelationShipCategoryName} Relationship-Department Name :{orgStuDet.SchoolDepartmentId} ");
        }

       
        public override void getDepartmentDetails(int studentId, int? stuRollNum)
        {
            DepartmentDetails deptStDet = new DepartmentDetails();
            Console.WriteLine($"Department Id : {deptStDet.DepartmentId} Department Name :{deptStDet.DepartmentName}");
        }



        public virtual List<StudentDetails> getStudentDetailsByRegistrationId(int registrationId)
        {
            List<StudentDetails> lstStdDetailsbyRegId = new List<StudentDetails>();

            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchStudentDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int) { Value = registrationId });

                var da = new SqlDataAdapter(cmd);

                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();
                dt = ds.Tables[0];


                foreach (DataRow dr in dt.Rows)
                {
                    StudentDetails studentDetByRegId = new StudentDetails();
                    studentDetByRegId.StudentId = Convert.ToInt32(dr["RelationshipId"]);
                    studentDetByRegId.StudentName = dr["StudentName"].ToString();
                    studentDetByRegId.RollNumber = Convert.ToInt32(dr["RollNumber"]);
                    studentDetByRegId.StudentClass = Convert.ToInt32(dr["ClassId"]);
                    studentDetByRegId.StudentSectionName = Convert.ToChar(dr["SectionName"]);
                    studentDetByRegId.StudentAddress = dr["StudentAddress"].ToString();
                    studentDetByRegId.StudentPhoneNumber = dr["StudentPhoneNumber"].ToString();
                    lstStdDetailsbyRegId.Add(studentDetByRegId);


                }

                return lstStdDetailsbyRegId;
            }

        }


    }
}
