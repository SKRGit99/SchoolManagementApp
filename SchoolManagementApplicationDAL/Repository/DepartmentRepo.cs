using SchoolManagementApplicationDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApplicationDAL.Repository
{
    public class DepartmentRepo : OrganizationRepo
    {
        private readonly string _connString = "Server=SAMPAT-PC\\;Database=SchoolManagementAppDevDb;Integrated Security=True;";
        public DepartmentRepo() 
        {
        
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

        public virtual void getDepartmentDetails(int empId)
        {
            DepartmentDetails deptEmpDet = new DepartmentDetails();
            Console.WriteLine($"Department Id : {deptEmpDet.DepartmentId} Department Name :{deptEmpDet.DepartmentName}");
        }
        public virtual void getDepartmentDetails(int studentId, int? rollNum)
        {
            DepartmentDetails deptStuDet = new DepartmentDetails();
            Console.WriteLine($"Department Id : {deptStuDet.DepartmentId} Department Name :{deptStuDet.DepartmentName}");
        }

        public decimal getDepartmentWiseExpenses(int deptId)
        {
            decimal _deptExpenses = 0;

            return _deptExpenses;
        }
    }
}
