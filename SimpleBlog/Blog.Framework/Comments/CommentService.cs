using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Framework.Comments
{
    public class CommentService : ICommentService
    {
        private IBlogUnitOfWork _blogUnitOfWork;
        public CommentService( IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public void CreateComment(Comment comment)
        {
            _blogUnitOfWork.CommentRepository.Add(comment);
            _blogUnitOfWork.Save();
        }

        public Comment DeleteComment(int Id)
        {
            var commnet = _blogUnitOfWork.CommentRepository.GetById(Id);
            _blogUnitOfWork.CommentRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return commnet;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditComment(Comment comment)
        {
            var exitingComment = _blogUnitOfWork.CommentRepository.GetById(comment.Id);
            exitingComment.Name = comment.Name;
            exitingComment.Email = comment.Email;
            exitingComment.Message = comment.Message;
            exitingComment.IsAprove = comment.IsAprove;

            _blogUnitOfWork.Save();
        }

        public Comment GetComment(int Id)
        {
            return _blogUnitOfWork.CommentRepository.GetById(Id);
        }

        public (IList<Comment> comments, int total, int totalDisplay) GetComments(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.CommentRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
