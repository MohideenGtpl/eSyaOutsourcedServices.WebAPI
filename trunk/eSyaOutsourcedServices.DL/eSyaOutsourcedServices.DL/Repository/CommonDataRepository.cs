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
   public class CommonDataRepository:ICommonDataRepository
    {
        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbsln
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            //LocationDescription = r.LocationDescription
                            LocationDescription = r.BusinessName
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
