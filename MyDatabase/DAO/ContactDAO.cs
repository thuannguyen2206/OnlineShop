using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.DAO
{
    public class ContactDAO
    {
        OnlineShop db = null;
        public ContactDAO()
        {
            db = new OnlineShop();
        }

        public Contact GetActiveContact()
        {
            return db.Contacts.SingleOrDefault(x => x.status == true);
        }

        public int InsertFeedback(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.id;
        }

    }
}
