using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.view
{
    interface IView
    {
        string Name { get;  }
        string Surname { get;  }
        string City { get;  }
        string Country { get;  }
        string ImageLocation { get; }


        string[] GetFields();
        void GetInformation(string _UserId);
       
    }
}
