using eSyaOutsourcedServices.DL.Entities;
using eSyaOutsourcedServices.DO;
using eSyaOutsourcedServices.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutsourcedServices.DL.Repository
{
   public class OutSourcedVendorRepository:IOutSourcedVendorRepository
    {
        #region Service Out Sourced
        public async Task<List<DO_OutSourcedCommonData>> GetServiceGroup()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var sr_gropu = db.GtEssrgr
                        .Where(w => w.ActiveStatus)
                        .Select(g => new DO_OutSourcedCommonData
                        {
                            GroupId =g.ServiceGroupId,
                            GroupDesc =g.ServiceGroupDesc
                        }).ToListAsync();

                    return await sr_gropu;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_OutSourcedCommonData>> GetServiceClassbyGroupId(int GroupId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var sr_class = db.GtEssrcl
                        .Where(w => w.ActiveStatus&&w.ServiceGroupId==GroupId)
                        .Select(c => new DO_OutSourcedCommonData
                        {
                            ClassId = c.ServiceClassId,
                            ClassDesc = c.ServiceClassDesc
                        }).ToListAsync();

                    return await sr_class;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_OutSourcedCommonData>> GetServicebyClassId(int ClassId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var sr = db.GtEssrms
                        .Where(w => w.ActiveStatus && w.ServiceClassId == ClassId)
                        .Select(s => new DO_OutSourcedCommonData
                        {
                            ServiceId = s.ServiceId,
                            ServiceDesc = s.ServiceDesc
                        }).ToListAsync();

                    return await sr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_OutSourcedService>> GetServicebyBusinessKeyforTreeView(int BusinessKey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var sr = db.GtEssros
                        .Where(w=>w.BusinessKey == BusinessKey)
                        .Join(db.GtEssrms,
                         x => x.ServiceId,
                         y => y.ServiceId,
                        (x, y) => new DO_OutSourcedService
                        {
                            BusinessKey=x.BusinessKey,
                            ServiceId=x.ServiceId,
                            ServiceName = x.ServiceId.ToString() + " - " + y.ServiceDesc,
                            OutsourcedStatus=x.OutsourcedStatus,
                            EffectiveFrom=x.EffectiveFrom,
                            EffectiveTill=x.EffectiveTill,
                            ActiveStatus = x.ActiveStatus
                        }).ToListAsync();

                    return await sr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_OutSourcedService> GetOutSourcedServiceInfo(int BusinessKey,int ServiceId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var sr = db.GtEssros
                        .Where(w => w.BusinessKey == BusinessKey && w.ServiceId==ServiceId)
                        .Join(db.GtEssrms,
                         x => x.ServiceId,
                         y => y.ServiceId,
                        (x, y) => new DO_OutSourcedService
                        {
                            BusinessKey = x.BusinessKey,
                            ServiceId = x.ServiceId,
                            ServiceName = y.ServiceDesc,
                            OutsourcedStatus = x.OutsourcedStatus,
                            EffectiveFrom = x.EffectiveFrom,
                            EffectiveTill = x.EffectiveTill,
                            ActiveStatus = x.ActiveStatus
                        }).FirstOrDefaultAsync();
                    return await sr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateOutSourcedService(DO_OutSourcedService obj)
        {
            bool result;

            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        bool is_serviceExist = db.GtEssros.Any(a => a.BusinessKey == obj.BusinessKey && a.ServiceId == obj.ServiceId);

                        if (is_serviceExist)
                        {
                            result = await UpdateOutSourcedService(obj);
                            if (result)
                            {
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Updated Successfully." };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = true, Message = "Updated Failed." };
                            }

                        }
                        else
                        {
                            result = await InsertOutSourcedService(obj);
                            if (result)
                            {
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Created Successfully." };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = true, Message = "Created Failed." };
                            }

                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<bool> InsertOutSourcedService(DO_OutSourcedService obj)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var out_sr = new GtEssros()
                    {
                        BusinessKey=obj.BusinessKey,
                        ServiceId=obj.ServiceId,
                        OutsourcedStatus=obj.OutsourcedStatus,
                        EffectiveFrom=obj.EffectiveFrom,
                        EffectiveTill=obj.EffectiveTill,
                        ActiveStatus = obj.ActiveStatus,
                        FormId = obj.FormId,
                        CreatedBy = obj.UserID,
                        CreatedOn = System.DateTime.Now,
                        CreatedTerminal = obj.TerminalID
                    };
                    db.GtEssros.Add(out_sr);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdateOutSourcedService(DO_OutSourcedService obj)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    GtEssros out_sr = db.GtEssros.Where(w => w.BusinessKey == obj.BusinessKey && w.ServiceId == obj.ServiceId).FirstOrDefault();
                    out_sr.OutsourcedStatus = obj.OutsourcedStatus;
                    out_sr.EffectiveFrom = obj.EffectiveFrom;
                    out_sr.EffectiveTill = obj.EffectiveTill;
                    out_sr.ActiveStatus = obj.ActiveStatus;
                    out_sr.ModifiedBy = obj.UserID;
                    out_sr.ModifiedOn = System.DateTime.Now;
                    out_sr.ModifiedTerminal = obj.TerminalID;
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Service Out Sourced
    }
}
