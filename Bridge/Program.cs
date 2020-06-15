using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EMailSender();
            customerManager.Update();
            Console.ReadKey();
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Saved");
        }
        public abstract void Send();
    }
    class EMailSender : MessageSenderBase
    {
        public override void Send()
        {
            Console.WriteLine("Email send");
        }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send()
        {
            Console.WriteLine("Sms send");
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void Update()
        {
            MessageSenderBase.Send();
            Console.WriteLine("Customer update");
        }
    }
}
