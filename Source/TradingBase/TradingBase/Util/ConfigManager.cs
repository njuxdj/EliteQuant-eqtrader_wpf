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
using System.IO;
using System.Diagnostics;
using YamlDotNet.RepresentationModel;

namespace TradingBase
{
    [Serializable()]
    public class ConfigManager : IConfigManager
    {
        public ConfigManager()
        {
            // To re-generate config.xml
            SettingPath = @"\Config\";
            TickPath = @"\TickData\";
            HistPath = @"\HistData\";
            LogPath = @"\Log\";
            StrategyPath = @"\Strategies\";
            RWorkspacePath = @"Strategies\R";

            DefaultBroker = "GOOG";
            DefaultAccount = "U00000";
            MyAccount = "DU15053";
            Host = "127.0.0.1";
            Port = 7496;
            User = "edemo";
            Password = "demouser";
            GoogleRefreshInMilliseconds = 1;

            GmailFrom = "youremailaccount@gmail.com";
            GmailPass = "yourpass";
            EmailTo = "123@gmail.com;abc@yahoo.com";

            RunVersion = "Debug";
            DllName = "ClassicStrategies.dll";

            TickQueueCapacity = 50000;
            TickSampleTime = 10;
            DailyOrderCapacity = 500;
            EnableOversellProtect = true;
            OversellSplitInsteadofRoundDown = true;
            SaveIndicator = true;
            DisableStrategyOnException = true;
            RealTimePlot = true;
            PlotRegularTradingHours = false;

            // Backtest additional settings
            DecimalPlace = 2;
            UseBidAskFill = false;
            AdjustIncomingTick = false;
            ShowTicks = true;

            DailyBucket = @"\Config\DailyBasket20140923.csv";
            DailyPairs = @"\Config\DailyPairs20140923.csv";
            DailyResultPath = @"\HistData\Daily\";

            Strategies = new List<string>();

            Holidays = new List<string>();
        }

      
        
        /// <summary>
        /// Config file path
        /// </summary>
        public string SettingPath { get; set; }
        /// <summary>
        /// Tick file path
        /// </summary>
        public string TickPath { get; set; }
        /// <summary>
        /// historical bar file file
        /// </summary>
        public string HistPath { get; set; }
        /// <summary>
        /// log file path
        /// </summary>
        public string LogPath { get; set; }
        /// <summary>
        /// strategy dll path
        /// </summary>
        public string StrategyPath { get; set; }
        public string RWorkspacePath { get; set; }
        public string DefaultBroker { get; set; }
        /// <summary>
        /// default account (not currently used)
        /// </summary>
        public string DefaultAccount { get; set; }
        public string MyAccount { get; set; }
        /// <summary>
        /// IB Api IP address
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        ///  IB Api Port
        /// </summary>
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int GoogleRefreshInMilliseconds { get; set; }
        public string GmailFrom { get; set; }
        public string GmailPass { get; set; }
        public string EmailTo { get; set; }
        public string RunVersion { get; set; }
        public string DllName { get; set; }
        public int TickQueueCapacity { get; set; }
        public int TickSampleTime { get; set; }
        public int DailyOrderCapacity { get; set; }
        public bool EnableOversellProtect { get; set; }
        public bool OversellSplitInsteadofRoundDown { get; set; }
        public bool SaveIndicator { get; set; }
        public bool DisableStrategyOnException { get; set; }
        public bool RealTimePlot { get; set; }
        public bool PlotRegularTradingHours { get; set; }
        
        //************************ Backtest additional setting ******************************//
        public int DecimalPlace { get; set; }
        public bool UseBidAskFill { get; set; }
        public bool AdjustIncomingTick { get; set; }
        public bool ShowTicks { get; set; }

        //************************ DailyPreMarket additional setting ******************************//
        public string DailyBucket { get; set; }
        public string DailyPairs { get; set; }
        public string DailyResultPath { get; set; }


        //*************************************** Other ***************************************//
        public List<string> Strategies { get; set; }
        public List<string> Holidays { get; set; }
        public YamlMappingNode ConfigClient;
        public YamlMappingNode ConfigServer;
        public string Account;
        public List<string> Securities;
        public String BrokerName;
        public string Api;
        public String BaseCurrency;
        public static ConfigManager Deserialize()
        {
            ConfigManager configmanager = new ConfigManager();
            Debug.WriteLine(Path.Combine(System.Environment.CurrentDirectory, "config_client.yaml"));
            using (FileStream fs = new FileStream(Path.Combine(System.Environment.CurrentDirectory, "config_client.yaml"), FileMode.Open))
            {
                int fsLen = (int)fs.Length;
                byte[] buffer = new byte[fsLen];
                int r = fs.Read(buffer, 0, fsLen);
                string yamlStr = System.Text.Encoding.UTF8.GetString(buffer);
               
                // Setup the input
                var input = new StringReader(yamlStr);

                // Load the stream
                var yaml = new YamlStream();
                yaml.Load(input);

                // Examine the stream
                configmanager.ConfigClient = (YamlMappingNode)yaml.Documents[0].RootNode;
            }
            
            using (FileStream fs = new FileStream(Path.Combine(System.Environment.CurrentDirectory, "config_server.yaml"), FileMode.Open))
            {
                int fsLen = (int)fs.Length;
                byte[] buffer = new byte[fsLen];
                int r = fs.Read(buffer, 0, fsLen);
                string yamlStr = System.Text.Encoding.UTF8.GetString(buffer);

                // Setup the input
                var input = new StringReader(yamlStr);

                // Load the stream
                var yaml = new YamlStream();
                yaml.Load(input);

                // Examine the stream
                configmanager.ConfigServer = (YamlMappingNode)yaml.Documents[0].RootNode;
                configmanager.Account=configmanager.ConfigServer["accounts"][0].ToString();
                configmanager.Api = configmanager.ConfigServer[configmanager.Account]["api"].ToString();
                configmanager.Port = Convert.ToInt32(configmanager.ConfigServer[configmanager.Account]["port"].ToString());
                configmanager.BrokerName= configmanager.ConfigServer[configmanager.Account]["broker"].ToString();
                configmanager.BaseCurrency = configmanager.ConfigServer[configmanager.Account]["base_currency"].ToString();
                configmanager.Securities = new List<string>();
                int i = 0; //allnode, starting on the currentnode.
                foreach ( var node in configmanager.ConfigServer[configmanager.Account]["tickers"].AllNodes)
                {
                    if (i++ == 0)
                        continue;
                    configmanager.Securities.Add(node.ToString());
                    
                }
            }


            return configmanager;
                /*
            config_server_ = config;            // save in memory
            
            const std::vector<string> accounts = config["accounts"].as< std::vector<string> > ();
            for (auto s : accounts)
            {
                const string api = config[s]["api"].as< std::string> ();

                securities.clear();
                const std::vector<string> tickers = config[s]["tickers"].as< std::vector<string> > ();
                for (auto s : tickers)
                {
                    securities.push_back(s.c_str());
                }
            }
            */
        
        }
    }
}