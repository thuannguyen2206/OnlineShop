using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using PagedList;

namespace MyDatabase.DAO
{
    public class ContentDAO
    {
        OnlineShop db = null;
        public ContentDAO()
        {
            db = new OnlineShop();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }

        public Tag GetTag(string id)
        {
            return db.Tags.Find(id);
        }

        public long Create(Content content)
        {
            //xử lý alias
            if (string.IsNullOrEmpty(content.metaTitle))
            {
                content.metaTitle = StringHelper.ConvertToUnSign(content.name);
            }
            content.viewCount = 0;
            content.createDate = DateTime.Now;
            db.Contents.Add(content);
            db.SaveChanges();

            if (!string.IsNullOrEmpty(content.tags))
            {
                string[] tags = content.tags.Split(',');
                foreach (var tag in tags)
                {
                    var tagID = StringHelper.ConvertToUnSign(tag);
                    bool existTag = CheckTag(tagID);
                    //insert vào bảng Tag
                    if (!existTag)
                    {
                        InsertTag(tagID, tag);
                    }

                    //insert vào bảng ContentTag
                    InsertContentTag(content.id, tagID);
                }
            }
            return content.id;
        }

        public long Update(Content content)
        {
            //xử lý alias
            if (string.IsNullOrEmpty(content.metaTitle))
            {
                content.metaTitle = StringHelper.ConvertToUnSign(content.name);
            }
            content.createDate = DateTime.Now;
            db.SaveChanges();

            if (!string.IsNullOrEmpty(content.tags))
            {
                RemoveAllContentTag(content.id);

                string[] tags = content.tags.Split(',');
                foreach (var tag in tags)
                {
                    var tagID = StringHelper.ConvertToUnSign(tag);
                    bool existTag = CheckTag(tagID);
                    //insert vào bảng Tag
                    if (!existTag)
                    {
                        InsertTag(tagID, tag);
                    }

                    //insert vào bảng ContentTag
                    InsertContentTag(content.id, tagID);
                }
            }
            return content.id;
        }

        public bool Delete(long id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveAllContentTag(long contentID)
        {
            db.ContentTags.RemoveRange(db.ContentTags.Where(x => x.contentID == contentID));
            db.SaveChanges();
        }

        public void InsertTag(string id, string name)
        {
            var tag = new Tag();
            tag.id = id;
            tag.name = name;
            db.Tags.Add(tag);
            db.SaveChanges();
        }

        public void InsertContentTag(long contentID, string tagID)
        {
            var contentTag = new ContentTag();
            contentTag.contentID = contentID;
            contentTag.tagID = tagID;
            db.ContentTags.Add(contentTag);
            db.SaveChanges();
        }

        public bool CheckTag(string id)
        {
            return db.Tags.Count(x => x.id == id) > 0;
        }

        //phân trang
        public IEnumerable<Content> ListAllPaging(string searchText, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchText))//nếu input search # rỗng thì search theo searchText
            {
                model = model.Where(x => x.name.Contains(searchText));
            }
            return model.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Content> ListAllPagingForClient(int page, int pageSize)
        {
            return db.Contents.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

        public List<Tag> ListTags(long contentID)
        {
            var result = (from a in db.Tags
                          join b in db.ContentTags
                          on a.id equals b.tagID
                          where b.contentID == contentID
                          select new
                          {
                              id = b.tagID,
                              name = a.name
                          }).AsEnumerable().Select(x => new Tag()
                          {
                              id = x.id,
                              name = x.name
                          });
            return result.ToList();
        }

        public IEnumerable<Content> ListAllContentByTag(string tagID, int page, int pageSize)
        {
            var result = (from a in db.Contents
                          join b in db.ContentTags
                          on a.id equals b.contentID
                          where b.tagID == tagID
                          select new
                          {
                              name = a.name,
                              metaTitle = a.metaTitle,
                              imageLocation = a.imageLocation,
                              descriptions = a.descriptions,
                              createBy = a.createBy,
                              createDate = a.createDate,
                              id = a.id
                          }).AsEnumerable().Select(x => new Content()
                          {
                              name = x.name,
                              metaTitle = x.metaTitle,
                              imageLocation = x.imageLocation,
                              descriptions = x.descriptions,
                              createBy = x.createBy,
                              createDate = x.createDate,
                              id = x.id
                          });
            return result.OrderByDescending(x => x.createDate).ToPagedList(page, pageSize);
        }

    }
}
