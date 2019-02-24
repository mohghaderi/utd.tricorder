﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public interface IFWStringTextService
    {
        void AddItemToDatabase(i18nText item);
        ConcurrentDictionary<Guid, i18nText> GetAlli18nText();
    }
}
