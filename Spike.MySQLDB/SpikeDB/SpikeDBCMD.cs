using System;
using System.Collections.Generic;
using System.Text;
using Spike.BO;
using Spike.DataContracts;
using Spike.Utility.Mysql;

namespace Spike.MySQLDB.SpikeDB
{
    public class SpikeDBCMD : MySqlBase, IMySqlCMDRepository
    {
        public long Create(OrderModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            string sql = $"DELETE FROM Test WHERE `Id`=@Id";
            object sqlParams = new { Id = id };
            return Execute(ConnectionString.TripOrderDB_INSERT, sql, sqlParams) > 0;
        }

        public bool Update(OrderModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
