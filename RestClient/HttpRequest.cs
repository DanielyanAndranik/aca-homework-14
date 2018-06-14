using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class HttpRequest
    {
        /// <summary>
        /// Base address for request.
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Accept type of request.
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// Add url parameters to the address.
        /// </summary>
        /// <param name="parameters">Dictionary object.</param>
        public void AddParameters(Dictionary<string, string> parameters)
        {
            if(parameters == null )
            {
                return;
            }

            if(parameters.Count > 0)
            {
                var builder = new StringBuilder(this.BaseAddress);
                builder.Append("?");

                foreach(var parameter in parameters)
                {
                    builder.AppendFormat("{0}={1}&", parameter.Key, parameter.Value);
                }

                builder.Remove(builder.Length - 1, 1);

                this.BaseAddress = builder.ToString();
            }
        }
    }
}
