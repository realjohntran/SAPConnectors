using SapNwRfc;
using System;

namespace Proxies
{
    public class SAPNWRFC
    {
        public class Result
        {
            [SapName("RETURN")]
            public ReturnStructure ret { get; set; }

            [SapName("COMPANYCODE_LIST")]
            public COMPANYCODE_Structure[] codes { get; set; }
        }

        public class ReturnStructure
        {
            [SapName("TYPE")]
            public string type { get; set; }

            [SapName("MESSAGE")]
            public string message { get; set; }
        }

        public class COMPANYCODE_Structure
        {
            [SapName("COMP_CODE")]
            public string comp_code { get; set; }

            [SapName("COMP_NAME")]
            public string comp_name { get; set; }
        }

        public static Result execute(string hostName, string userName, string password, string client)
        {
            try
            {
                SapConnectionParameters parameters = new SapConnectionParameters
                {
                    AppServerHost = hostName,
                    User = userName,
                    Password = password,
                    Client = client
                };

                using (SapConnection connection = new SapConnection(parameters))
                {
                    connection.Connect();

                    using (ISapFunction function = connection.CreateFunction("BAPI_COMPANYCODE_GETLIST"))
                    {
                        return function.Invoke<Result>();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
