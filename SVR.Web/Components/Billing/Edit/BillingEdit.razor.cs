using Microsoft.AspNetCore.Components;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components.Billing.Edit
{
    public partial class BillingEdit
    {
        public Bill_UM BillUM { get; set; }

        public List<Customer> Customers { get; set; }


        protected override async Task OnInitializedAsync()
        {
            BillUM = new Bill_UM();
            BillUM.CGST = 9;
            BillUM.SGST = 9;
            var billitem = new BillItem { Price = 54, Quantity = 452 };
            Customers = new List<Customer> {
                new Customer { Name = "General Sewing Machines", ID = 1,GSTIN= "36AABFG7254P1ZX",GRNO= "TS09UB4183 " },
                new Customer { Name = "Sri Durga Agencis ", ID = 2, GSTIN = "36AABFG7254P1ZXQQ", GRNO = "TS09UB4183QQ",  }
            };
                
            BillUM.billItems.Add(billitem); await base.OnInitializedAsync();
        }
        private  async Task  AddBillItem()
        {


            BillUM.billItems.Add(new BillItem());
        }
        private async Task RemoveBillItem(BillItem billItem )
        {


            BillUM.billItems.Remove(billItem);
        }

        private async Task CustomerChanged(ChangeEventArgs e)
        {
            var a = e.Value.ToString();
        }

        private async Task Submit()
        {
            
        }




    }
}
