using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementApplicationBAL;
using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;

namespace SchoolManagementApplication.Controllers
{
    public class EducatorController : Controller
    {
        /* Use of the EducatorDetailsBAL class to access the business logic layer for educator details. 
         * This class is injected into the controller through constructor injection, allowing for better separation of concerns and easier unit testing.
        */
        private readonly EducatorDetailsBAL _educatorBal;

        public EducatorController(EducatorDetailsBAL educatorBal)
        {
            _educatorBal = educatorBal;
        }



        //[HttpGet]
        //public IActionResult GetIndividualEducatorDetailsByRegistrationId()
        //{
        //    int educatorid = 0;
        //    EducatorDetailsBAL eduDetailsBAL = new EducatorDetailsBAL();

        //    /*This code is for grtting dropdown details*/
        //    List<EducatorDetailsForDropDown> educatorDetDrpDwn = new List<EducatorDetailsForDropDown>();
        //    educatorDetDrpDwn = eduDetailsBAL.fetchEducatorDetailsForDropDown(educatorid);
        //    ViewBag.EducatorList = new SelectList(educatorDetDrpDwn, "EducatorIdForDrpDwn", "EducatorFullNameForDrpDwn");
        //    /*code for grtting dropdown details ends*/

        //    return View();
        //}

        //[HttpPost]

        public JsonResult GetIndividualEducatorDetailsByRegistrationId(string value)
        {
            /*We will not be using the new EducatorDetailsBAL() anymore because we are using dependency injection */

            //EducatorDetailsBAL eduDetailsDrpDwnBAL = new EducatorDetailsBAL();

            List<EducatorDetails> educatDetails = new List<EducatorDetails>();

            educatDetails = _educatorBal.fetchEducatorDetailsByRegistrationId(Convert.ToInt32(value));

            return Json(educatDetails);
        }
        





    }
}
