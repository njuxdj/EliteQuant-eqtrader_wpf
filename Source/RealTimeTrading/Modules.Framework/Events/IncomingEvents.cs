/****************************** Project Header ******************************\
Project:	      QuantTrading
Author:			  Letian_zj @ Codeplex
URL:			  https://quanttrading.codeplex.com/
Copyright 2014 Letian_zj

This file is part of QuantTrading Project.

QuantTrading is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, 
either version 3 of the License, or (at your option) any later version.

QuantTrading is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with QuantTrading. 
If not, see http://www.gnu.org/licenses/.

\***************************************************************************/
using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using TradingBase;


namespace Modules.Framework.Events
{
    /*
    public class OrderConfirmationEvent : PubSubEvent<Order>
    {
    }

    public class OrderCancelConfirmationEvent : PubSubEvent<long>
    {
    }
    
    public class OrderFillEvent : PubSubEvent<Trade>
    {
    }
   
    public class InitialPositionEvent : PubSubEvent<Position>
    {
    }

    public class HistBarEvent : PubSubEvent<Bar>
    {
    }
     */
    public class MarketDataEvent : PubSubEvent<Tick>
    {
    }
    public class OrderStatusEvent : PubSubEvent<Order>
    {
    }
    public class OrderFillEvent : PubSubEvent<Order>
    {
    }
    public class PositionEvent : PubSubEvent<Position>
    {
    }
    public class HistoricalEvent : PubSubEvent<string>
    {
    }
    public class AccountEvent : PubSubEvent<object>
    {
    }
    public class ContractEvent : PubSubEvent<string>
    {
    }
    public class GeneralMessageEvent : PubSubEvent<GeneralMessage>
    {
    }

    [Serializable]
    public sealed class MyEventArgs<TData> : EventArgs
    {
        private readonly TData _value;

        public MyEventArgs(TData value)
        {
            _value = value;
        }
        public TData Value
        {
            get { return _value; }
        }
    }

    public class GeneralMessage {

        public string Time;
        public string Content;

        public GeneralMessage(string time,string content)
        {
            Time = time;
            Content = content;

        }
    }
}
