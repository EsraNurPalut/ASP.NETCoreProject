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

        //public WriterManager(IWriterService writerDal)
        //{
        //    _writerDal = writerDal;
        //}

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }
    }
}
