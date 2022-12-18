using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer TGetByID(int id)
        {
            return _writerDal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }

        //public WriterManager(IWriterService writerDal)
        //{
        //    _writerDal = writerDal;
        //}

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }
    }
}
