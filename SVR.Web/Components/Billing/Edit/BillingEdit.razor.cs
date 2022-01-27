using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SVR.Core.RelatedData;
using SVR.Core.Services.Interface;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using Syncfusion.Blazor.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components.Billing.Edit
{
    public partial class BillingEdit : EditComponent, IDisposable
    {


        public BillUpdateModel ExistingModel { get; set; }
        public BillUpdateModel EditModel { get; set; }

        public List<Customer> Customers { get; set; }

        public BillRelatedDto relatedDto { get; set; }

        [Inject]
        protected IBillService Service { get; set; }



        protected override async Task OnInitializedAsync()
        {
            EditModel = new BillUpdateModel();
            EditModel.CGST = 9;
            EditModel.SGST = 9;
            var billitem = new BillItem { Price = 54, Quantity = 452 };
            relatedDto = new BillRelatedDto();
            relatedDto= await Service.GetRelatedData(default);
            Customers =
                new List<Customer> {
                new Customer { Name = "General Sewing Machines", ID = 1,GSTIN= "36AABFG7254P1ZX",GRNO= "TS09UB4183 " },
                new Customer { Name = "Sri Durga Agencis ", ID = 2, GSTIN = "36AABFG7254P1ZXQQ", GRNO = "TS09UB4183QQ",  }
            };

            EditModel.BilledCustomer = relatedDto.customers.Where(x => x.ID == 2).FirstOrDefault();

            EditModel.billItems.Add(billitem);
            await base.OnInitializedAsync();

            //editContext.OnValidationRequested += HandleValidationRequested;
            //editContext = new(EditModel);
            //messageStore = new(editContext);

        }
        private async Task AddBillItem()
        {


            EditModel.billItems.Add(new BillItem());
        }
        private async Task RemoveBillItem(BillItem billItem)
        {


            EditModel.billItems.Remove(billItem);
        }

        private async Task CustomerChanged(ChangeEventArgs e)
        {
            var a = e.Value.ToString();
        }



        private EditContext? editContext;
        private async void HandleValidSubmit()
        {
            if (editContext != null && editContext.Validate())
            {
                await Service.CreateorUpdate(EditModel, default);
            }
            else
            {
                // Logger.LogInformation("HandleSubmit called: Form is INVALID");
            }

            // Process the valid form
        }

        private ValidationMessageStore? messageStore;
        private void HandleValidationRequested(object? sender,
        ValidationRequestedEventArgs args)
        {
            messageStore?.Clear();

            // Custom validation logic
            if (EditModel != null)
            {
                messageStore?.Add(() => true, "Select at least one.");
            }
        }


        private void ValueChangeHandler(ChangeEventArgs<int, Customer> args)
        {
            EditModel.BilledCustomer = args.ItemData;

        }

        private void OnValueSelecthandler(SelectEventArgs<Customer> args)
        {
            EditModel.BilledCustomer = args.ItemData;

            // Here you can customize your code
        }

        public void Dispose()
        {
            if (editContext is not null)
            {
                editContext.OnValidationRequested -= HandleValidationRequested;
            }
        }




    }
}
