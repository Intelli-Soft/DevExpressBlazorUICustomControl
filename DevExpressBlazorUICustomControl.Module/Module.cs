using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpressBlazorUICustomControl.Module.Helpers;

namespace DevExpressBlazorUICustomControl.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class DevExpressBlazorUICustomControlModule : ModuleBase {
    public DevExpressBlazorUICustomControlModule() {
		// 
		// DevExpressBlazorUICustomControlModule
		// 
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
        application.SetupComplete += Application_SetupComplete;
    }

    private void Application_SetupComplete(object sender, EventArgs e)
    {
        Application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
    }

    private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
    {
        NonPersistentObjectSpace locNonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
        if (locNonPersistentObjectSpace != null)
        {
            new AvailableNonPersistentAdapter(locNonPersistentObjectSpace);


        }

        CompositeObjectSpace locCompositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
        if (locCompositeObjectSpace != null)
        {
            if (!(locCompositeObjectSpace.Owner is CompositeObjectSpace))
            {
                locCompositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
            }
        }
    }

    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }
    
}
