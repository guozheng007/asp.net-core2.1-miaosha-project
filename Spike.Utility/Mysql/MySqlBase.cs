using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Spike.Utility.Mysql
{
    public class MySqlBase
    {
        /// <summary>
        /// 根据数据库名获取连接
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        protected IDbConnection GetConnection(string connStr)
        {
            IDbConnection connection = new MySqlConnection(connStr);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <returns></returns>
        protected T ExecuteScalar<T>(string connStr, string sql, object param = null)
        {
            using (IDbConnection connection = GetConnection(connStr))
            {
                return connection.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        ///     Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected int Execute(string connStr, string sql, object param = null)
        {
            using (IDbConnection connection = GetConnection(connStr))
            {
                return connection.Execute(sql, param);
            }
        }

        /// <summary>
        ///  QueryList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected IList<T> QueryList<T>(string connStr, string sql, object param = null)
        {
            using (IDbConnection connection = GetConnection(connStr))
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        ///  Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connStr"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected T Query<T>(string connStr, string sql, object param = null)
        {
            using (IDbConnection connection = GetConnection(connStr))
            {
                return connection.Query<T>(sql, param).SingleOrDefault();
            }
        }

        #region GetPage

        public List<T> GetPage<T>(string connStr, SqlPageInfo sqlPageInfo, out int recordCount, IDictionary<string, object> parameters) where T : class, new()
        {
            if (sqlPageInfo.PageIndex <= 0 || sqlPageInfo.PageSize <= 0 || string.IsNullOrWhiteSpace(sqlPageInfo.TableName))
            {
                recordCount = 0;
                return null;
            }

            string sql = string.Format("SELECT COUNT(*) FROM {0}", sqlPageInfo.TableName);
            if (!string.IsNullOrWhiteSpace(sqlPageInfo.SqlWhere))
                sql = string.Format("{0} WHERE {1}", sql, sqlPageInfo.SqlWhere);

            using (IDbConnection connection = GetConnection(connStr))
            {
                recordCount = connection.Query<int>(sql, GetDynamicParameters(parameters)).SingleOrDefault();
            }

            if (recordCount == 0)
                return null;

            sql = string.Format("SELECT {0} FROM {1}", sqlPageInfo.Fields, sqlPageInfo.TableName);
            if (!string.IsNullOrWhiteSpace(sqlPageInfo.SqlWhere))
                sql = string.Format("{0} WHERE {1}", sql, sqlPageInfo.SqlWhere);

            if (!string.IsNullOrWhiteSpace(sqlPageInfo.OrderField))
                sql = string.Format("{0} ORDER BY {1}", sql, sqlPageInfo.OrderField);

            int pageIndex = sqlPageInfo.PageIndex;
            int pageSize = sqlPageInfo.PageSize;
            int begIndex = (pageIndex - 1) * pageSize;
            if (begIndex < 0)
            {
                begIndex = 0;
            }

            sql = string.Format("{0} LIMIT {1},{2}", sql, begIndex, pageSize);

            using (IDbConnection connection = GetConnection(connStr))
            {
                return connection.Query<T>(sql, GetDynamicParameters(parameters)).ToList();
            }
        }

        #endregion

        /// <summary>
        /// 获取动态参数信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DynamicParameters GetDynamicParameters(IDictionary<string, object> parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            if (parameters is null)
            {
                return null;
            }

            foreach (var item in parameters)
            {
                dynamicParameters.Add(item.Key, item.Value);
            }

            return dynamicParameters;
        }
    }
}
