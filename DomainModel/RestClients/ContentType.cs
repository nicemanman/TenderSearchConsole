using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients
{
    public sealed class ContentType
    {
        readonly string name;
        readonly DataFormat format;

        public string Name
        {
            get { return this.name; }
        }

        public DataFormat Format
        {
            get { return this.format; }
        }

        public static readonly ContentType JSON = new ContentType("application/json", DataFormat.Json);
        public static readonly ContentType XML = new ContentType("application/xml", DataFormat.Xml);

        private ContentType(string name, DataFormat format)
        {
            this.name = name;
            this.format = format;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
