using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Attribs;
using Lib.Data.DB;

namespace Lib.Logic
{
    //[C#/.NET]:  This is an example of a generic class where T should be a descendand of CDBRecord
    //          Additionallywe can use the class provided for T
    //          to instantiate objects of T inside a method (dynamic instantiation)

    public class CEntity<T>: IEntity where T : CDBRecord, new()
    {
        // ....................................................................
        private T __record;

        [Browsable(false)]
        public T Record { get { return __record; } set { __record = value; } }
        // ....................................................................
        [Browsable(false)]
        public int PrimaryKeyValue { get { return GetPrimaryKeyValue() ?? -1; } }
        // ....................................................................
        // [C#] We declare an event member. This gives the ability to a client code to hook an event handler
        public event PropertyChangedEventHandler OnPropertyChange;
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public CEntity()
        {
            __record = new T();
        }
        // --------------------------------------------------------------------------------------
        protected void InvokePropertyChanged(string p_sPropertyName)
        {
            OnPropertyChange?.Invoke(this, new PropertyChangedEventArgs(p_sPropertyName));
        }
        // --------------------------------------------------------------------------------------
        // [C#/.NET] [ADVANCED]: This in an example of reflection. 
        protected int? GetPrimaryKeyValue()
        {
            int? nResult = null;

            string sResult = string.Empty;
            Type tObjectType = GetType();
            foreach (var oProperty in tObjectType.GetProperties())
            {
                var oKeyAttrib = oProperty.GetCustomAttribute<KeyAttribute>();
                if (oKeyAttrib != null)
                {
                    string sPrimaryKeyFieldName = oProperty.Name;
                    nResult = (int?)oProperty.GetValue(this);
                    break;
                }
            }
            return nResult;
        }
        // --------------------------------------------------------------------------------------

        #region // IEntity \\
        // ....................................................................
        [Browsable(false)]
        public EntityChangeType Change
        {
            get
            {
                if (__record.IsDeleted)
                    return EntityChangeType.DELETED;
                else if (__record.IsNew)
                    return EntityChangeType.CREATED;
                else if (__record.IsUpdated)
                    return EntityChangeType.UPDATED;
                else
                    return EntityChangeType.NONE;
            }
            set
            {
                switch (value)
                {
                    case EntityChangeType.CREATED:
                        {
                            int? nKeyValue = GetPrimaryKeyValue();
                            if (nKeyValue != null)
                                __record.IsNew = (nKeyValue == 0);
                            else
                                __record.IsNew = true;
                            break;
                        }
                    case EntityChangeType.UPDATED:
                        {
                            __record.IsUpdated = true;
                            break;
                        }
                    case EntityChangeType.DELETED:
                        {
                            __record.IsDeleted = true;
                            break;
                        }

                }
            }
        }
        // ....................................................................
        #endregion
    }
}
