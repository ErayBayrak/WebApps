using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        private IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }
        public void DraftAdd(Draft draft)
        {
            _draftDal.Insert(draft);
        }

        public void DraftDelete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }

        public Draft GetById(int id)
        {
            return _draftDal.Get(x=>x.DraftID==id);
        }

        public List<Draft> GetListInbox(string p)
        {
            return _draftDal.List(x => x.ReceiverMail == p);
        }

        public List<Draft> GetListSendbox(string p)
        {
            return _draftDal.List(x => x.SenderMail == p);
        }
    }
}
