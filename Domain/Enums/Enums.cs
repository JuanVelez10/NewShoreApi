using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public class Enums
    {

        // To know the role of an person
        public enum RoleType
        {
            Admin = 1,
            Client = 2
        }

        // To know the payment of an bill
        public enum FlightType
        {
            Single_Route = 0,
            Multiple_Route = 1,
            Multiple_Route_Return = 2
        }

        //Types of api response messages
        public enum MessageType
        {
            None = 0,
            Success = 1,
            Error = 2
        }


    }
}
