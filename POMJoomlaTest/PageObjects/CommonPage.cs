using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMJoomlaTest.PageObjects
{
    class CommonPage
    {



        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://192.168.190.247/joomlatest/administrator/index.php");
        }
    }
}
