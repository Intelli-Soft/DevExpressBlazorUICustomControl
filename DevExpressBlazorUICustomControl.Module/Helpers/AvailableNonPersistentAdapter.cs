using DevExpress.ExpressApp;
using DevExpressBlazorUICustomControl.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressBlazorUICustomControl.Module.Helpers
{
    public class AvailableNonPersistentAdapter
    {

        private NonPersistentObjectSpace myObjectSpace;
        private ArticleInput myArticleInput;
        public AvailableNonPersistentAdapter(NonPersistentObjectSpace objectSpace)
        {
            myObjectSpace = objectSpace;
            myObjectSpace.ObjectByKeyGetting += ObjectByKeyGetting;
        }

        private void ObjectByKeyGetting(object sender, ObjectByKeyGettingEventArgs e)
        {
            {
                IObjectSpace locObjectSpace = (IObjectSpace)sender;
                if (e.ObjectType.IsAssignableFrom(typeof(ArticleInput)))
                {
                    if (e.Key != null)
                    {
                        if ((long)e.Key == -1)
                        {
                            if (myArticleInput == null)
                            {
                                myArticleInput = locObjectSpace.CreateObject<ArticleInput>();
                                myArticleInput.Id = -1;
                                myArticleInput.IsFirstLevel = true;
                                locObjectSpace.CommitChanges();
                            }

                            e.Object = myArticleInput;

                        }
                    }
                }
            }
        }
    }
}
