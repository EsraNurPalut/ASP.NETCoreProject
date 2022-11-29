using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        EFCategoryRepository eFCategoryRepository;
        public CategoryManager() //contructor metot
        {
            eFCategoryRepository = new EFCategoryRepository();
            //yapıcı metotun içine newleme ilemi.
        }
        
        public void CategorUpdate(Category category)
        {
            eFCategoryRepository.Update(category);
        }

        public void CategoryAdd(Category category)
        {
            eFCategoryRepository.Insert(category);
            
        }

        public void CategoryDelete(Category category)
        {
            eFCategoryRepository.Delete(category);
        }

        public Category GetByID(int id)
        {
            return eFCategoryRepository.GetByID(id);
        }

        public List<Category> GetList()
        {
            return eFCategoryRepository.GetListAll();
        }
    }
}
