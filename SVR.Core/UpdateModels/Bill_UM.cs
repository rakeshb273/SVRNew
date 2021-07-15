using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.UpdateModels
{
    public class Bill_UM
    {
        public Bill_UM()
        {
            billItems = new List<BillItem>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public string InvoiceNo { get; set; }
        public Customer BilledCustomer { get; set; }
        public Customer ShippedCustomer { get; set; }
        public DateTime BilledDate { get; set; }
        public List<BillItem> billItems { get; set; }

        public int NetValue
        {
            get
            {
                return billItems.Sum(x => x.Amount);
            }
        }
        public int SGST { get; set; }
        public int CGST { get; set; }
        public int IGST { get; set; }
        public double Total { get { return Math.Round(NetValue * (1 + 0.01 * (SGST + CGST)), 2); } }
        public int GrandTotal { get { return (int)Total; } } 





        //public Bill_UM()
        //{
        //    DocumentTypes = new List<DocumentTypeDto>();
        //}
        //public string Description { get; set; }

        //public string Name { get; set; }


        //public List<DocumentTypeDto> DocumentTypes { get; set; }

        //public DocumentGovernanceDto DocumentGovernance { get; set; }

        //public int? DocumentGovernanceId { get { return DocumentGovernance == null ? 0 : DocumentGovernance.Id; } }
    }
}
