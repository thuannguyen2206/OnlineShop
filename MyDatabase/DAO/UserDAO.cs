using MyDatabase.EF;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System;
using Common;

namespace MyDatabase.DAO
{
    public class UserDAO
    {
        OnlineShop db = null;

        public UserDAO()
        {
            db = new OnlineShop();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.userName == entity.userName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            else
                return user.id;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.id);
                user.email = entity.email;
                user.phone = entity.phone;
                user.name = entity.name;
                user.address = entity.address;
                user.modifyBy = entity.modifyBy;
                user.modifyDate = DateTime.Now;
                user.status = entity.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByID(int id)
        {
            return db.Users.Find(id);
        }

        //phân trang
        public IEnumerable<User> ListAllPaging(string searchText, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(x => x.userName.Contains(searchText) || x.name.Contains(searchText));
            }
            return model.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public User GetUserByName(string name)
        {
            return db.Users.SingleOrDefault(x => x.userName == name);
        }

        public int Login(string name, string pass, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.userName == name && x.password == pass);
            if (result != null)
            {
                if (isLoginAdmin == true)
                {
                    if((result.groupID == Constans.ADMIN_GROUP || result.groupID == Constans.MOD_GROUP))
                    {
                        if (result.status == true)
                            return 1;//đănng nhập thành công
                        else
                            return 0;//tài khoản bị khóa
                    }
                    else
                        return -2;//tài khoản này không phải của admin hay mod
                }
                else
                {
                    if (result.status == true)
                        return 1;//đănng nhập thành công
                    else
                        return 0;//tài khoản bị khóa
                }   
            }
            else
                return -1;//đăng nhập thất bại
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
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
            var user = db.Users.Find(id);
            user.status = !user.status;
            db.SaveChanges();
            return user.status;
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.userName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.email == email) > 0;
        }

        public List<string> GetListPermission(string username)
        {
            var user = db.Users.Single(x => x.userName == username);
            var data = (from a in db.Permissions
                        join b in db.UserGroups on a.userGroupID equals b.id
                        join c in db.Roles on a.roleID equals c.id
                        where b.id == user.groupID
                        select new
                        {
                            roleID = a.roleID,
                            userGroupID = a.userGroupID
                        }).AsEnumerable().Select(y => new Permission() {
                            roleID = y.roleID,
                            userGroupID = y.userGroupID
                        });

            return data.Select(z => z.roleID).ToList();
        }

        public List<UserGroup> GetListUserGroup()
        {
            return db.UserGroups.ToList();
        }

    }
}
