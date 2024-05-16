using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface ICashService
    {
        Task SetCashResponseAysnc(string Key, object Value, TimeSpan time);
        Task<string?> GetCashResponseAysnc(string Key);
    }
}
