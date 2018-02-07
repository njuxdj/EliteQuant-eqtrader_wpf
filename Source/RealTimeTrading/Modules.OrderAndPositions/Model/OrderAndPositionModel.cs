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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Modules.OrderAndPositions.Model
{   
    public class OrderEntry : INotifyPropertyChanged
    {
        private long _orderid;
        private string _symbol;
        private string _name;
        private string _securityType;
        private int _direction;
        private int _orderFlag;
        private decimal _price;
        private int _quantity;
        private int _filled;
        private string _status;
        private int _orderTime;
        private int _cancelTime;
        private int _exchange;
        private string _account;
        private string _source;
        
      
        public OrderEntry(long id, string symbol, string name, string securityType, int direction, int orderFlag, decimal price,
            int quantity, int filled, string status, int orderTime, int cancelTime, int exchange, string account, string source) 
        {
            _orderid=id;
            _symbol=symbol;
            _name=name;
            _securityType=securityType;
            _direction=direction;
            _orderFlag=orderFlag;
            _price=price;
            _quantity=quantity;
            _filled=filled;
            _status=status;
            _orderTime=orderTime;
            _cancelTime=cancelTime;
            _exchange=exchange;
            _account=account;
            _source=source;
    }

        public long OrderId
        {
            get { return _orderid; }
            set
            {
                _orderid = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OrderId");
            }
        }


        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Symbol");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Name");
            }
        }
        public string SecurityType
        {
            get { return _securityType; }
            set
            {
                _securityType = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("SecurityType");
            }
        }
        public int Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Direction");
            }
        }
        public int OrderFlag
        {
            get { return _orderFlag; }
            set
            {
                _orderFlag = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OrderFlag");
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Price");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Quantity");
            }
        }
        public int Filled
        {
            get { return _filled; }
            set
            {
                _filled = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Filled");
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Status");
            }
        }
        public int OrderTime
        {
            get { return _orderTime; }
            set
            {
                _orderTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OrderTime");
            }
        }
        public int CancelTime
        {
            get { return _cancelTime; }
            set
            {
                _cancelTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("CancelTime");
            }
        }
        public int Exchange
        {
            get { return _exchange; }
            set
            {
                _exchange = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Exchange");
            }
        }
        public string Account
        {
            get { return _account; }
            set
            {
                _account = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Account");
            }
        }

        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Source");
            }
        }
        
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class OrderTable : ObservableCollection<OrderEntry> {}

    public class LogEntry : INotifyPropertyChanged
    {
        
        private int _logtime;
        private string _content;
        
        public LogEntry(int time, string content)
        {
            _logtime = time; _content = content;
        }
      

        public int LogTime
        {
            get { return _logtime; }
            set
            {
                _logtime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("LogTime");
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Content");
            }
        }
        
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class LogTable : ObservableCollection<LogEntry> { }

    public class FillEntry : INotifyPropertyChanged
    {
        private long _orderid;
        private long _fillid;
        private string _symbol;
        private string _name;
        private string _securityType;
        private int _direction;
        private int _orderFlag;
        private decimal _fillprice;
        private int _filled;
        private int _fillTime;
        private int _exchange;
        private string _account;
        private string _source;
      

        public FillEntry(long id, long fillid, string symbol, string name, string securityType, int direction, int orderFlag, decimal fillprice,
             int filled,  int fillTime,  int exchange, string account, string source)
        {
            _orderid = id;
            _fillid = fillid;
            _symbol = symbol;
            _name = name;
            _securityType = securityType;
            _direction = direction;
            _orderFlag = orderFlag;
            _fillprice = fillprice;
            _filled = filled;
            _fillTime = fillTime;
            _exchange = exchange;
            _account = account;
            _source = source;
        }
        public long OrderId
        {
            get { return _orderid; }
            set
            {
                _orderid = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OrderId");
            }
        }
        public long Fillid
        {
            get { return _fillid; }
            set
            {
                _fillid = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Fillid");
            }
        }
        
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Symbol");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Name");
            }
        }
        public string SecurityType
        {
            get { return _securityType; }
            set
            {
                _securityType = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("SecurityType");
            }
        }
        public int Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Direction");
            }
        }
        public int OrderFlag
        {
            get { return _orderFlag; }
            set
            {
                _orderFlag = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OrderFlag");
            }
        }
           
        public decimal Fillprice
        {
            get { return _fillprice; }
            set
            {
                _fillprice = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Fillprice");
            }
        }
       
        public int Filled
        {
            get { return _filled; }
            set
            {
                _filled = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Filled");
            }
        }
        
        public int FillTime
        {
            get { return _fillTime ; }
            set
            {
                _fillTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("FillTime");
            }
        }
       
        public int Exchange
        {
            get { return _exchange; }
            set
            {
                _exchange = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Exchange");
            }
        }
        public string Account
        {
            get { return _account; }
            set
            {
                _account = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Account");
            }
        }

        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Source");
            }
        }
        
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class FillTable : ObservableCollection<FillEntry> {}

    public class PositionEntry : INotifyPropertyChanged
    {
        private long _index;
        private string _symbol;
        private decimal _avgprice;
        private int _size;
        private decimal _closepl;
        private decimal _openpl;

        public PositionEntry(long index, string symbol, decimal avgprice, int size, decimal closepl, decimal openpl)
        {
            _index = index; _symbol = symbol; _avgprice = avgprice;
            _size = size; _closepl = closepl; _openpl = openpl;
        }

        public long Index
        {
            get { return _index; }
            set
            {
                _index = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Index");
            }
        }

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Symbol");
            }
        }

        public decimal AvgPrice
        {
            get { return _avgprice; }
            set
            {
                _avgprice = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("AvgPrice");
            }
        }

        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Size");
            }
        }

        public decimal ClosePL
        {
            get { return _closepl; }
            set
            {
                _closepl = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ClosePL");
            }
        }

        public decimal OpenPL
        {
            get { return _openpl; }
            set
            {
                _openpl = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("OpenPL");
            }
        }

         // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class PositionTable : ObservableCollection<PositionEntry> {}

    public class AccountEntry : INotifyPropertyChanged
    {
        private string _statistics;
        private string _result;

        public string Statistics
        {
            get { return _statistics; }
            set
            {
                _statistics = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Statistics");
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Result");
            }
        }

         // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class AccountTable : ObservableCollection<AccountEntry> {}


}
