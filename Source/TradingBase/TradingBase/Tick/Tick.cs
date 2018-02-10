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



    public enum OrderFlag
    {
        OPEN = 0,
        CLOSE = 1,
        CLOSE_TODAY = 2,
        CLOSE_YESTERDAY = 3
    }
    /// <summary>
    /// Tick can be a quote (bid/ask) or a trade
    /// Size < 0 means index
    /// </summary>
    [Serializable]
    public class Tick
    {
        public string FullSymbol { get; set; }
        public int Time { get; set; }
        public TickType TickType{get;set;}
        public decimal Price { get; set; }
        public int Size { get; set; }
        
        public int Depth { get; set; }
        public decimal BidPriceL1 { get; set; }
        public int BidSizeL1 { get; set; }
        public decimal AskPriceL1 { get; set; }
        public int AskSizeL1 { get; set; }
        public decimal OpenInterest { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal PreClose { get; set; }
        public decimal UpperLimitPrice { get; set; }
        public decimal LowerLimitPrice { get; set; }
        public DateTime Date
        {
            get
            {
                return new DateTime(Time).Date;
            }
        }

        public Tick():this("")
        {
        }

        public Tick(string fullsymbol)
        {
            FullSymbol = fullsymbol;
            Time = 0;
            Time = 0;
            Size = 0;
            Price = 0;
            Depth = 0;
        }

        public static Tick NewTrade(string fullsym, int time, decimal trade, int size)
        {
            Tick t = new Tick(fullsym);
            
            t.Time = time;
            t.Price = trade;
            t.Size = size;
            t.BidPriceL1 = 0m;
            t.AskPriceL1 = 0m;
            return t;
        }

        public override string ToString()
        {
            return Serialize(this);
        }

        public static string Serialize(Tick t)
        {
            const char d = '|';
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(t.FullSymbol);
            sb.Append(d);
            sb.Append(t.Time);
            sb.Append(d);
            sb.Append(t.TickType);
            sb.Append(d);
            sb.Append(t.Price);
            sb.Append(d);
            sb.Append(t.Size);
            sb.Append(d);
            sb.Append(t.Depth);
            sb.Append(d);
            sb.Append(t.BidPriceL1);
            sb.Append(d);
            sb.Append(t.BidSizeL1);
            sb.Append(d);
            sb.Append(t.AskPriceL1);
            sb.Append(d);
            sb.Append(t.AskSizeL1);
            sb.Append(d);
            sb.Append(t.OpenInterest);
            sb.Append(d);
            sb.Append(t.Open);
            sb.Append(d);
            sb.Append(t.High);
            sb.Append(d);
            sb.Append(t.Low);
            sb.Append(d);
            sb.Append(t.PreClose);
            sb.Append(d);
            sb.Append(t.UpperLimitPrice);
            sb.Append(d);
            sb.Append(t.LowerLimitPrice);
            
            return sb.ToString();
        }

        public static Tick Deserialize(string msg)
        {
            string[] r = msg.Split('|');
            Tick t = new Tick();
            decimal d = 0;
            int i = 0;
            t.FullSymbol = r[0];
            t.Time =Convert.ToInt32( r[1]);
            t.TickType = (TickType)Enum.Parse(typeof(TickType),r[2]);
            t.Price= Convert.ToDecimal(r[3]);
            t.Size = Convert.ToInt32(r[4]);
            t.Depth = Convert.ToInt32(r[5]);
           
               if (t.TickType == TickType.FULL)
               {
                   t.BidPriceL1 = Convert.ToDecimal(r[6]);
                t.BidSizeL1 = Convert.ToInt32(r[7]);
                t.AskPriceL1 = Convert.ToDecimal(r[8]);
                t.AskSizeL1 = Convert.ToInt32(r[9]);
                t.OpenInterest= Convert.ToDecimal(r[10]);
                t.Open = Convert.ToDecimal(r[11]);
                t.High= Convert.ToDecimal(r[12]);
                t.Low = Convert.ToDecimal(r[13]);
                t.PreClose= Convert.ToDecimal(r[14]);
                t.UpperLimitPrice = Convert.ToDecimal(r[15]);
                t.LowerLimitPrice = Convert.ToDecimal(r[16]);
               }

            return t;
        }
    }
}
