using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressBlazorUICustomControl.Module.Interfaces
{
    public interface IArticle
    {
        long Id { get; set; }
        string Description { get; set; }
        double Price { get; set; }
    }
}
