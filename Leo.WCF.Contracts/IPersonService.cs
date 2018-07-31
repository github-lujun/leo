using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Leo.WCF.Contracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        string GetName(int id);
        [OperationContract]
        int GetAge(int id);
    }
}
