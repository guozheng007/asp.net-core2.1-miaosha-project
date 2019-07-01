using System;
using System.Collections.Generic;
using System.Text;


using Spike.Utility;

namespace Spike.MySQLDB
{
    public class ConnectionString
    {
        public readonly static string TripOrderDBSelect = ConfigurationManager.Configuration["add:SpikeDB_SELECT:connectionString"];
        public readonly static string TripOrderDBInsert = ConfigurationManager.Configuration["add:SpikeDB_INSERT:connectionString"];

        /// <summary>
        /// TripOrderDB库读链接
        /// </summary>
        public static string TripOrderDB_SELECT
        {
            get
            {
                return Encryption.Decrypt(TripOrderDBSelect, AppSetting.EncryptKey);
            }
        }

        /// <summary>
        /// TripOrderDB库写链接
        /// </summary>
        public static string TripOrderDB_INSERT
        {
            get
            {
                return Encryption.Decrypt(TripOrderDBInsert, AppSetting.EncryptKey);
            }
        }
    }
}
