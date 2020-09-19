using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Areas.Admin.Models.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Areas.Admin.Controllers
{
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
            return View();
        }
    }
}
