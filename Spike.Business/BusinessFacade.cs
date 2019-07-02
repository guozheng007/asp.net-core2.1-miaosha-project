using Spike.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Business
{
    public class BusinessFacade
    {
        private readonly ISpikeDBCMDRepository _spikeDBCMDRepository;

        public BusinessFacade(ISpikeDBCMDRepository spikeDBCMDRepository)
        {
            this._spikeDBCMDRepository = spikeDBCMDRepository;
        }

         
    }
}
