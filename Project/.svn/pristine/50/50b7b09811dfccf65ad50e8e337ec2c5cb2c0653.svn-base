using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib.Logic
{
    public interface IEntity
    {
        public EntityChangeType Change { get; set; }
        public event PropertyChangedEventHandler OnPropertyChange;
        public int PrimaryKeyValue { get; }
    }
}
