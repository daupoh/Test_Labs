using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using wf_testLabs.api;
using wf_testLabs.controller;
using wf_testLabs.view;

namespace wf_testLabs
{
    public partial class Form1 : Form
    {
        IView m_rView;
        public Form1()
        {
            InitializeComponent();        
            m_rView = new CView("7301831");
        }
      
        private void Button1_Click(object sender, EventArgs e)
        {
            m_rView.GetInformation(UserID.Text);
            string[] aFields = m_rView.GetFields();
            UserName.Text = aFields[0];
            UserSurname.Text = aFields[1];
            UserCity.Text = aFields[2];
            UserCountry.Text = aFields[3];
          
        }
    }
}
