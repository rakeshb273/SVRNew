using AutoMapper;
using SVR.Core.Models;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.Profiles
{
   public class BillProfile:Profile
    {
        public BillProfile()
        {
            CreateMap<Bill, BillDto>()
                  .ForMember(dest => dest.BillItemCount, src => src.MapFrom(x => x.BillItems.Count))
                  .ForMember(dest => dest.CustomerName, src => src.MapFrom(x => x.BilledCustomer.Name))
                  .MaxDepth(1)
                  .ReverseMap();

            CreateMap<BillUpdateModel, Bill>().ReverseMap();

        }
       
    }
}
