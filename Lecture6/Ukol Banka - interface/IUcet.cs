using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol_Banka___interface
{
    interface IUcet
    {
        //defaultne public
        string Vlastnik { get; }
        double Zustatek { get; }        
    }
}
