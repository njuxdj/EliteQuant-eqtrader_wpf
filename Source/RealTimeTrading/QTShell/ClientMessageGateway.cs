using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Modules.Framework.Events;
using Modules.OrderAndPositions.Model;
using NNanomsg;
using NNanomsg.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBase;

namespace QTShell
{

    public class ClientMessageGateway
    {
        #region 字段

        private IEventAggregator _eventaggregator;
        private PairSocket msg_sock;
        private SubscribeSocket tick_sock;
        private Queue<String> outgoing_queue;
        private readonly ILoggerFacade _logger;
       

        #endregion

        #region 构造函数 

        public ClientMessageGateway(IEventAggregator eventAggregator, ILoggerFacade logger)
        {
            _eventaggregator = eventAggregator;
            _logger = logger;
            outgoing_queue = new Queue<string>();

            _eventaggregator.GetEvent<SendOrderEvent>().Subscribe((order)=> {
                outgoing_queue.Enqueue(order);
            });

            tick_sock = new SubscribeSocket();
            msg_sock = new PairSocket();

            NanomsgSocketOptions.SetTimespan(tick_sock.SocketID, SocketOptionLevel.Default, SocketOption.RCVTIMEO, TimeSpan.FromMilliseconds(100));
            NanomsgSocketOptions.SetString(tick_sock.SocketID, SocketOptionLevel.Subscribe, SocketOption.SUB_SUBSCRIBE,"");
            NanomsgSocketOptions.SetTimespan(msg_sock.SocketID, SocketOptionLevel.Default, SocketOption.RCVTIMEO, TimeSpan.FromMilliseconds(100));

            tick_sock.Connect("tcp://127.0.0.1:55555");
            msg_sock.Connect("tcp://127.0.0.1:55558");
        }

        #endregion

        public void RunMessageProcessLoop()
        {
            while (true)
            {
                byte[] data = tick_sock.Receive();
                //获取消息
                if (data!=null && data.Length> 0)
                {
                    string marketmsg = Encoding.UTF8.GetString(data);
                    if(marketmsg.IndexOf('|')>0)
                    {
                        Tick k = Tick.Deserialize(marketmsg);
                       
                        _eventaggregator.GetEvent<MarketDataEvent>().Publish(k);
                       
                    }
                }
                byte[] buf1 = msg_sock.Receive();

                if (buf1 != null && buf1.Length > 0)
                {
                    string generalmsg = Encoding.UTF8.GetString(buf1);
                    string[] v=generalmsg.Split('|');
                    if (v[0] == "s")
                    {
                        Order order = new Order();
                        order.Id = Convert.ToInt32(v[1]);
                        order.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus),v[2]);
                        _eventaggregator.GetEvent<OrderStatusEvent>().Publish(order);
                    }
                    else if (v[0] == "f")
                    {
                        Order order = new Order();
                        order.Id= Convert.ToInt32(v[1]);
                        order.TradeTime= Convert.ToInt32(v[2]);
                        order.TradePrice = Convert.ToDecimal(v[3]);
                        order.TradeSize = Convert.ToInt32(v[4]);
                        _eventaggregator.GetEvent<OrderFillEvent>().Publish(order);
                       
                    }
                    else if (v[0] == "n")
                    {
                        Position p = new Position();
                        p.FullSymbol = v[0]; // should exist
                        p.AvgPrice=Convert.ToDecimal(v[1]);
                        p.Size = Convert.ToInt32(v[3]);
                        p.ClosedPL = Convert.ToDecimal(v[4]);
                        p.OpenPL = Convert.ToDecimal(v[2]);

                        _eventaggregator.GetEvent<PositionEvent>().Publish(p);
                    }
                    else if (v[0] == "h")
                    {

                        _eventaggregator.GetEvent<HistoricalEvent>().Publish(generalmsg);
                    }
                    else if (v[0] == "u")
                    {
                        AccountEntry account = new AccountEntry();
                        account.AccountId = v[1];
                        account.YestNet=Convert.ToDecimal(v[2]);
                        account.Net = Convert.ToDecimal(v[3]);
                        account.Available = Convert.ToDecimal(v[4]);
                        account.Commision = Convert.ToDecimal(v[5]);
                        account.Margin = Convert.ToDecimal(v[6]);
                        account.ClosedPnL = Convert.ToDecimal(v[7]);
                        account.OpenPnL = Convert.ToDecimal(v[8]);
                        //account.Brokerage = 
                        account.Time =v[8];
                        _eventaggregator.GetEvent<AccountEvent>().Publish(account);
                    }
                    else if (v[0] == "r")
                    {
                        _eventaggregator.GetEvent<ContractEvent>().Publish(generalmsg);
                    }
                    else if (v[0] == "m")
                    {
                        var generalMessage = new GeneralMessage(v[v.Length-1].Trim(), v[v.Length-2]);
                        _eventaggregator.GetEvent<GeneralMessageEvent>().Publish(generalMessage);
                    }
                   
                }

                if (outgoing_queue.Count > 0)
                {
                    String msg3 = outgoing_queue.Dequeue();
                    _logger.Log("send order msg: "+ msg3, Category.Info, Priority.High);
                    msg_sock.Send(Encoding.UTF8.GetBytes(msg3));
                }
            }
        }

    }
}
