﻿/****************************** Project Header ******************************\
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
using System.ComponentModel;
using System.Threading.Tasks;

namespace TradingBase
{
    public enum CurrencyType
    {
        [Description("USD")]
        USD,
        [Description("AUD")]
        AUD,
        [Description("CAD")]
        CAD,
        [Description("CHF")]
        CHF,
        [Description("EUR")]
        EUR,
        [Description("GBP")]
        GBP,
        [Description("HKD")]
        HKD,
        [Description("JPY")]
        JPY,
        [Description("MXN")]
        MXN,
        [Description("NZD")]
        NZD,
        [Description("SEK")]
        SEK,
    }
}
