using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using NetLicensingClient;
using NetLicensingClient.Entities;

namespace License.Logic
{
    public class CCreateConnection
    {
        private string apiKey = "bf9ae19b-e5bd-4c21-abd9-826142d29ab0";
        private string baseUrl = @"https://go.netlicensing.io/core/v2/rest/";
        private string productNumber = "PRKXCEYAV";
        public bool isLicensed = false;
        public string userLicense { get; set; }
        public ValidationResult? validationResult;
        public bool isValid = false;
        public string checkingValidity { get; set; }

        public CCreateConnection(string s_userLicense)
        {
            userLicense = s_userLicense;

            try
            {
                ValidationParameters validationParameters = new ValidationParameters();
                validationParameters.setProductNumber("PRKXCEYAV");
                validationParameters.put("MC2QXNFNK", "Subsription", "Enabled");

                Context context = new Context();
                context.securityMode = SecurityMode.APIKEY_IDENTIFICATION;
                context.apiKey = apiKey;
                this.validationResult = LicenseeService.validate(context, userLicense, validationParameters);
                isValid = true;
                this.checkingValidity = this.validationResult.ToString().Split('{')[1].Split(',')[0].Split('=')[1];
                Debug.WriteLine(this.checkingValidity);
              

            }
            catch(NetLicensingClient.NetLicensingException)
            {
            }
            

            
        }

    

        

    }
}
