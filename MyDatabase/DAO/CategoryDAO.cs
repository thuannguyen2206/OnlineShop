using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MyDatabase.DAO
{
    public class CategoryDAO
    {
        OnlineShop db = null;
        public CategoryDAO()
        {
            db = new OnlineShop();
        }

        public int Insert(Category cate)
        {
            db.Categories.Add(cate);
            db.SaveChanges();
            return cate.id;
        }

        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Categories.Find(entity.id);
                cate.name = entity.name;
                cate.metaTitle = entity.metaTitle;
                cate.seoTitle = entity.seoTitle;
                cate.modifyDate = DateTime.Now;
                cate.modifyBy = entity.modifyBy;
                cate.metaKeyword = entity.metaKeyword;
                cate.metaDecription = entity.metaDecription;
                cate.showOnHome = entity.showOnHome;
                cate.status = entity.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Category> ListCategory()
        {
            return db.Categories.Where(x => x.status == true).ToList();
        }

        public ProductsCategory ViewDetail(int id)
        {
            return db.ProductsCategories.Find(id);
        }

        public IEnumerable<Category> ListAllPaging(string searchText, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(x => x.name.Contains(searchText) || x.seoTitle.Contains(searchText));
            }
            return model.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }
        
        public Category GetCategoryByID(int id)
        {
            return db.Categories.Find(id);
        }

    }
}
