using CsGoSkinsPreview.Remote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote.Interfaces
{
    public interface IApiCaller
    {
        Task<SkinsRealRoot> GetAllItems();
        Task<Price> GetItemPrice(string itemID);
        Task<InventoryValue> GetInventoryValue(string inventoryID);
    }
}
