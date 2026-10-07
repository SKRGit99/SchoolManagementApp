using Microsoft.Extensions.Configuration;
using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApplicationDAL.Repository
{
    /*
     SuperAdminRepo : StudentRepo

     StudentRepo : DepartmentRepo

     EmployeeRepo : DepartmentRepo




     StudentDetails : DepartmentDetails

     EducatorDetails : EmployeeDetails

     EmployeeDetails : DepartmentDetails

     DepartmentDetails : OrganizationDetails

 */
    public class EmployeeRepo : DepartmentRepo,IEmployee
    {
        //public EmployeeRepo() 
        //{ 
        //}

        //private readonly string? _connString;

        /* Since DepartmentRepo now requires IConfiguration, But EmployeeRepo was not passing the IConfiguration to the Parent Class.
         * Hence modified the constructor to accept IConfiguration and pass it to the base class constructor.
         */
        public EmployeeRepo(IConfiguration configuration):base(configuration)
        {
            //_connString = configuration.GetConnectionString("SchoolManagementAppDbConnectionString");
        }

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


    }
}
