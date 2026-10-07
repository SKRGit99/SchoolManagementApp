using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

 */
    public class SuperAdminRepo : StudentRepo, ISuperAdmin     
    {
        
        private readonly string _connString = "Server=SAMPAT-PC\\;Database=SchoolManagementAppDevDb;Integrated Security=True;";

        public SuperAdminRepo()
        { 
        
        }

        /*------------------------------------------ Organization Data ------------------------------------------*/
        public override OrganizationDetails getOrganizationDetails()
        {
            OrganizationDetails lstOrg = new OrganizationDetails();

            return lstOrg;

        }

        public override void getOrganizationRelationshipDetails(int empId)
        {
            OrganizationDetails orgEmpDet = new OrganizationDetails();
            Console.WriteLine($"Relationship Id : {orgEmpDet.EmployeeRelationShipId} Relationship Category Id: {orgEmpDet.SchoolRelationShipCategoryId} Relationship Category Name : {orgEmpDet.SchoolRelationShipCategoryName} Relationship-Department Name :{orgEmpDet.SchoolDepartmentId} ");
        }

        public override void getOrganizationRelationshipDetails(int studentId, int? stuRollNum)
        {
            OrganizationDetails orgStuDet = new OrganizationDetails();
            Console.WriteLine($"Relationship Id : {orgStuDet.StudentRelationShipId} Relationship Category Id: {orgStuDet.SchoolRelationShipCategoryId} Relationship Category Name : {orgStuDet.SchoolRelationShipCategoryName} Relationship-Department Name :{orgStuDet.SchoolDepartmentId} ");
        }


        
        public override void getDepartmentDetails(int empId)
        {
            DepartmentDetails deptEmpDet = new DepartmentDetails();
            Console.WriteLine($"Department Id : {deptEmpDet.DepartmentId} Department Name :{deptEmpDet.DepartmentName}");
        }
        public override void getDepartmentDetails(int studentId, int? stuRollNum)
        {
            DepartmentDetails deptStuDet = new DepartmentDetails();
            Console.WriteLine($"Department Id : {deptStuDet.DepartmentId} Department Name :{deptStuDet.DepartmentName}");
        }


        public decimal getDepartmentWiseExpenditureDetails(int deptId)
        {
            decimal deptWiseExpenses = 0;




            return deptWiseExpenses;
        }


        
        public List<EmployeeDetails> getEmployeeDetails()
        {
            List<EmployeeDetails> empDet = new List<EmployeeDetails>();

            return empDet;
        }


        public List<EducatorDetails> fetchEducatorDetails(int educatorid)
        {
            List<EducatorDetails> lstEduDetails = new List<EducatorDetails>();

            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchEducatorDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@educatorid", SqlDbType.Int) { Value = educatorid });

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    EducatorDetails eduDet = new EducatorDetails();
                    eduDet.EducatorId = Convert.ToInt32(dr["EducatorId"]);
                    eduDet.EducatorFirstName = dr["EducatorFirstName"].ToString();
                    eduDet.EducatorMiddleName = dr["EducatorMiddleName"].ToString();
                    eduDet.EducatorLastName = dr["EducatorLastName"].ToString();
                    eduDet.EducatorName = dr["EducatorFullName"].ToString();

                    eduDet.EducatorDepartmentName = dr["DepartmentName"].ToString();
                    eduDet.EducatorClassesAssigned = dr["ClassesAssigned"].ToString();
                    eduDet.EducatorPhoneNumber = dr["EducatorPhoneNumber"].ToString();
                    eduDet.EducatorAddressLine1 = dr["EducatorAddressLine1"].ToString();
                    eduDet.EducatorAddressLine2 = dr["EducatorAddressLine2"].ToString();
                    eduDet.EducatorAddress = dr["EducatorFullAddress"].ToString();
                    eduDet.EducatorCity = dr["City"].ToString();
                    eduDet.EducatorState = dr["HomeState"].ToString();
                    eduDet.EducatorCountry = dr["Country"].ToString();
                    eduDet.ZipCode = dr["ZipCode"].ToString();
                    eduDet.EmailId = dr["EmailId"].ToString();



                    lstEduDetails.Add(eduDet);


                }

                return lstEduDetails;


            }
        }

        public List<EducatorDetailsForDropDown> getEducatorDetailsForDropDown(int educatorId)
        {
            List<EducatorDetailsForDropDown> lstEduDrpDwn = new List<EducatorDetailsForDropDown>();

            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchEducatorDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@educatorId", SqlDbType.Int) { Value = educatorId });

                var da = new SqlDataAdapter(cmd);

                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();

                dt = ds.Tables[1];

                foreach (DataRow dr in dt.Rows)
                {
                    EducatorDetailsForDropDown educatorDetailsByDropDown = new EducatorDetailsForDropDown();
                    educatorDetailsByDropDown.EducatorIdForDrpDwn = Convert.ToInt32(dr["EducatorId"]);
                    educatorDetailsByDropDown.EducatorFullNameForDrpDwn = dr["EducatorFullName"].ToString();


                    lstEduDrpDwn.Add(educatorDetailsByDropDown);
                }
                return lstEduDrpDwn;
            }
        }

        public List<EducatorDetails> getEducatorDetailsByRegistrationId(int educatorId)
        {
            List<EducatorDetails> lstEduDetailsbyRegId = new List<EducatorDetails>();

            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchEducatorDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@educatorId", SqlDbType.Int) { Value = educatorId });

                var da = new SqlDataAdapter(cmd);

                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    EducatorDetails eduDet = new EducatorDetails();
                    eduDet.EducatorId = Convert.ToInt32(dr["EducatorId"]);
                    eduDet.EducatorFirstName = dr["EducatorFirstName"].ToString();
                    eduDet.EducatorMiddleName = dr["EducatorMiddleName"].ToString();
                    eduDet.EducatorLastName = dr["EducatorLastName"].ToString();
                    eduDet.EducatorName = dr["EducatorFullName"].ToString();

                    eduDet.EducatorDepartmentName = dr["DepartmentName"].ToString();
                    eduDet.EducatorClassesAssigned = dr["ClassesAssigned"].ToString();
                    eduDet.EducatorPhoneNumber = dr["EducatorPhoneNumber"].ToString();
                    eduDet.EducatorAddressLine1 = dr["EducatorAddressLine1"].ToString();
                    eduDet.EducatorAddressLine2 = dr["EducatorAddressLine2"].ToString();
                    eduDet.EducatorAddress = dr["EducatorFullAddress"].ToString();
                    eduDet.EducatorCity = dr["City"].ToString();
                    eduDet.EducatorState = dr["HomeState"].ToString();
                    eduDet.EducatorCountry = dr["Country"].ToString();
                    eduDet.ZipCode = dr["ZipCode"].ToString();
                    eduDet.EmailId = dr["EmailId"].ToString();

                    lstEduDetailsbyRegId.Add(eduDet);


                }

                return lstEduDetailsbyRegId;
            }
        }


        public List<EmployeeDetails> getEmployeeSalaryDetails()
        {
            List<EmployeeDetails> empSalDet = new List<EmployeeDetails>();




            return empSalDet;
        }

        public decimal getIndividualEmployeeSalaryDetails(int empId)
        {
            decimal empSalary = 0;




            return empSalary;
        }


        /*---------------------------------------------- Employee Data ---------------------------------------------*/






        /*---------------------------------------------- Student Data ----------------------------------------------*/
        public List<StudentDetails> fetchStudentDetails(int studentId)
        {
            List<StudentDetails> stuDet = new List<StudentDetails>();

            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchStudentDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int) { Value = studentId });

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    StudentDetails studentDet = new StudentDetails();

                    studentDet.SchoolRelationShipCategoryId = Convert.ToInt32(dr["RelationshipCategoryId"]);
                    studentDet.SchoolRelationShipCategoryName = dr["RelationshipCategoryName"].ToString();
                    studentDet.StudentRelationShipId = Convert.ToInt32(dr["RelationshipId"]);
                    studentDet.SchoolName = dr["SchoolName"].ToString();

                    studentDet.StudentFirstName = dr["StudentFirstName"].ToString();
                    studentDet.StudentMiddleName = dr["StudentMiddleName"].ToString();
                    studentDet.StudentLastName = dr["StudentLastName"].ToString();
                    studentDet.StudentName = dr["StudentName"].ToString();
                    studentDet.IsRegisteredStudent = Convert.ToChar(dr["IsRegisteredStudent"]);


                    studentDet.RollNumber = Convert.ToInt32(dr["RollNumber"]);
                    studentDet.StudentClass = Convert.ToInt32(dr["ClassId"]);
                    studentDet.StudentSectionId = Convert.ToInt32(dr["SectionId"]);
                    studentDet.StudentSectionName = Convert.ToChar(dr["SectionName"]);

                    studentDet.StudentCity = dr["City"].ToString();
                    studentDet.StudentState = dr["HomeState"].ToString();
                    studentDet.StudentCountry = dr["Country"].ToString();

                    stuDet.Add(studentDet);
                }
            }

              return stuDet;

            
        }


        public List<StudentDetailsForDropDown> getStudentDetailsForDropDown(int studentId)
        {
            List<StudentDetailsForDropDown> lstStdDrpDwn = new List<StudentDetailsForDropDown>();
            using (var con = new SqlConnection(_connString))
            using (var cmd = new SqlCommand("fetchStudentDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int) { Value = studentId });

                var da = new SqlDataAdapter(cmd);

                var ds = new DataSet();

                da.Fill(ds);

                DataTable dt = new DataTable();
                dt = ds.Tables[1];

                foreach (DataRow dr in dt.Rows)
                {
                    StudentDetailsForDropDown studentDetailsByDropDown = new StudentDetailsForDropDown();
                    studentDetailsByDropDown.StudentIdForDrpDwn = Convert.ToInt32(dr["RelationshipId"]);
                    studentDetailsByDropDown.StudentFullNameForDrpDwn = dr["StudentName"].ToString();


                    lstStdDrpDwn.Add(studentDetailsByDropDown);
                }
                return lstStdDrpDwn;
            }
        }

        public override List<StudentDetails> getStudentDetailsByRegistrationId(int registrationId)
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

        /*------------------------------------------- Student Data -------------------------------------------*/

        
    }
}
