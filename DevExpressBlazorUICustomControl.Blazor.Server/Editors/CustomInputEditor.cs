using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpressBlazorUICustomControl.Module.BusinessObjects;

namespace DevExpressBlazorUICustomControl.Blazor.Server.Editors
{
    [PropertyEditor(typeof(ArticleSearch), true)]
    public class CustomInputEditor : BlazorPropertyEditorBase, IComplexViewItem
    {

        private IObjectSpace myObjectSpace;
        private XafApplication myXafApplication;
        public CustomInputEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }

        public void Setup(IObjectSpace objectSpace, XafApplication application) {
            myObjectSpace = objectSpace;
            myXafApplication = application;
        }
    
        protected override IComponentAdapter CreateComponentAdapter() => new InputAdapter(new InputModel());
    }
}
