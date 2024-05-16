using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpressBlazorUICustomControl.Module.Helpers;
using DevExpressBlazorUICustomControl.Module.Interfaces;
using System;
using System.Linq;

namespace DevExpressBlazorUICustomControl.Module.BusinessObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    [CreatableItem(false)]
    public class ArticleSearch : Notify, IArticle
    {

        double myPrice;
        string myDescription;
        long myId;

        [DevExpress.ExpressApp.Data.Key]
        public long Id
        {
            get => myId;
            set => SetPropertyValue(nameof(Id), ref myId, value);
        }

        public string Description
        {
            get => myDescription;
            set => SetPropertyValue(nameof(Description), ref myDescription, value);
        }


        public double Price
        {
            get => myPrice;
            set => SetPropertyValue(nameof(Price), ref myPrice, value);
        }

    }
}
