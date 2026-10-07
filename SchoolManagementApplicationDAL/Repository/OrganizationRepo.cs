using Microsoft.Extensions.Configuration;
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

      DepartmentRepo : OrganizationRepo


      DepartmentDetails : OrganizationRepo

      OrganizationRepo : OrganizationDetails


      Model Classes:

      StudentDetails : DepartmentDetails

      EducatorDetails : EmployeeDetails

      EmployeeDetails : DepartmentDetails

   */
    public class OrganizationRepo
    {
        //private readonly string _connString = "Server=SAMPAT-PC\\;Database=SchoolManagementAppDevDb;Integrated Security=True;";
        //public OrganizationRepo() 
        //{ 

        //}


        /* Changed OrganizarionRepo to require IConfiguration.*/
        protected readonly string? _connString;

        public OrganizationRepo(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("SchoolManagementAppDbConnectionString");
        }
        public virtual OrganizationDetails getOrganizationDetails()
        {
            OrganizationDetails lstOrg = new OrganizationDetails();
            
            return lstOrg;

        }

        public virtual void getOrganizationRelationshipDetails(int empId)
        {
            OrganizationDetails orgEmpDet = new OrganizationDetails();

            Console.WriteLine($"Relationship Id : {orgEmpDet.EmployeeRelationShipId} Relationship Category Id: {orgEmpDet.SchoolRelationShipCategoryId} Relationship Category Name : {orgEmpDet.SchoolRelationShipCategoryName} Relationship-Department Name :{orgEmpDet.SchoolDepartmentId} ");
        }

        public virtual void getOrganizationRelationshipDetails(int studentId, int? stuRollNum)
        {
            OrganizationDetails orgStuDet = new OrganizationDetails();
            Console.WriteLine($"Relationship Id : {orgStuDet.StudentRelationShipId} Relationship Category Id: {orgStuDet.SchoolRelationShipCategoryId} Relationship Category Name : {orgStuDet.SchoolRelationShipCategoryName} Relationship-Department Name :{orgStuDet.SchoolDepartmentId} ");
        }

    }
}
