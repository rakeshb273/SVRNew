using Microsoft.AspNetCore.Components;
using SVR.Core.Services.Interface;
using SVR.Shared.Parameters;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Web.Adaptors
{
    
    public class SampleAdaptor : DataAdaptor
    { 

        private readonly IBillService Service;

        public SampleAdaptor(IBillService _Service)
        {
            this.Service = _Service;
        }


        public async override Task<object> ReadAsync(DataManagerRequest options, string key = null)
        {
            
            var response = await Service.GetSyncAll(options.Skip,options.Take );
            

            DataResult dataResult = new DataResult()
            {
                Result = response ,
                Count = response.Count(),
            };

            return dataResult;
        }
    }
}
