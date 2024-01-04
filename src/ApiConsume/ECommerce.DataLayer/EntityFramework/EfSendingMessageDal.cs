using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Concretes;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfSendingMessageDal : GenericRepository<SendingMessage>, ISendingMessageDal
    {
        private readonly Context _context;
        public EfSendingMessageDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetSendingMessageCount()
        {
            
            var values = _context.SendingMessages.Count();
            return values;
        }
    }
}
