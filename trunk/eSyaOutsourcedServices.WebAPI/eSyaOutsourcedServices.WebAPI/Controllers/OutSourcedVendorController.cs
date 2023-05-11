using eSyaOutsourcedServices.DL.Repository;
using eSyaOutsourcedServices.DO;
using eSyaOutsourcedServices.IF;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace eSyaOutsourcedServices.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OutSourcedVendorController : ControllerBase
    {
        #region Service Out Sourced
        private readonly IOutSourcedVendorRepository _outSourcedVendorRepository;
        private readonly ICommonDataRepository _CommonDataRepository;
        public OutSourcedVendorController(IOutSourcedVendorRepository outSourcedVendorRepository, ICommonDataRepository CommonDataRepository)
        {
            _outSourcedVendorRepository = outSourcedVendorRepository;
            _CommonDataRepository = CommonDataRepository;
        }
        /// <summary>
        /// Getting  Business Locations.
        /// UI Reffered -Vendor Business Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBusinessKey()
        {
            var bkeys = await _CommonDataRepository.GetBusinessKey();
            return Ok(bkeys);
        }
        /// <summary>
        /// Getting  Service Group.
        /// UI Reffered -OutSourced Service dropdown
        /// params-Vendorcode
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServiceGroup()
        {
            var sr_group = await _outSourcedVendorRepository.GetServiceGroup();
            return Ok(sr_group);
        }

        /// <summary>
        /// Getting  Service Class.
        /// UI Reffered -OutSourced Service dropdown
        /// params-GroupId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServiceClassbyGroupId(int GroupId)
        {
            var sr_class = await _outSourcedVendorRepository.GetServiceClassbyGroupId(GroupId);
            return Ok(sr_class);
        }

        /// <summary>
        /// Getting  Service.
        /// UI Reffered -OutSourced Service dropdown
        /// params-ClassId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServicebyClassId(int ClassId)
        {
            var srvices = await _outSourcedVendorRepository.GetServicebyClassId(ClassId);
            return Ok(srvices);
        }

        /// <summary>
        /// Getting  Out Sourced Service .
        /// UI Reffered -OutSourced Service Tree View
        /// params-ClassId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServicebyBusinessKeyforTreeView(int BusinessKey)
        {
            var outsourced = await _outSourcedVendorRepository.GetServicebyBusinessKeyforTreeView(BusinessKey);
            return Ok(outsourced);
        }

        /// <summary>
        /// Getting  Out Sourced Service Info .
        /// UI Reffered -OutSourced Service 
        /// params-BusinessKey & ServiceId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetOutSourcedServiceInfo(int BusinessKey,int ServiceId)
        {
            var outsourced = await _outSourcedVendorRepository.GetOutSourcedServiceInfo(BusinessKey, ServiceId);
            return Ok(outsourced);
        }
        /// <summary>
        /// Insert Or Update Out Sourced Service.
        /// UI Reffered -OutSourced Service 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateOutSourcedService(DO_OutSourcedService obj)
        {
            var msg = await _outSourcedVendorRepository.InsertOrUpdateOutSourcedService(obj);
            return Ok(msg);

        }
        #endregion Service Out Sourced
    }
}
