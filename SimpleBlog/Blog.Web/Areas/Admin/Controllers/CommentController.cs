using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Areas.Admin.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class CommentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CommentModel> _logger;

        public CommentController (IConfiguration configuration,
                                   ILogger<CommentModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CommentModel>();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditCommentModel();
            model.Load(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind (nameof(EditCommentModel.Id),
                                               nameof(EditCommentModel.Email),
                                               nameof(EditCommentModel.Name),
                                               nameof(EditCommentModel.IsAprove),
                                               nameof(EditCommentModel.BlogcomposeId),
                                               nameof(EditCommentModel.Message)
                                               )]
                                         EditCommentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    model.Edit();
                    model.Response = new ResponseModel("Approve successful.", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Comment Approve Successfully");

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Comment Approve failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Comment Approve 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CommentModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Post {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Comment Delete failed.", ResponseType.Failure);
                    // error logger code
                    _logger.LogError($"Comment Delete 'Failed'. Excption is : {ex.Message}");
                }
            }
            return RedirectToAction("index");

        }
        public IActionResult GetComment()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CommentModel>();
            var data = model.GetComment(tableModel);
            return Json(data);
        }
    }
}
