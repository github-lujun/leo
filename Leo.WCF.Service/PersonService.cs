using Leo.WCF.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leo.WCF.Service
{
    public class PersonService : IPersonService
    {
        public int GetAge(int id)
        {
            return 24;
        }

        public string GetName(int id)
        {
            return "lujun";
        }
    }
}
