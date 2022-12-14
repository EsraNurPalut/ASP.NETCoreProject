using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal; //ıcommentdaldan commentdal isminde nesne ürettik.

        public CommentManager(ICommentDal commentdal) //constructor metotum
        {
            _commentdal = commentdal;
        }

        public void CommentAdd(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }

        //public List<Comment> GetList()
        //{
        //    throw new NotImplementedException();
        //}
    } 
}
