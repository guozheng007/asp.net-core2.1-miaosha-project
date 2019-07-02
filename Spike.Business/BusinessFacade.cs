using Spike.DataContracts;

namespace Spike.Business
{
    public class BusinessFacade
    {
        private readonly ISpikeDBCMDRepository _spikeDBCMDRepository;

        public BusinessFacade(ISpikeDBCMDRepository spikeDBCMDRepository)
        {
            _spikeDBCMDRepository = spikeDBCMDRepository;
        }


    }
}
