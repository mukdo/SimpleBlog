using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Areas.Admin.Models.BlogCompose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class BlogComposeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlogComposeModel> _logger;

        public BlogComposeController(IConfiguration configuration , ILogger<BlogComposeModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<BlogComposeModel>();
            return View(model);
        }

        public IActionResult CreatePost()
        {
            var model = new CreateBlogComposeModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost([Bind (nameof(CreateBlogComposeModel.Title),
                                               nameof(CreateBlogComposeModel.Body),
                                               nameof(CreateBlogComposeModel.ImageFile),
                                               nameof(CreateBlogComposeModel.CategoryId))] 
                                         CreateBlogComposeModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Blog Post Create Successful", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Blog Post Create Sucessfully");

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Blog Post failued.", ResponseType.Failure);
                    _logger.LogError($"BlogPost Create 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult EditPost(int id)
        {
            var model = new EditBlogComposeModel();
            model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost([Bind (nameof(EditBlogComposeModel.Id),
                                               nameof(EditBlogComposeModel.Title),
                                               nameof(EditBlogComposeModel.Body),
                                               nameof(EditBlogComposeModel.DateTime),
                                               nameof(EditBlogComposeModel.ImageFile),
                                               nameof(EditBlogComposeModel.CategoryId))]
                                         EditBlogComposeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Blog Post editing successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Blog Post Edit Successfully");

                    return RedirectToAction("Index");

                }
                
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Blog Post Edit failued.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Blog Post Edit 'Failed'. Excption is : {ex.Message}");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new BlogComposeModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Post {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Post Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Blog Post Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }

        public IActionResult GetPost()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<BlogComposeModel>();
            var data = model.GetBlogCompose(tableModel);
            return Json(data);
        }
    }
}