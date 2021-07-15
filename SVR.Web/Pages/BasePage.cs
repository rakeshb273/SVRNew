using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

using SVR.Web.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Pages
{
    public abstract class BasePage: BaseComponent
    {
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //if (PermissionService.HasReadPermission())
                //{
                    //await JsRuntime.InvokeVoidAsync("common.loaded");
                //}
                //else
                //{
                //    NavigationManager.NavigateTo($"/{Configuration["VirtualDirectory"]}/access-denied");
                //}
            }

            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
