using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.api;
using wf_testLabs.controller;
using wf_testLabs.view;

namespace wf_testLabs
{
    [TestFixture]
    class TCMocks
    {
        IView m_rView;
        IViewApi m_rViewApi;
        IVkApi m_rVkApi;

        [Test]
        public void TestView()
        {
            m_rView = new CView(new CMockViewApi());
            m_rView.GetInformation("123");
            string[] aFields = m_rView.GetFields();
            Assert.AreEqual("Евгений", aFields[0]);
            Assert.AreEqual("Стоялов", aFields[1]);
            Assert.AreEqual("Берлин", aFields[2]);
            Assert.AreEqual("Германия", aFields[3]);

            Assert.AreEqual("Евгений", m_rView.Name);
            Assert.AreEqual("Стоялов", m_rView.Surname);
            Assert.AreEqual("Берлин", m_rView.City);
            Assert.AreEqual("Германия", m_rView.Country);

            Assert.AreEqual("https://image.jpg" , m_rView.ImageLocation);

        }
        [Test]
        public void TestViewApi()
        {
            m_rViewApi = new CViewApi(new CMockVkApi());
            Dictionary<string,string> rDict = new Dictionary<string, string>()
            {
                { "photo_max","https://image.jpg" },
                { "first_name","Евгений" },
                { "last_name","Стоялов" },
                { "country","Россия" },
                { "city","Белгород" }
            };

            Assert.AreEqual("Белгород",m_rViewApi.GetCityById(""));
            Assert.AreEqual("Россия", m_rViewApi.GetCountryById(""));
            Assert.IsTrue(rDict.Equals(m_rViewApi.GetInformation("",null)));
        }

        [Test]
        public void TestVkApi()
        {
            m_rVkApi = new CVkApi("7301831");
            string sToken = m_rVkApi.GetToken();
            string[] Params = { "city", "country", "photo_max" };
            string sResponse = m_rVkApi.GetUsers("daupoh", Params, sToken);
            Assert.AreEqual("{\"id\":248768661,\"first_name\":" +
                "\"Евгений\",\"last_name\":\"Стоялов\",\"city\"" +
                ":{\"id\":26,\"title\":\"Белгород\"},\"country\"" +
                ":{\"id\":1,\"title\":\"Россия\"},\"photo_max\":" +
                "\"https:\\/\\/sun9-50.userapi.com\\/c638816\\/v638816405" +
                "\\/5aad7\\/6eUUkRy2oew.jpg?ava=1\"}", sResponse);
        }


    }
}
