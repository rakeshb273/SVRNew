using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Components;
using SVR.Core.Models;
using SVR.Core.Services.Interface;
using SVR.Web.Common;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Web.Components
{
    public partial class Sample : GridComponent
    {
        public List<BillDto> MyProperty { get; set; }
        //public Sample()
        //{
        //    MyProperty = new List<BillDto>();
        //    for(int i = 0; i < 100; i++)
        //    {
        //        MyProperty.Add(new BillDto { id = i, Name = $"Name" + i, User = $"User" + i ,Place=$"Place SVR"+i});
        //    }
        //}

        [Inject]
        protected IBillService Service { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        //public async Task<LoadResult> LoadAsync(DataSourceLoadOptionsBase options, CancellationToken cancellationToken)
        //{

        //    var fp = await ConfigureParameters(options, 15, DefaultOptions());
        //   var RecordCount = await Service.GetTotalRecords(fp, cancellationToken);
        //    var response = await Service.GetPagedCollection(fp, cancellationToken);
        //    if (response.Succeeded)
        //    {
        //        return new LoadResult()
        //        {
        //            data = response.Data,
        //            totalCount = RecordCount
        //        };
        //        //return new DataResult()
        //        //{
        //        //    Result = response.Data,
        //        //    Count = RecordCount
        //        //}; 
        //    }

        //    return EmptyResult();
        //}

        //public async Task<DataResult> LoadAsync(DataManagerRequest options, CancellationToken cancellationToken)
        //{
        //    //var options = new DataSourceLoadOptionsBase { Skip = newOptions.Skip, Take = newOptions.Take };
        //    var fp = await ConfigureSyncParameters(options, 15, DefaultOptions());
        //    var RecordCount = await Service.GetTotalRecords(fp, cancellationToken);
        //    var response = await Service.GetPagedCollection(fp, cancellationToken);
        //    if (response.Succeeded)
        //    {
        //        //    return new LoadResult()
        //        //    {
        //        //        data = response.Data,
        //        //        totalCount = RecordCount
        //        //    };
        //        return new DataResult()
        //        {
        //            Result = response.Data,
        //            Count = RecordCount
        //        };
        //    }

        //    return EmptyDataResult();
        //}
        private List<object> DefaultOptions()
        {
            return new List<object>() { "Active", "=", "true" };
        }


        //private  void LoadData()
        //{
        //    MyProperty = new List<BillDto>();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        MyProperty.Add(new BillDto { id = i,  CustomerName = $"Name" + i,  InvoiceNo = $"Invoice" + i, BilledDate = DateTime.Now.AddDays(-i)});
        //    }
        //}
    }

    

     

}
