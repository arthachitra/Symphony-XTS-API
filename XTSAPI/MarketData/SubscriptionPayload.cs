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

namespace XTSAPI.MarketData
{
    [DataContract]
    public class SubscriptionPayload : Payload
    {
       
        /// <summary>
        /// Gets or sets the instruments
        /// </summary>
        [DataMember(Name = "instruments")]
        public List<Instruments> instruments { get; set; }

        /// <summary>
        /// Gets or sets the message code
        /// </summary>
        [DataMember(Name = "xtsMessageCode")]
        public int xtsMessageCode { get; set; }

    }

        
}
