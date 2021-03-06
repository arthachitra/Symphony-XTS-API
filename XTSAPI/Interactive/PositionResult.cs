﻿/*
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
    FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XTSAPI.Interactive
{
    
    /*
    {"AccountID":"JOYDEEP",
    "TradingSymbol":"HINDUNILVR",
    "Exchange":"NSECM",
    "ExchangeInstrumentId":"1394",
    "ProductType":"CNC",
    "Marketlot":"1",
    "Multiplier":"1",
    "BuyAveragePrice":"1,870.00",
    "SellAveragePrice":"0.00",
    "OpenBuyQuantity":"1",
    "OpenSellQuantity":"0",
    "Quantity":"1",
    "BuyAmount":"1,870.00",
    "SellAmount":"0.00",
    "NetAmount":"-1,870.00",
    "UnrealizedMTM":"-14.95",
    "RealizedMTM":"0.00",
    "MTM":"-14.95",
    "BEP":"1,870.00",
    "SumOfTradedQuantityAndPriceBuy":"1,870.00",
    "SumOfTradedQuantityAndPriceSell":"0.00",

    "MessageCode":9002,
    "MessageVersion":1,
    "TokenID":0,
    "ApplicationType":0,
    "SequenceNumber":34775891}
    */
    [DataContract]
    public class PositionResult : ResultBase
    {
        /// <summary>
        /// Gets or sets the account id
        /// </summary>
        [DataMember(Name = "AccountID")]
        public string AccountID { get; set; }

        /// <summary>
        /// Gets or sets the trading symbol
        /// </summary>
        [DataMember(Name = "TradingSymbol")]
        public string TradingSymbol { get; set; }

        /// <summary>
        /// Gets or sets the exchange
        /// </summary>
        [DataMember(Name = "ExchangeSegment")]
        public string ExchangeSegment { get; set; }

        /// <summary>
        /// Gets or sets the exchange instrument id
        /// </summary>
        [DataMember(Name = "ExchangeInstrumentID")]
        public string ExchangeInstrumentID { get; set; }

        /*
        /// <summary>
        /// Gets or sets the login id
        /// </summary>
        [DataMember(Name = "LoginID")]
        public string LoginID { get; set; }

        
        /// <summary>
        /// Gets or sets the client id
        /// </summary>
        [DataMember(Name = "ClientID")]
        public string ClientID { get; set; }
        */

        /// <summary>
        /// Gets or sets the product type
        /// <see cref="XTSAPI.ProductType"/>
        /// </summary>
        [DataMember(Name = "ProductType")]
        public string ProductType { get; set; }



        /// <summary>
        /// Gets or sets the martet lot
        /// </summary>
        [DataMember(Name = "Marketlot")]
        public string Marketlot { get; set; }

        /// <summary>
        /// Gets or sets the multiplier
        /// </summary>
        [DataMember(Name = "Multiplier")]
        public string Multiplier { get; set; }

        /*
        /// <summary>
        /// Gets or sets the long position
        /// </summary>
        [DataMember(Name = "LongPosition")]
        public int LongPosition { get; set; }

        /// <summary>
        /// Gets or sets the short position
        /// </summary>
        [DataMember(Name = "ShortPosition")]
        public int ShortPosition { get; set; }

        /// <summary>
        /// Gets or sets the net position
        /// </summary>
        [DataMember(Name = "NetPosition")]
        public int NetPosition { get; set; }
        */

        /// <summary>
        /// Gets or sets the buy average price
        /// </summary>
        [DataMember(Name = "BuyAveragePrice")]
        public string BuyAveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the sell average price
        /// </summary>
        [DataMember(Name = "SellAveragePrice")]
        public string SellAveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the open buy quantity
        /// </summary>
        [DataMember(Name = "OpenBuyQuantity")]
        public string OpenBuyQuantity { get; set; }

        /// <summary>
        /// Gets or sets open sell quantity
        /// </summary>
        [DataMember(Name = "OpenSellQuantity")]
        public string OpenSellQuantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        [DataMember(Name = "Quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Gets or sets the buy amount
        /// </summary>
        [DataMember(Name = "BuyAmount")]
        public string BuyAmount { get; set; }

        /// <summary>
        /// Gets or sets the sell amount
        /// </summary>
        [DataMember(Name = "SellAmount")]
        public string SellAmount { get; set; }

        /// <summary>
        /// Gets or sets the net amount
        /// </summary>
        [DataMember(Name = "NetAmount")]
        public string NetAmount { get; set; }


        /*
        /// <summary>
        /// Gets or sets the buy value
        /// </summary>
        [DataMember(Name = "BuyValue")]
        public string BuyValue { get; set; }

        /// <summary>
        /// Gets or sets the sell value
        /// </summary>
        [DataMember(Name = "SellValue")]
        public string SellValue { get; set; }

        /// <summary>
        /// Gets or sets the net value
        /// </summary>
        [DataMember(Name = "NetValue")]
        public string NetValue { get; set; }
        */

        /// <summary>
        /// Gets or sets the unrealized mark to market (MTM)
        /// </summary>
        [DataMember(Name = "UnrealizedMTM")]
        public string UnrealizedMTM { get; set; }

        /// <summary>
        /// Gets or sets the realized mark to market (MTM)
        /// </summary>
        [DataMember(Name = "RealizedMTM")]
        public string RealizedMTM { get; set; }

        /// <summary>
        /// Gets or sets the mark to market (MTM)
        /// </summary>
        [DataMember(Name = "MTM")]
        public string MTM { get; set; }

        /// <summary>
        /// Gets or sets the breakeven point
        /// </summary>
        [DataMember(Name = "BEP")]
        public string BEP { get; set; }

        /// <summary>
        /// Gets or sets the sum of traded quantity and buy price
        /// </summary>
        [DataMember(Name = "SumOfTradedQuantityAndPriceBuy")]
        public string SumOfTradedQuantityAndPriceBuy { get; set; }

        /// <summary>
        /// Gets or sets the sum of traded qantity and sell price
        /// </summary>
        [DataMember(Name = "SumOfTradedQuantityAndPriceSell")]
        public string SumOfTradedQuantityAndPriceSell { get; set; }

        /// <summary>
        /// Gets or sets the unique key
        /// </summary>
        [DataMember(Name = "UniqueKey")]
        public string UniqueKey { get; set; }

        

        
    }
}
