using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
