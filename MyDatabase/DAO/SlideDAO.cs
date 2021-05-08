using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.DAO
{
    public class SlideDAO
    {
        OnlineShop db = null;
        public SlideDAO()
        {
            db = new OnlineShop();
        }

        public List<Slide> ListAllSlides()
        {
            return db.Slides.Where(x => x.status == true).OrderBy(x => x.displayOrder).ToList();
        }

        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public bool Update(Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.id);
                slide.imageLocation = entity.imageLocation;
                slide.displayOrder = entity.displayOrder;
                slide.link = entity.link;
                slide.descriptions = entity.descriptions;
                slide.modifyDate = DateTime.Now;
                slide.modifyBy = entity.modifyBy;
                slide.status = entity.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //xóa danh mục
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Slide GetSlideByID(int id)
        {
            return db.Slides.Find(id);
        }

    }
}
