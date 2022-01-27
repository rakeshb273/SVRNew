using Microsoft.AspNetCore.Components.Forms;
using SVR.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Components
{
    public class EditComponent:BaseComponent,IDisposable
    {
        private bool disposedValue;
        private bool isLoading;

        protected EditForm Form { get; set; }

        protected override void OnInitialized()
        {
            if (ViewMode == null)
            {
                ViewMode = new ViewModeModel();
            }
            //ViewMode.ViewModeUpdatedEvent += ViewModeUpdated;
            ViewMode.OnChange += StateHasChanged;
            base.OnInitialized();
        }

        protected   override async Task OnInitializedAsync()
        {
            //ProgressHandler.IsLoading += ProgressLoading;
            await base.OnInitializedAsync();
        }
        //[Inject]
        //protected ProgressHandler ProgressHandler { get; set; }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Form = null;
                }

                disposedValue = true;
            }
        }
    }
}
