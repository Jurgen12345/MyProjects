using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Invoices.Common
{
    public  class CSettings
    {

        private static CSettings? __instance = null;
        public static CSettings Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                {
                    __instance = new CSettings();
                    __instance.Load();
                }
                return __instance;
            }
        }
        // ....................................................................


        // ........................................................................
        // If the application is using the new Material UX
        public bool IsNewUX { get; set; }
        // ........................................................................
        public string DBType { get; set; }
        // ........................................................................
        // Name of the LocalDB instance
        public string DBInstanceName { get; set; }
        // ........................................................................
        // Name of the database file without its extension
        public string DatabaseName { get; set; }
        // ........................................................................
        private string __settingsFileName;

        // The folllowing is a C# attribute. When you use this attribute this property
        // will be excluded (ignored) from JSON serialization/deserialization
        [JsonIgnore]
        public string FileName { get { return __settingsFileName; } }
        // ........................................................................





        // --------------------------------------------------------------------------------------
        // [C#] When we deserialize an object from JSON the constructor is public
        //    (unsafe for Singleton, but we cannot have it all sometimes)
        public CSettings()
        {
            // [C#] Joining paths using the platform's  path separator
            this.__settingsFileName = Path.Join(CAppPaths.Instance.SettingsPath, "settings.json");

            // Assign the default values for the settings (read the next method to understand null)
            Assign(null);
        }
        // ------------------------------------------------------------------------------------------------
        public void Assign(CSettings? p_oSettings)
        {
            // [C#] Use the null-coalescing operator ??, to a default value at the right side,
            // when the object/property at the right side is null

            // [C#] The null conditional operator ?, ensures that the code will not stop with an exception,
            // when a nullable field/property/local variable contains null

            this.IsNewUX = p_oSettings?.IsNewUX ?? false;
            this.DBType = p_oSettings?.DBType ?? "MSSQL";
            this.DBInstanceName = p_oSettings?.DBInstanceName ?? "MyInstance";
            this.DatabaseName = p_oSettings?.DatabaseName ?? "ERP";
        }
        // ------------------------------------------------------------------------------------------------
        public CSettings? LoadJSON()
        {
            CSettings? oResult = null;

            if (File.Exists(FileName))
            {
                Debug.WriteLine($"Loading settings from JSON file {this.FileName}.");

                // This is an example of deserializing a C# object from a JSON String
                string sJSON = File.ReadAllText(this.FileName);
                oResult = (CSettings?)JsonSerializer.Deserialize(sJSON, GetType());
            }
            else
                Debug.WriteLine($"Settings file {this.FileName} is not found.");

            return oResult;
        }
        // ------------------------------------------------------------------------------------------------
        public void SaveJSON(object p_oSourceObject)
        {
            // This is an example of serializing an object into a JSON string
            JsonSerializerOptions oOptions = new JsonSerializerOptions();
            oOptions.WriteIndented = true;

            string sJSON = JsonSerializer.Serialize(p_oSourceObject, oOptions);
            File.WriteAllText(this.FileName, sJSON);
        }
        // --------------------------------------------------------------------------------------
        public void Save()
        {
            this.SaveJSON(this);
        }
        // --------------------------------------------------------------------------------------
        public void Load()
        {
            if (!File.Exists(FileName))
            {
                // Lazy initialization of settings:
                // If the settings file does not exist, the first run will create the settings file.
                SaveJSON(this);
            }
            else
            {
                // If the file is successfully loaded, it will assign the values of loaded settings
                CSettings? oLoadedSettings = LoadJSON();
                if (oLoadedSettings != null)
                    Assign(oLoadedSettings);
            }
        }


    }
}
