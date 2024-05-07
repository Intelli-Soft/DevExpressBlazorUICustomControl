using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpressBlazorUICustomControl.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpressBlazorUICustomControl.Module.Controllers
{
    
    public partial class ArticleInputDetailViewController : ObjectViewController<DetailView, ArticleInput>
    {
        IObjectSpace myObjectSpace = null;
        public ArticleInputDetailViewController()
        {
            InitializeComponent();
            SimpleAction mySimpleAction = new SimpleAction(this, "MySimpleAction", "MyCategory")
            {
                Caption = "Add Article",
                ConfirmationMessage = "Article added",
            };
            mySimpleAction.Execute += MySimpleAction_Execute;
        }

        private void MySimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ArticleInput locCurrentObject = View.CurrentObject as ArticleInput;

            locCurrentObject.SavedArticles.Add(new ArticleInput
            {
                Id = locCurrentObject.SavedArticles.Count +1,
                Price = locCurrentObject.Price,
                Description = locCurrentObject.Description
                
            });

        }

        protected override void OnActivated()
        {
            base.OnActivated();
        if (myObjectSpace == null)
            {
                myObjectSpace = View.ObjectSpace;
                View.ViewEditMode = ViewEditMode.Edit;
                myObjectSpace.ObjectChanged += MyObjectSpace_ObjectChanged;
            }
        }

        private void MyObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {

            if(e.PropertyName == nameof(ArticleInput.Search))
            {
                myObjectSpace.ObjectChanged -= MyObjectSpace_ObjectChanged;
                ArticleInput locCurrentObject = e.Object as ArticleInput;
                locCurrentObject.Price = locCurrentObject?.Search.Price ?? 0;
                locCurrentObject.Description = locCurrentObject?.Search.Description ?? string.Empty;
                myObjectSpace.ObjectChanged += MyObjectSpace_ObjectChanged;
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            if (myObjectSpace != null)
                myObjectSpace.ObjectChanged -= MyObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }
    }
}
