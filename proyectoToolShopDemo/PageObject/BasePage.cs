using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace proyectoToolShopDemo.PageObject
{
    public abstract class BasePage
    {

        protected IWebDriver Driver;

        // Instancia de espera explícita
        protected WebDriverWait Wait;
        private string v;

        // Constructor que recibe el WebDriver y configura una espera de 10 segundos
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected BasePage(string v)
        {
            this.v = v;
        }

        // Método protegido que espera hasta que un elemento sea visible y lo devuelve
        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        // Método público para obtener la URL actual del navegador
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        //Metodos dinamicos

        public bool elementosVisibles(By selector)
        {
            Console.WriteLine("Encontrando elementos...");
            var elementos = Driver.FindElements(selector);
            return elementos.Count > 0;
        }

        public int cantidadDeProductos(By selector)
        {
            Console.WriteLine("Contando elementos...");
            var elementos = Driver.FindElements(selector);
            return elementos.Count;
        }

        public void presionandoElemento(By selector)
        {
            Console.WriteLine("Presionando elemento...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement elemento = wait.Until(ExpectedConditions.ElementToBeClickable(selector));
            elemento.Click();
        }
        /*
        public string saberValorInput(By selector)
        {
            Console.WriteLine("Obteniendo el valor del input...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement btn = wait.Until(ExpectedConditions.ElementToBeClickable(selector));

            string valor = btn.GetAttribute("value");

            Console.WriteLine($"Cantidad actual: {valor}");

            return valor;

        }*/

        public string obtenerValorDeInput(By selector)
        {
            Console.WriteLine("Obteniendo el valor del input...");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(selector));

            string valor = input.GetAttribute("value");
            return valor;
        }

        public void insertarValorCarrito(By selector, string valor)
        {
            //WaitForElement(selector).Clear();
            Console.WriteLine("Cambiando el numero en el input...");
            Driver.FindElement(selector).SendKeys(valor);
            Console.WriteLine($"Cantidad actual: {valor}");

        }

        public void insertarValorInput(By selector, string valor)
        {
            WaitForElement(selector).Clear();
            Console.WriteLine("Agregando texto al input...");
            Driver.FindElement(selector).SendKeys(valor);
            Console.WriteLine($"Cantidad actual: {valor}");

        }

        public string obtenerTextoAlerta(By selector)
        {
            Console.WriteLine("Esperando que la alerta sea visible...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement alerta = wait.Until(ExpectedConditions.ElementIsVisible(selector));

            Console.WriteLine("Obteniendo texto...");
            return alerta.Text;
        }

        public void seleccionar(By selector, string texto)
        {
            Console.WriteLine($"Seleccionando: {texto}");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement selectElement = wait.Until(ExpectedConditions.ElementToBeClickable(selector));

            // Crea el objeto SelectElement con el <select>
            SelectElement buscar = new SelectElement(selectElement);
            // Selecciona por el texto visible
            buscar.SelectByText(texto);
        }

        public bool estaAlertaVisible(By selector)
        {
            Console.WriteLine("Esperando que la alerta sea visible...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement alerta = wait.Until(ExpectedConditions.ElementIsVisible(selector));
                return alerta.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("La alerta no apareció.");
                return false;
            }
        }

        public bool inputNoEstaVacio(By selector)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            return !string.IsNullOrWhiteSpace(input.GetAttribute("value"));
        }

        public void presionarConEnter(By selector)
        {
            Console.WriteLine("Enviando tecla ENTER...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            input.SendKeys(Keys.Enter);
        }

        public void clickConJavaScript(By selector)
        {
            Console.WriteLine("Forzando click con JavaScript...");
            IWebElement elemento = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementExists(selector));

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].click();", elemento);
        }
    }
}
