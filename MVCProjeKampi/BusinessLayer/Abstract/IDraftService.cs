using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetListInbox(string p);
        List<Draft> GetListSendbox(string p);
        void DraftAdd(Draft draft);
        void DraftDelete(Draft draft);
        void DraftUpdate(Draft draft);
        Draft GetById(int id);
    }
}
