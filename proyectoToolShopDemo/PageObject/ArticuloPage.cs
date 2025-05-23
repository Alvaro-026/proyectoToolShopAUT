using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace proyectoToolShopDemo.PageObject
{
    public class ArticuloPage: BasePage
    {
        //https://practicesoftwaretesting.com/product/01JVARH2PN8CV4694194KJ6FWW

        private readonly string loginUrl = "https://practicesoftwaretesting.com/";
        private By cardProducto = By.XPath("/html/body/app-root/div/app-overview/div[3]/div[2]/div[1]/a[1]");
        private By btnAumentar = By.XPath("//*[@id=\"btn-increase-quantity\"]");
        private By btnDisminuir = By.XPath("//*[@id=\"btn-decrease-quantity\"]");
        private By btnFavoritos = By.XPath("//*[@id=\"btn-add-to-favorites\"]");
        private By inputValor = By.XPath("//*[@id=\"quantity-input\"]");
        private By btnInsertarCarrito= By.XPath("//*[@id=\"btn-add-to-cart\"]");
        private By btnIconoCarrito = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");

        public ArticuloPage(IWebDriver driver) : base(driver) {}

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(loginUrl);
        }

        public void irAlProducto()
        {
            presionandoElemento(cardProducto);
        }

        public void clickAumentar() {

            presionandoElemento(btnAumentar);

        }

        public void clickDisminuir()
        {
            presionandoElemento(btnDisminuir);

        }

        public void clickFavoritos()
        {
            presionandoElemento(btnFavoritos);

        }

        public string saberValorInput()
        {

            string valor = obtenerValorDeInput(inputValor);

            Console.WriteLine($"Cantidad actual: {valor}");
            return valor;

        }

        public void clickInsertarCarrito()
        {
            presionandoElemento(btnInsertarCarrito);

        }

        public bool visualizarIconoCarrito()
        {
            Console.WriteLine("Validando la visualización del carrito.");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement elemento = wait.Until(ExpectedConditions.ElementToBeClickable(btnIconoCarrito));
                return elemento.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("El ícono del carrito no se encontró.");
                return false;
            }
        }
    }
}
