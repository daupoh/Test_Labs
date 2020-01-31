using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.view
{
    class CMockView : IView
    {
        public string Name { get => "Григор"; set => throw new NotImplementedException(); }
        public string Surname { get => "Клиган"; set => throw new NotImplementedException(); }
        public string City { get => "Королевская гавань"; set => throw new NotImplementedException(); }
        public string Country { get => "Семь королевств"; set => throw new NotImplementedException(); }

        public string ImageLocation => "https://image.jpg";

        public string[] GetFields()
        {
            return new string[] { "Григор", "Клиган", "Королевская гавань", "Семь королевств" };
        }

        public void GetInformation(string _UserId)
        {
            if (_UserId=="")
            {
                throw new InvalidOperationException();
            }
        }
    }
}
