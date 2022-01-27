using AutoMapper;
using SVR.Core.Models;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.Mappers
{
    class CommonMapper: Profile
    {
        public CommonMapper()
        {
            //CreateMap<Bill, BillDto>();
            ////.ForMember(x => x.TotalTypes, opt => opt.MapFrom(d => d.DocumentTypes.Count(x => x.Active)));
            //CreateMap<BillUpdateModel, Bill>().ReverseMap();
            ////.ForMember(x => x.DocumentCategory, opt => opt.Ignore()).ReverseMap();
        }
    }
}
