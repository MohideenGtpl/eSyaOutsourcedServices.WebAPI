using eSyaOutsourcedServices.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutsourcedServices.IF
{
   public interface IOutSourcedVendorRepository
    {
        Task<List<DO_OutSourcedCommonData>> GetServiceGroup();

        Task<List<DO_OutSourcedCommonData>> GetServiceClassbyGroupId(int GroupId);

        Task<List<DO_OutSourcedCommonData>> GetServicebyClassId(int ClassId);

        Task<List<DO_OutSourcedService>> GetServicebyBusinessKeyforTreeView(int BusinessKey);

        Task<DO_OutSourcedService> GetOutSourcedServiceInfo(int BusinessKey, int ServiceId);

        Task<DO_ReturnParameter> InsertOrUpdateOutSourcedService(DO_OutSourcedService obj);
    }
}
