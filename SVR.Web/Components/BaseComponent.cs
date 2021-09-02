using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SVR.Shared.Parameters;
using SVR.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components
{
    public abstract class BaseComponent: ComponentBase
    {

        public ViewModeModel ViewMode { get; set; }
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected async Task<FilterParameter> GetParametersAsync(
           DataSourceLoadOptionsBase options,
           int pageIndex,
           int pageSize)
        {
            var sortColumn = string.Empty;
            var desc = false;

            //if (options.Sort != null)
            //{
            //    sortColumn = options.Sort.FirstOrDefault().Selector;
            //    desc = options.Sort.FirstOrDefault().Desc;
            //}

            var parameter = new FilterParameter() { Filter = options.Filter as List<object> };
            if (parameter.Filter == null)
            {
                parameter.Filter = new List<object>();
            }

            parameter.Pager = new PagedParameter
            {
                Skip = options.Skip,
                PageSize = pageSize,
                PageIndex = pageIndex,
                OrderBy = sortColumn,
                IsDescending = desc,
            };

            return await Task.FromResult(parameter);
        } 
        protected override async Task OnInitializedAsync()
        {
            if (ViewMode == null)
            {
                ViewMode = new ViewModeModel();
            }
            await base.OnInitializedAsync();
        }
    }
}
