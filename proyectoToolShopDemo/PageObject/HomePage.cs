
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using proyectoToolShopDemo.PageObject;
using SeleniumExtras.WaitHelpers;

namespace proyectoToolShopDemo
{
    public class HomePage: BasePage
    {

        private readonly string loginUrl = "https://practicesoftwaretesting.com/";

        private By tbxCard = By.XPath("/html/body/app-root/div/app-overview/div[3]/div[2]/div[1]/a[1]");
        private By campoBusqueda = By.XPath("//*[@id=\"search-query\"]");
        private By btnBuscar = By.XPath("//*[@id=\"filters\"]/form[2]/div/button[2]");
        private By cardProducto= By.CssSelector(".card");
        private By logo = By.XPath("/html/body/app-root/app-header/nav/div/a");
        private By btnSiguiente = By.CssSelector("a[aria-label='Next']");
        private By btnAnterior = By.CssSelector("a[aria-label='Previous']");
        private By inputCategoria = By.XPath("//*[@id=\"filters\"]/fieldset[1]/div[1]/label/input");
        private By inputSubCategoria = By.XPath("//*[@id=\"filters\"]/fieldset[1]/div[2]/ul/fieldset/div[1]/label/input");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(loginUrl);

        }

        public bool hayProductosVisibles()
        {
            var productos = elementosVisibles(cardProducto);
            return productos;
        }

        public int obtenerCantidadDeProductos()
        {
            var productos = cantidadDeProductos(cardProducto);
            return productos;
        }

        public void clickLogo()
        {
            presionandoElemento(logo);
        }

        public void clickSiguiente()
        {
            presionandoElemento(btnSiguiente);
        }

        public void clickAnterior()
        {
            presionandoElemento(btnAnterior);
        }


        public void clickProducto()
        {
            presionandoElemento(tbxCard);

        }

        public bool ClickEnPaginaSiExiste(int numeroPagina)
        {
            try
            {
                Console.WriteLine($"Intentando ir a la página {numeroPagina}...");
                string selector = $"a[aria-label='Page-{numeroPagina}']";
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
                var paginaBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
                paginaBtn.Click();
                return true;
            }
            catch
            {
                Console.WriteLine($"Página {numeroPagina} no existe.");
                return false;
            }
        }

        public void clickCategoria()
        {
            presionandoElemento(inputCategoria);
        }

        public void clickSubCategoria()
        {
            presionandoElemento(inputSubCategoria);
        }

        public void escribirEnElBuscador(string texto)
        {
            Console.WriteLine($"Escribiendo '{texto}' en el campo de búsqueda");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement campo = wait.Until(ExpectedConditions.ElementToBeClickable(campoBusqueda));
            campo.Clear();
            campo.SendKeys(texto);
        }

        public void clickBuscador()
        {
            Console.WriteLine("Presionando el btn buscar");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement btn = wait.Until(ExpectedConditions.ElementToBeClickable(btnBuscar));
            btn.Click();
        }


        /*

        private IWebDriver driver;
        private string baseURL;

        //Selectores

        private By tbxCard = By.XPath("/html/body/app-root/div/app-overview/div[3]/div[2]/div[1]/a[1]");

        //Metodos

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ingresarProducto() {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Espera hasta que el elemento con el selector esté visible y clickeable
            IWebElement card = wait.Until(ExpectedConditions.ElementToBeClickable(tbxCard));
            card.Click();


        }*/

    }
}