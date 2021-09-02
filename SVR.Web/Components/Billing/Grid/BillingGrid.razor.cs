using Microsoft.AspNetCore.Components;
using SVR.Core.Models;
using SVR.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components.Billing.Grid
{
    public partial class BillingGrid :GridComponent
    { 
        
        [Inject]
        protected IBillRepository Repo { get; set; }

        public List<BillDto> AllBills { get; set; }

        //protected override async Task OnInitializedAsync() => AllBills = await Repo.GetAll(default);

        //protected override async Task OnInitializedAsync()
        //{
        //    
        //}


        //protected override async Task OnInitializedAsync()
        //{
        //    AllBills = await Repo.GetAll(default);
        //      await base.OnInitializedAsync();
        //}

    }
}
