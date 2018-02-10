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

namespace TradingBase
{
    /// <summary>
    /// track the last bid/ask/trade data for securities
    /// </summary>
    public class TickTracker
    {
        Dictionary<string, decimal> _bids;
        Dictionary<string, decimal> _asks;
        Dictionary<string, int> _bidsizes;
        Dictionary<string, int> _asksizes;
        Dictionary<string, decimal> _trades;
        Dictionary<string, int> _tradesizes;
        Dictionary<string, int> _lastdates;
        Dictionary<string, int> _lasttimes;

        public TickTracker(int capacity) 
        {
            _bids = new Dictionary<string, decimal>(capacity);
            _asks = new Dictionary<string, decimal>(capacity);
            _bidsizes = new Dictionary<string, int>(capacity);
            _asksizes = new Dictionary<string, int>(capacity);
            _trades = new Dictionary<string, decimal>(capacity);
            _tradesizes = new Dictionary<string, int>(capacity);
            _lastdates = new Dictionary<string, int>(capacity);
            _lasttimes = new Dictionary<string, int>(capacity);
        }
        public void GotTick(Tick k)
        {
            string s = k.FullSymbol;

            if (!_trades.ContainsKey(s))
            {
                _bids.Add(s, 0);
                _asks.Add(s,0);
                _bidsizes.Add(s,0);
                _asksizes.Add(s,0);
                _trades.Add(s,0);
                _tradesizes.Add(s,0);
                _lastdates.Add(s,0);
                _lasttimes.Add(s,0);
            }
                
            
            _lastdates[s] = k.Date.Day;
            _lasttimes[s] = (int)k.Time;

            if (k.TickType==TickType.TRADE)
            {
                _trades[s] = k.Price;
                _tradesizes[s] = k.Size;
            }
            if (k.TickType == TickType.FULL || k.TickType == TickType.ASK)
            {
                _asks[s] = k.AskPriceL1;
                _asksizes[s] = k.AskSizeL1;
            }
            if (k.TickType == TickType.FULL || k.TickType == TickType.BID)
            {
                _bids[s] = k.BidPriceL1;                    
                _bidsizes[s] = k.BidSizeL1;
            }
        }

        public void Clear()
        {
            _bids.Clear();
            _asks.Clear();
            _bidsizes.Clear();
            _asksizes.Clear();
            _trades.Clear();
            _tradesizes.Clear();
            _lastdates.Clear();
            _lasttimes.Clear();
        }

        public int Count
        {
            get { return _trades.Count; }
        }

        public bool IsTracked(string symbol)
        {
            return _trades.ContainsKey(symbol);
        }

        public Tick this[string symbol]
        {
            get
            {
                if (!IsTracked(symbol)) return new Tick();
                Tick k = new Tick(symbol);
                k.Time = _lasttimes[symbol];
                k.Price = _trades[symbol];
                k.Size = _tradesizes[symbol];
                k.BidPriceL1 = _bids[symbol];
                k.BidSizeL1 = _bidsizes[symbol];
                k.AskPriceL1 = _asks[symbol];
                k.AskSizeL1 = _asksizes[symbol];
                return k;
            }
        }

        #region properties
        public decimal Bid(string sym) { return _bids[sym]; }
        public decimal Ask(string sym) { return _asks[sym]; }
        public decimal Last(string sym) { return _trades[sym]; }
        public bool HasBid(string sym) { return _bids[sym] != 0; }
        public bool HasAsk(string sym) { return _asks[sym] != 0; }
        public bool HasLast(string sym) { return _trades[sym] != 0; }
        public bool HasAll(string sym) { return HasBid(sym) && HasAsk(sym) && HasLast(sym); }
        public bool HasQuote(string sym) { return HasBid(sym) && HasAsk(sym); }
        #endregion
    }
}
