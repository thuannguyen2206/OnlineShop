using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MyDatabase.DAO
{
    public class FeedbackDAO
    {
        OnlineShop db = null;
        public FeedbackDAO()
        {
            db = new OnlineShop();
        }

        public IEnumerable<Feedback> ListAllPaging(string searchText, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(x => x.name.Contains(searchText) || x.address.Contains(searchText) || x.content.Contains(searchText));
            }
            return model.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var cate = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
