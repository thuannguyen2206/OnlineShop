using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MyDatabase.DAO
{
    public class ProductDAO
    {
        OnlineShop db = null;
        public ProductDAO()
        {
            db = new OnlineShop();
        }

        public IEnumerable<Product> ListProduct(int page, int pageSize)
        {
            return db.Products.Where(x => x.status == true).OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.name.Contains(keyword)).Select(x => x.name).ToList();
        }
        
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.Where(x => x.status == true).OrderByDescending(x => x.createDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.topHot != null && x.topHot > DateTime.Now).OrderByDescending(x => x.createDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProduct(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.id != productID && x.categoryID == product.categoryID).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> ListProductByCategoryID(int categoryID, int page, int pageSize)
        {
            return db.Products.Where(x=>x.categoryID == categoryID && x.status==true).OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize)
        {
            var result = db.Products.Where(x => x.name.Contains(keyword) && x.status == true).OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
            return result;
        }

        //trong admin
        //phân trang
        public IEnumerable<Product> ListAllPaging(string searchText, int categoryID, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products.Where(x => x.categoryID == categoryID);
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(y => y.name.Contains(searchText));
            }
            return model.OrderByDescending(z => z.createDate).ToPagedList(page, pageSize);
        }

        public List<ProductsCategory> GetListProductCategory()
        {
            return db.ProductsCategories.ToList();
        }

        public long Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.id;
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.id);
                product.name = entity.name;
                product.code = entity.code;
                product.descriptions = entity.descriptions;
                product.imageLocation = entity.imageLocation;
                product.price = entity.price;
                product.discountPrice = entity.discountPrice;
                product.categoryID = entity.categoryID;
                product.detail = entity.detail;
                product.guarantee = entity.guarantee;
                product.metaTitle = entity.metaTitle;
                product.modifyDate = DateTime.Now;
                product.modifyBy = entity.modifyBy;
                product.metaKeyword = entity.metaKeyword;
                product.status = entity.status;
                product.topHot = entity.topHot;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product GetProductByID(long id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                //xóa danh mục
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var product = db.Products.Find(id);
            product.status = !product.status;
            db.SaveChanges();
            return product.status;
        }

    }
}
