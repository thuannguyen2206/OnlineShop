using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.DAO
{
    public class MenuDAO
    {
        OnlineShop db = null;
        public MenuDAO()
        {
            db = new OnlineShop();
        }

        public List<Menu> ListMenuByTypeID(int typeID)
        {
            var result = db.Menus.Where(x => x.typeID == typeID && x.status == true).OrderBy(x => x.displayOrder).ToList();
            return result;
        }

        public List<MenuType> ListAllMenuType()
        {
            return db.MenuTypes.ToList();
        }

        public List<Menu> ListAllMenus()
        {
            return db.Menus.Where(x => x.status == true).OrderBy(x => x.typeID).ToList();
        }

        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menus.Find(entity.id);
                menu = entity;
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
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Menu GetMenuByID(int id)
        {
            return db.Menus.Find(id);
        }

    }
}
