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

namespace XTSAPI
{
    [DataContract]
    public abstract class LoginResultBase
    {
        /// <summary>
        /// Gets or sets the token
        /// </summary>
        [DataMember(Name = "token")]
        public string token { get; set; }

        /// <summary>
        /// Gets or sets the userId
        /// </summary>
        [DataMember(Name = "userID")]
        public string userID { get; set; }

        /// <summary>
        /// Gets or sets the app version
        /// </summary>
        [DataMember(Name = "appVersion")]
        public string appVersion { get; set; }
    }
}
