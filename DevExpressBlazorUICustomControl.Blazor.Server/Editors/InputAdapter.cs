using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpressBlazorUICustomControl.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;

namespace DevExpressBlazorUICustomControl.Blazor.Server.Editors
{
    public class InputAdapter : ComponentAdapterBase
    {
        public InputModel myComponentModel { get; }
        public InputAdapter(InputModel componentModel)
        {
            myComponentModel = componentModel;
            myComponentModel.ValueChanged = EventCallback.Factory.Create<ArticleSearch>(this, value => { myComponentModel.Value = value; RaiseValueChanged(); });
        }
        public override IComponentModel ComponentModel { get; }

        public override object GetValue() => myComponentModel.Value;
        public override void SetAllowEdit(bool allowEdit) => myComponentModel.ReadOnly = !allowEdit;
        public override void SetAllowNull(bool allowNull) { }
        public override void SetDisplayFormat(string displayFormat) { }
        public override void SetEditMask(string editMask) { }
        public override void SetEditMaskType(EditMaskType editMaskType) { }
        public override void SetErrorIcon(ImageInfo errorIcon) { }
        public override void SetErrorMessage(string errorMessage) { }
        public override void SetIsPassword(bool isPassword) { }
        public override void SetMaxLength(int maxLength) { }
        public override void SetNullText(string nullText) { }
        public override void SetValue(object value) => myComponentModel.Value = (ArticleSearch)value;
        protected override RenderFragment CreateComponent()
        {
            return ComponentModelObserver.Create(myComponentModel, InputRenderer.Create(myComponentModel));
        }
    }
}
