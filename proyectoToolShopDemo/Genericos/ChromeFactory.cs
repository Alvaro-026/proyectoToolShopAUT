﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace proyectoToolShopDemo.Genericos
{
    public class ChromeFactory
    {
        public static IWebDriver CrearDriver(ChromeOptions options) {

            return new ChromeDriver(options);
        
        }

    }
}
