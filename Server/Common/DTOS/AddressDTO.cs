using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOS
{
    public class AddressDTO
    {
        public string IpAddress { get; set; }
        public int Port { get;set; }

        public AddressDTO(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
