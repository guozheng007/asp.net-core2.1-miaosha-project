using Spike.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.DataContracts
{
    public interface IMySqlCMDRepository
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        long Create(OrderModel entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(OrderModel entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(long id);
    }
}
