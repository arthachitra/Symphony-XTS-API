﻿/*
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
    FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XTSAPI.MarketData
{
    [DataContract]
    public class SearchByStringResult : SearchBase
    {
        public SearchByStringResult()
        {
            this.PriceBand = new PriceBand();
        }

        /// <summary>
        /// Gets or sets the underlying instrument id
        /// </summary>
        [DataMember(Name = "UnderlyingInstrumentId")]
        public long UnderlyingInstrumentId { get; set; }

        /// <summary>
        /// Gets or sets the underlying index name
        /// </summary>
        [DataMember(Name = "UnderlyingIndexName")]
        public string UnderlyingIndexName { get; set; }

        /// <summary>
        /// Gets or sets the contract expiration
        /// </summary>
        [DataMember(Name = "ContractExpiration")]
        public DateTime ContractExpiration { get; set; }

        /// <summary>
        /// Gets or sets the contrct expiration string
        /// </summary>
        [DataMember(Name = "ContractExpirationString")]
        public string ContractExpirationString { get; set; }

        /// <summary>
        /// Gets or sets the remaining expiry days
        /// </summary>
        [DataMember(Name = "RemainingExpiryDays")]
        public int RemainingExpiryDays { get; set; }

        /// <summary>
        /// Gets or sets the strike price
        /// </summary>
        [DataMember(Name = "StrikePrice")]
        public double StrikePrice { get; set; }

        /// <summary>
        /// Gets or sets the option type
        /// </summary>
        [DataMember(Name = "OptionType")]
        public int OptionType { get; set; }




        public bool Parse(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            string[] array = line.Split('|');

            int len = array.Length;

            if (len < 13)
                return false;

            //1|2885|8|RELIANCE|RELIANCE-EQ|EQ|RELIANCE-EQ|1100100002885|1403.5|1148.4|76062|0.05|1
            //2|96225|2|RELIANCE|RELIANCE19OCT960CE|OPTSTK|RELIANCE-OPTSTK|2930400096225|488.9|185.2|35001|0.05|500|1100100002885||2019-10-31T14:30:00|960|3
            //2|44698|1|RELIANCE|RELIANCE19SEPFUT|FUTSTK|RELIANCE-FUTSTK|2926900044698|1412.4|1155.6|35001|0.05|500|1100100002885||2019-09-26T14:30:00|undefined|undefined
            //2|44461|1|NIFTY|NIFTY19SEPFUT|FUTIDX|NIFTY-FUTIDX|2926900044461|12180.65|9966|7501|0.05|75|-1|Nifty 50|2019-09-26T14:30:00|undefined|undefined
            //2|57949|2|NIFTY|NIFTY19SEP11000CE|OPTIDX|NIFTY-OPTIDX|2926900057949|522.7|0.05|7501|0.05|75|-1|Nifty 50|2019-09-26T14:30:00|11000|3
            //3|3511|2|GBPUSD|GBPUSD19SEP1.2PE|OPTCUR|GBPUSD-OPTCUR|3926900003511|0.0104|0.0036|10001|0.0001|1|-1||2019-09-26T14:30:00|1.2|4
            //NSECD|1553|2|EURUSD|EURUSD19SEP1.085CE|OPTCUR|EURUSD-OPTCUR|3926900001553|0.0346|0.0208|10001|0.0001|1|-1||2019-09-26T14:30:00|1.085|3

            //EXCHANGE|EXCHANGE_INSTRUMENT_ID|INSTRUMENT_TYPE|NAME|DESCRIPTION|SERIES|NAME_WITH_SERIES|INSTRUMENT_ID|UPPER_CIRCUIT|LOWER_CIRCUIT|FREEZE_QTY|TICK_SIZE|LOT_SIZE|UNDERLYING_INSTRUMENT_ID|UNDERLYING_INDEX_NAME|EXPIRY_DATE|STRIKE_PRICE|OPTION_TYPE

            /*
            {"ExchangeSegment":2,"ExchangeInstrumentID":44698,"InstrumentType":1,"Name":"RELIANCE","DisplayName":"RELIANCE 26SEP2019","Description":"RELIANCE19SEPFUT","Series":"FUTSTK","NameWithSeries":"RELIANCE-FUTSTK","InstrumentID":2926900044698,"PriceBand":{"High":1253.25,"Low":1025.4},"FreezeQty":35001,"TickSize":0.05,"LotSize":500,"UnderlyingInstrumentId":1100100002885,"UnderlyingIndexName":"","ContractExpiration":"2019-09-26T14:30:00","ContractExpirationString":"26Sep2019","RemainingExpiryDays":51}
            */

            //{ "ExchangeSegment":1,"ExchangeInstrumentID":14346,"InstrumentType":8,"Name":"ORIENTALTL","DisplayName":"ORIENTALTL",
            //"Description":"ORIENTAL TRIMEX LTD","Series":"EQ","NameWithSeries":"ORIENTALTL-EQ","InstrumentID":1100100014346,
            //"PriceBand":{ "High":15.6,"Low":10.4},"FreezeQty":932447,"TickSize":0.05,"LotSize":1},

            if (!int.TryParse(array[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int exchangeSegment))
            {
                exchangeSegment = Globals.GetExchangeFromString(array[0]);
                if (exchangeSegment == -1)
                    return false;
            }

            this.ExchangeSegment = exchangeSegment;

            if (!long.TryParse(array[1], NumberStyles.Any, CultureInfo.InvariantCulture, out long exchangeInstrumnetId))
                return false;

            this.ExchangeInstrumentID = exchangeInstrumnetId;

            if (!int.TryParse(array[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int instrumentType))
                return false;

            this.InstrumentType = instrumentType;

            this.Name = array[3];
            this.Description = array[4];
            this.Series = array[5];
            this.NameWithSeries = array[6];

            if (!long.TryParse(array[7], NumberStyles.Any, CultureInfo.InvariantCulture, out long instrumentId))
                return false;

            this.InstrumentID = instrumentId;

            if (this.PriceBand != null)
            {
                double.TryParse(array[8], NumberStyles.Any, CultureInfo.InvariantCulture, out double high);
                this.PriceBand.High = high;

                double.TryParse(array[9], NumberStyles.Any, CultureInfo.InvariantCulture, out double low);
                this.PriceBand.Low = low;
            }

            double.TryParse(array[10], NumberStyles.Any, CultureInfo.InvariantCulture, out double freezeQty);
            this.FreezeQty = freezeQty;

            if (!double.TryParse(array[11], NumberStyles.Any, CultureInfo.InvariantCulture, out double tickSize))
                return false;

            this.TickSize = tickSize;

            if (!int.TryParse(array[12], NumberStyles.Integer, CultureInfo.InvariantCulture, out int lotSize))
                return false;

            this.LotSize = lotSize;

            if (len < 14)
                return true;

            if (len < 16)
                return false;

            //|UNDERLYING_INSTRUMENT_ID|UNDERLYING_INDEX_NAME|EXPIRY_DATE|STRIKE_PRICE|OPTION_TYPE

            long.TryParse(array[13], NumberStyles.Any, CultureInfo.InvariantCulture, out long underlyingInstrumentId);
            this.UnderlyingInstrumentId = underlyingInstrumentId;

            this.UnderlyingIndexName = array[14];

            DateTime.TryParse(array[15], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate);
            this.ContractExpiration = expiryDate;

            if (len < 17)
                return true;

            if (len < 18)
                return false;

            double.TryParse(array[16], NumberStyles.Any, CultureInfo.InvariantCulture, out double strikePrice);
            this.StrikePrice = strikePrice;

            int.TryParse(array[17], NumberStyles.Integer, CultureInfo.InvariantCulture, out int optionType);
            this.OptionType = optionType;


            return true;

        }
    }
}
