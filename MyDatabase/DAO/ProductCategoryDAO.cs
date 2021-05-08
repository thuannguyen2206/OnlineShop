using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MyDatabase.DAO
{
    public class ProductCategoryDAO
    {
        OnlineShop db = null;
        public ProductCategoryDAO()
        {
            db = new OnlineShop();
        }

        public List<ProductsCategory> ListAllProductCategory()
        {
            return db.ProductsCategories.Where(x => x.status == true).OrderBy(x => x.displayOrder).ToList();
        }

        public ProductsCategory ViewDetail(int id)
        {
            return db.ProductsCategories.Find(id);
        }

        public IEnumerable<ProductsCategory> ListAllPaging(string searchText, int page, int pageSize)
        {
            IQueryable<ProductsCategory> model = db.ProductsCategories;
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(x => x.name.Contains(searchText));
            }
            return model.OrderBy(x => x.createDate).ToPagedList(page, pageSize);
        }

        public int Insert(ProductsCategory cate)
        {
            db.ProductsCategories.Add(cate);
            db.SaveChanges();
            return cate.id;
        }

        public bool Update(ProductsCategory entity)
        {
            try
            {
                var procate = db.ProductsCategories.Find(entity.id);
                procate.name = entity.name;
                procate.metaTitle = entity.metaTitle;
                procate.seoTitle = entity.seoTitle;
                procate.modifyDate = DateTime.Now;
                procate.modifyBy = entity.modifyBy;
                procate.metaKeyword = entity.metaKeyword;
                procate.showOnHome = entity.showOnHome;
                procate.status = entity.status;
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
                //xóa sản phẩm của danh mục đó
                db.Products.RemoveRange(db.Products.Where(y => y.categoryID == id));
                //xóa danh mục
                var procate = db.ProductsCategories.Find(id);
                db.ProductsCategories.Remove(procate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductsCategory GetProductCategoryByID(int id)
        {
            return db.ProductsCategories.Find(id);
        }

        public List<ProductsCategory> GetListProductCategory()
        {
            return db.ProductsCategories.ToList();
        }


    }
}
