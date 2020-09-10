using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Framework.BlogCompose
{
    public class BlogComposeService : IBlogComposeService
    {
        private IBlogUnitOfWork _blogUnitOfWork;

        public BlogComposeService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateCompose(BlogComposes blogComposes)
        {
            _blogUnitOfWork.BlogRepository.Add(blogComposes);
            _blogUnitOfWork.Save();
        }

        public BlogComposes DeleteCompose(int Id)
        {
            var blogCompose = _blogUnitOfWork.BlogRepository.GetById(Id);
            _blogUnitOfWork.BlogRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return blogCompose;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditCompose(BlogComposes blogComposes)
        {
            var existingCompose = _blogUnitOfWork.BlogRepository.GetById(blogComposes.Id);
            existingCompose.Title = blogComposes.Title;
            existingCompose.Body = blogComposes.Body;
            existingCompose.ImageUrl = blogComposes.ImageUrl;
            existingCompose.CategoryId = blogComposes.CategoryId;

            _blogUnitOfWork.Save();

        }

        public BlogComposes GetCompose(int Id)
        {
            return _blogUnitOfWork.BlogRepository.GetById(Id);
        }

        public (IList<BlogComposes> composes, int total, int totalDisplay) GetComposes(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.BlogRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
