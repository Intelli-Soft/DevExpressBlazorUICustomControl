
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpressBlazorUICustomControl.Module.Helpers;
using DevExpressBlazorUICustomControl.Module.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevExpressBlazorUICustomControl.Module.BusinessObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    public class ArticleInput : Notify, IArticle
    {


        int myActualShortSearch;
        bool myIsFirstLevel = false;
        double myPrice;
        string myDescription;
        long myId;
        ArticleSearch mySearch;
        ObservableCollection<ArticleInput> mySavedArticles;
        BindingList<int> myShortSearchList = null;

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]
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

        public ArticleSearch Search { get => mySearch; set => SetPropertyValue(nameof(Search), ref mySearch, value); }

        [Browsable(false)]
        public BindingList<int> ShortSearchList
        {
            get
            {
                if (myShortSearchList == null)
                {
                    
                    myShortSearchList = [1, 2, 3];
                }
                return myShortSearchList;
            }
        }


        [DataSourceProperty(nameof(ShortSearchList))]
        public int ActualShortSearch
        {
            get => myActualShortSearch;
            set => SetPropertyValue(nameof(ActualShortSearch), ref myActualShortSearch, value);
        }


        [VisibleInDashboards(false)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("Visible", "False")]
        public bool IsFirstLevel
        {
            get => myIsFirstLevel;
            set => SetPropertyValue(nameof(IsFirstLevel), ref myIsFirstLevel, value);
        }


        [Appearance("VisibleChildArticleInput", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "![IsFirstLevel]", Context = "Any")]
        public IList<ArticleInput> SavedArticles
        {
            get
            {
                if(mySavedArticles == null)
                    mySavedArticles = new ObservableCollection<ArticleInput>();
                return mySavedArticles;
            }
        }


    }
}
