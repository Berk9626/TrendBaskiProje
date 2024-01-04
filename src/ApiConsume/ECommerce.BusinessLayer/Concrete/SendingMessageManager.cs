using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.Repositories.Concrete;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class SendingMessageManager : BaseManager<SendingMessage>, ISendingMessageService
    {
        ISendingMessageDal _sendingMessageDal;
        public SendingMessageManager(ISendingMessageDal sendingMessageDal) : base(sendingMessageDal)
        {
            _sendingMessageDal = sendingMessageDal;
        }

        public int GetSendingMessageCount()
        {
            return _sendingMessageDal.GetSendingMessageCount();
            
        }
    }
}
