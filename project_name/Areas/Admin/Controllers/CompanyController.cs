using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using solution_file.DataAccess.Data;
using solution_file.DataAccess.Repository.IRepository;
using solution_file.Models;
using solution_file.Models.ViewModels;
using solution_file.Utility;

namespace project_name.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
           

            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id) 
        {
          
            if(id==null || id==0 )
            {
                //create
                return View(new Company());
            }
            else
            {
                //Update
                Company companyObj=_unitOfWork.Company.Get(u=>u.Id==id);
                return View(companyObj);
            }
             
            
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
           
            if (ModelState.IsValid)
            {
               
               
                if(CompanyObj.Id ==0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }

                
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else {
               
                return View(CompanyObj); 

            }           

        }
       
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Company deleted successfully";
            return RedirectToAction("Index");
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int?id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u =>u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { succes = false, message = "Error while deleting" });
            }
           
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
           return Json(new {success = true, message ="Deleted Succesfully"});
            
        }
        #endregion
    }
}
