using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Web.Models;
using Blog.Framework;
using Blog.Web.Areas.Admin.Models.BlogCompose;
using Blog.Web.Areas.Admin.Models.Comments;
using Blog.Web.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FrameworkContext _context;

        public HomeController(ILogger<HomeController> logger , FrameworkContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var post = _context.BlogComposes.OrderByDescending(d => d.Date);
            ViewBag.Post = post;
            return View();
        }
        public IActionResult Post(int id)
        {
            var model = new EditBlogComposeModel();
            model.Load(id);
            var comment = _context.Comments.Where(c => c.BlogComposeId == id && c.IsAprove==true);
            ViewBag.Comment = comment;
            return View(model);

        }

        public IActionResult Comment()
        {
            var model = new AddCommentModel();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Comment([Bind(nameof(AddCommentModel.BlogComposesId),
                                           nameof(AddCommentModel.Name),
                                           nameof(AddCommentModel.Email),
                                           nameof(AddCommentModel.Message),
                                           nameof(AddCommentModel.IsAprove))] 
                                      AddCommentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add();
                    model.Response = new ResponseModel("Comment Successful Wating for Review", ResponseType.Success);

                    //logger code
                    _logger.LogInformation("Comment Create Sucessfully");

                    return RedirectToAction("Post", new { id =model.BlogComposesId} );
                }

                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Comment failued.", ResponseType.Failure);
                    _logger.LogError($"Comment Add 'Failed'. Excption is : {ex.Message}");
                }
            }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
