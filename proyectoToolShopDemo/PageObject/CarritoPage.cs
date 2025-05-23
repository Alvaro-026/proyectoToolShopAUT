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
    public class CarritoPage: BasePage
    {
        //https://practicesoftwaretesting.com/product/01JVARH2PN8CV4694194KJ6FWW
        //https://practicesoftwaretesting.com/product/01JVARH2PJ8PCECM52Z4M4397N

        //https://practicesoftwaretesting.com/
        private readonly string loginUrl = "https://practicesoftwaretesting.com/";
        private By cardProducto = By.XPath("/html/body/app-root/div/app-overview/div[3]/div[2]/div[1]/a[1]");
        private By btnInsertarCarrito = By.XPath("//*[@id=\"btn-add-to-cart\"]");
        private By btnIconoCarrito = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");
        private By inputCantidadCarrito = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[1]/app-cart/div/table/tbody/tr/td[2]/input");
        private By inputAgregarCarrito = By.XPath("//*[@id=\"quantity-01jvcpc6h2fd5n1tng11qce9fp\"]");
        private By btnPasarPorCaja = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[1]/app-cart/div/div/button");
        private By inputEmailCarrito = By.XPath("//*[@id=\"email\"]");
        private By inputPasswordCarrito = By.XPath("//*[@id=\"password\"]");
        private By btnLoginCarrito = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/form/div[3]/input");
        private By lblErrorLoginCarrito = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/div/div");
        private By logo = By.XPath("/html/body/app-root/app-header/nav/div/a");
        //logueo registrarse
        private By btnRegistrarse = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/form/div[4]/p/a[1]");
        private By inputNombreFormulario = By.XPath("//*[@id=\"first_name\"]");
        private By inputApellidosFormulario = By.XPath("//*[@id=\"last_name\"]");
        private By inputFechaNacimientoFormulario = By.XPath("//*[@id=\"dob\"]");
        private By inputCalleFormulario = By.XPath("//*[@id=\"street\"]");
        private By inputCodigoPostalFormulario = By.XPath("//*[@id=\"postal_code\"]");
        private By selectPaisFormulario = By.XPath("//*[@id=\"country\"]");
        private By inputTelefonoFormulario = By.XPath("//*[@id=\"phone\"]");
        private By inputEstadoFormulario = By.XPath("//*[@id=\"state\"]");
        private By inputCiudadFormulario = By.XPath("//*[@id=\"city\"]");
        private By inputEmailFormulario = By.XPath("//*[@id=\"email\"]");
        private By inputPasswordFormulario = By.XPath("//*[@id=\"password\"]");
        private By btnOjoPasswordFormulario = By.XPath("/html/body/app-root/div/app-register/div/div/div/form/div/div[11]/app-password-input/div/div/button");
        private By btnRegistrarseFormulario = By.XPath("/html/body/app-root/div/app-register/div/div/div/form/div/button");
        private By alertaErrorFormulario = By.CssSelector("div.alert.alert-danger");
        //Logueo ya registrado
        private By btnLogin = By.XPath("/html/body/app-root/div/app-login/div/div/div/form/div[3]/input");
        private By btnPasarPorLaCaja = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[2]/app-login/div/div/div/div/button");
        private By btnPasarPorLaCajaAfirmacion = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-step[3]/app-address/div/div/div/div/button");
        private By inputPaisAfirmacion = By.XPath("//*[@id=\"country\"]");
        private By selectTipoPago= By.XPath("//*[@id=\"payment-method\"]");
        private By btnAfirmacionCompra = By.XPath("/html/body/app-root/div/app-checkout/aw-wizard/div/aw-wizard-completion-step/app-payment/div/div/div/div/button");

        private By alertaExitosa = By.CssSelector("div.alert.alert-success");

        private By cardProductoAleatorio = By.CssSelector(".card");
        private By pAgotado = By.CssSelector("p[data-test='out-of-stock']");

        public CarritoPage(IWebDriver driver) : base(driver) {}

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(loginUrl);
        }

        public void irAlProducto()
        {
            presionandoElemento(cardProducto);
        }

        public void agregarAlCarrito() 
        {
            presionandoElemento(btnInsertarCarrito);
        }

        public void irAlCarrito()
        {
            presionandoElemento(btnIconoCarrito);
        }
 
        public void agregarNumeroDeProductosCarrito(string cantidad) 
        {
            insertarValorCarrito(inputAgregarCarrito, cantidad);
        }

        public void agregarProductosDentroCarrito(string cantidad)
        {
            insertarValorInput(inputCantidadCarrito, cantidad);
        }

        public void clickPasarPorCaja()
        {
          presionandoElemento(btnPasarPorCaja);
        }

        public void volverHome()
        {
            presionandoElemento(logo);
        }

        public void agregarEmailCarrito(string correo)
        {
            insertarValorInput(inputEmailCarrito,correo);
        }

        public void agregarPasswordCarrito(string password)
        {
            insertarValorInput(inputPasswordCarrito,password);
        }

        public void clickBtnLoginCarrito()
        {
            presionandoElemento(btnLoginCarrito);
        }

        public String obteniendoAlertaError()
        {
            return obtenerTextoAlerta(lblErrorLoginCarrito);
        }

        //Logueo

        public void clickRegistrarCuenta()
        {
            presionandoElemento(btnRegistrarse);
        }

        public void agregarNombreFormulario(string nombre)
        {
            insertarValorInput(inputNombreFormulario, nombre);
        }

        public void agregarApellidoFormulario(string apellido)
        {
            insertarValorInput(inputApellidosFormulario, apellido);
        }

        public void agregarCalleFormulario(string calle)
        {
            insertarValorInput(inputCalleFormulario, calle);
        }

        public void agregarCodigoPostalFormulario(string codigoPostal)
        {
            insertarValorInput(inputCodigoPostalFormulario, codigoPostal);
        }

        public void agregarTelefonoFormulario(string telefono)
        {
            insertarValorInput(inputTelefonoFormulario, telefono);
        }

        public void agregarEmailFormulario(string email)
        {
            insertarValorInput(inputEmailFormulario, email);
        }

        public void agregarPasswordFormulario(string password)
        {
            insertarValorInput(inputPasswordFormulario, password);
        }

        public void agregarFechaNacimientoFormulario(string fecha)
        {
            insertarValorInput(inputFechaNacimientoFormulario, fecha);
        }

        public void agregarPaisFormulario(string pais)
        {
            seleccionar(selectPaisFormulario, pais);
        }

        public void agregarEstadoFormulario(string estado)
        {
            insertarValorInput(inputEstadoFormulario, estado);
        }

        public void agregarCiudadFormulario(string ciudad)
        {
            insertarValorInput(inputCiudadFormulario, ciudad);
        }

        public void clickBtnOjoPassword()
        {
            presionandoElemento(btnOjoPasswordFormulario);
        }

        public void clickBtnRegistrarseFormulario()
        {
            presionandoElemento(btnRegistrarseFormulario);
        }

        public bool errorAlRegistrar()
        {
            return estaAlertaVisible(alertaErrorFormulario);
        }

        public void clickBtnLogin()
        {
            presionandoElemento(btnLogin); ;
        }

        public void clickBtnPasarPorLaCaja()
        {
            presionandoElemento(btnPasarPorLaCaja); 
        }

        public void clickBtnPasarPorLaCajaAfirmacion()
        {
            presionandoElemento(btnPasarPorLaCajaAfirmacion);
        }

        public bool validarInputsNoVacios()
        {
            Console.WriteLine("Validando que los inputs no estén vacíos...");

            bool calle = !string.IsNullOrWhiteSpace(obtenerValorDeInput(inputCalleFormulario));
            bool ciudad = !string.IsNullOrWhiteSpace(obtenerValorDeInput(inputCiudadFormulario));
            bool estado = !string.IsNullOrWhiteSpace(obtenerValorDeInput(inputEstadoFormulario));
            bool pais = !string.IsNullOrWhiteSpace(obtenerValorDeInput(inputPaisAfirmacion));
            bool codigoPostal = !string.IsNullOrWhiteSpace(obtenerValorDeInput(inputCodigoPostalFormulario));

            return calle && ciudad && estado && estado &&codigoPostal;
        }

        public void agregarTipoPago(string tipoPago)
        {
            seleccionar(selectTipoPago, tipoPago);
        }

        public void clickBtnAfirmacionCompra()
        {
            presionandoElemento(btnAfirmacionCompra);
        }

        public bool alertaCompraExitosa()
        {
            return estaAlertaVisible(alertaExitosa);
        }
        //metodos propios
        public void insertarCantidadEnInputAleatorio(string cantidad)
        {
            // Espera a que la tabla del carrito esté presente
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table/tbody/tr")));

            // Encuentra todas las filas del carrito
            var filas = Driver.FindElements(By.XPath("//table/tbody/tr"));

            if (filas.Count == 0)
            {
                throw new Exception("No hay productos en el carrito.");
            }

            Console.WriteLine($"Cantidad de productos en el carrito: {filas.Count}");

            // Selecciona un índice aleatorio
            Random rnd = new Random();
            int indiceAleatorio = rnd.Next(filas.Count); // de 0 a n-1

            // Construimos el XPath del input en esa fila (suponiendo que está en td[2])
            string xpathInput = $"//table/tbody/tr[{indiceAleatorio + 1}]/td[2]/input";
            By selectorInput = By.XPath(xpathInput);

            Console.WriteLine($"Seleccionando input de la fila #{indiceAleatorio + 1}");

            // Usamos tu método para insertar valor
            insertarValorInput(selectorInput, cantidad);
        }

        public void seleccionarYPresionarCardAleatorio()
        {
            var cards = Driver.FindElements(cardProductoAleatorio);

            if (cards.Count == 0)
                throw new Exception("No hay cards visibles.");

            Random rnd = new Random();
            int index = rnd.Next(cards.Count);

            string xpathCard = $"/html/body/app-root/div/app-overview/div[3]/div[2]/div[1]/a[{index + 1}]";
            By selector = By.XPath(xpathCard);

            presionandoElemento(selector);
        }

        public bool productoEstaAgotado()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementIsVisible(pAgotado));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void agregarAlCarritoSiEsta()
        {
            if (!productoEstaAgotado())
            {
                presionandoElemento(btnInsertarCarrito);
                Console.WriteLine("Producto agregado al carrito.");
            }
            else
            {
                Console.WriteLine("Producto agotado, no se agregó al carrito.");
            }
        }


        public void presionarBotonEliminarAleatorio()
        {
            Console.WriteLine("Buscando botones de eliminar en el carrito...");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table//tbody//tr/td[5]/a[contains(@class, 'btn-danger')]")));

            // Obtener todos los botones de eliminar
            var botonesEliminar = Driver.FindElements(By.XPath("//table//tbody//tr/td[5]/a[contains(@class, 'btn-danger')]"));

            if (botonesEliminar.Count == 0)
            {
                throw new Exception("No se encontraron botones de eliminar.");
            }

            // Elegir uno aleatoriamente
            Random rnd = new Random();
            int indiceAleatorio = rnd.Next(botonesEliminar.Count);

            Console.WriteLine($"Presionando botón de eliminar #{indiceAleatorio + 1}...");
            botonesEliminar[indiceAleatorio].Click();
        }






    }
}
