﻿using CsGoSkinsPreview.Remote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Models
{
    public class SearchCommandArguments
    {
        public ObservableCollection<Skin> AllSkins { get; set; }
        public string PriceFrom { get; set; }
        public string PriceTo { get; set; }
        public string WeaponType { get; set; }
    }
}
