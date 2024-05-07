using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpressBlazorUICustomControl.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;

namespace DevExpressBlazorUICustomControl.Blazor.Server.Editors
{
    public class InputModel : ComponentModelBase
    {
        public EventCallback<ArticleSearch> ValueChanged { get => GetPropertyValue<EventCallback<ArticleSearch>>(); set => SetPropertyValue(value); }

        public bool ReadOnly { get => GetPropertyValue<bool>(); set => SetPropertyValue(value); }

        public IEnumerable<ArticleSearch> Data { get => GetPropertyValue<IEnumerable<ArticleSearch>>(); set => SetPropertyValue(value); }

        public ArticleSearch Value { get => GetPropertyValue<ArticleSearch>(); set => SetPropertyValue(value); }
    }
}
