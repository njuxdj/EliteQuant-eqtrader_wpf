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

using System.ComponentModel;

namespace TradingBase
{
    /// <summary>
    /// Incoming tick types; defined in EWrapper.h, used in tickPrice().
    /// http://www.interactivebrokers.com/php/apiUsersGuide/apiguide/api/tick_values.htm#XREF_tick_values_generic_tick
    /// </summary>
    public enum TickType : int
    {
        [Description("TRADE")]
        TRADE = 0,
        [Description("BID")]
        BID = 1,
        [Description("ASK")]
        ASK = 2,
        [Description("FULL")]
        FULL = 3
    }
}
