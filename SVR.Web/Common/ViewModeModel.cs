using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVR.Web.Common
{
    public class ViewModeModel
    {
        public event Action OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();

        public bool IsGridViewMode { get; private set; }
        public bool IsDetailViewMode { get; private set; }

        public bool IsDetailEditMode { get; private set; }
        public bool Popup { get; set; }
        public bool IsNew { get; set; }

        public bool HasWizard { get; set; }

        public ViewModeModel()
        {
            IsGridViewMode = true;
            Popup = false;
        }

        public void NestedModalChange(bool val)
        {
            Popup = !val;
        }

        public EventHandler<bool> ViewModeUpdatedEvent { get; set; }

        public void SwitchToDetailView(bool swithOffEditMode = true)
        {
            IsGridViewMode = false;
            IsDetailViewMode = true;
            if (swithOffEditMode)
            {
                IsDetailEditMode = false;
            }
            Popup = true;
        }

        public void SwitchToGridView()
        {
            IsGridViewMode = true;
            IsDetailViewMode = false;
            IsDetailEditMode = false;
            Popup = false;
        }

        public void SwitchToEditMode()
        {
            IsGridViewMode = false;
            IsDetailEditMode = true;
            Popup = true;
        }

        public void ApplyEditModeChange(bool val)
        {
            IsDetailEditMode = val;
            Popup = true;
            ViewModeUpdatedEvent?.Invoke(this, val);
        }

        #region UI css and state helpers

        public string CssClassForForm
        {
            get
            {
                string wizardMode = (HasWizard && IsNew) ? "wizard-mode" : string.Empty;
                return $"card card-form {(IsDetailEditMode ? $"edit-mode {wizardMode}" : "read-only-mode")}";
            }
        }

        public bool FormItemIsReadOnlyMode
        {
            get
            {
                return !IsDetailEditMode;
            }
        }

        public bool IsInputDisabled
        {
            get
            {
                return !IsDetailEditMode;
            }
        }

        public bool FormItemIsEnabled
        {
            get
            {
                return IsDetailEditMode;
            }
        }

        #endregion

    }
}
