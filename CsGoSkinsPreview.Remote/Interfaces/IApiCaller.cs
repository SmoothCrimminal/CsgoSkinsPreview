using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Interfaces
{
    public interface IApiCaller
    {
        Task<bool> GetAllItems();
        Task<bool> GetItemPrice();
        Task<bool> GetInventoryValue();
    }
}
