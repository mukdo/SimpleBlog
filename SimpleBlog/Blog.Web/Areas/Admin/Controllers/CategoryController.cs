using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Blog.Framework;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryModel> _logger;

        public CategoryController( IConfiguration configuration , 
                                   ILogger<CategoryModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            return View(model);
        }

        public IActionResult CreateCategory()
        {
            var model = new CreateCategoryModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory([Bind(nameof(CreateCategoryModel.Name))] 
        CreateCategoryModel model )
            
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Category Create Successful", ResponseType.Success);
                   
                    //logger code
                    _logger.LogInformation("Category Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    _logger.LogError("Category Name already Exist");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category creation failued.", ResponseType.Failure);
                    _logger.LogError($"Category Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditCategory(int id)
        {
            var model = new EditCategoryModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory([Bind(nameof(EditCategoryModel.Id),
                                                nameof(EditCategoryModel.Name))]
                                            EditCategoryModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Category editing successful.", ResponseType.Success);
                    
                    //logger code
                    _logger.LogInformation("Category Edit Successful");
                   
                    return RedirectToAction("Index");
                    
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);

                    // error logger code
                    _logger.LogError($"Category Name Already Exist so Edit 'Failed'. Excption is : {ex.Message}");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category Edit Failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError( $"Category Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CategoryModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Category {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Category Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Category Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }

       
        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
    }
}