using Lib.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Interfaces
{
    public interface IDataModule: IDataModuleSimple
    {
        public int MasterKeyValue { get; set; }
        public void ModuleOnAnyEntityChange(object? sender, PropertyChangedEventArgs e);
        public bool ModuleLoadBrowser();
        public bool ModuleLoadLookups();
        public bool ModuleNew();
        public bool ModuleDelete();
    }
}
