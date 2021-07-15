using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components.Bill.Grid
{
    public  partial class BillGrid
    {
        //private readonly AppDbContext _context;
        //public BillGrid(AppDbContext context)
        //{
        //    _context = context;

        //}

        public List<Bill> Grid { get; set; }
        //protected override Task OnInitializedAsync()
        //{
        //    Grid = _context.Bills.ToList();
        //    return base.OnInitializedAsync();
        //}
    }
}
