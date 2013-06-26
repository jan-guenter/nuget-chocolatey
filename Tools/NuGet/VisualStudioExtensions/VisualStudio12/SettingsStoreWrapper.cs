﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Settings;
using NuGet.VisualStudio.Types;

namespace NuGet.VisualStudio12
{
    internal class SettingsStoreWrapper : ISettingsStore
    {
        private readonly SettingsStore _store;

        public SettingsStoreWrapper(SettingsStore store)
        {
            _store = store;
        }

        public bool CollectionExists(string collection)
        {
            return _store.CollectionExists(collection);
        }

        public bool GetBoolean(string collection, string propertyName, bool defaultValue)
        {
            return _store.GetBoolean(collection, propertyName, defaultValue);
        }

        public int GetInt32(string collection, string propertyName, int defaultValue)
        {
            return _store.GetInt32(collection, propertyName, defaultValue);
        }

        public string GetString(string collection, string propertyName, string defaultValue)
        {
            return _store.GetString(collection, propertyName, defaultValue);
        }
    }
}
