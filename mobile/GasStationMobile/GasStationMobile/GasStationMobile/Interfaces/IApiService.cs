using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.Interfaces
{
    public interface IApiService
    {
        Query Get(string endpoint);
        Query Post<D>(string endpoint, D model);
        Query Post(string endpoint);
        Query Put<D>(string endpoint, D model);
        Query Delete<D>(string endpoint, D model);
    }
}
