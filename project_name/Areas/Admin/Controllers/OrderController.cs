using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using solution_file.DataAccess.Repository.IRepository;
using solution_file.Models;

namespace project_name.Areas.Admin.Controllers
{
	[Area("admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
			return Json(new { data = objOrderHeaders });
		}
		
		
	}
}
