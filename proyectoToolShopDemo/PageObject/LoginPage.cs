using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace proyectoToolShopDemo.PageObject
{
    public class LoginPage : BasePage
    {
        private readonly string loginUrl = "https://practicesoftwaretesting.com/";

        private By btnIniciarSesion = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[4]/a");
        private By btnRegistrarse = By.XPath("/html/body/app-root/div/app-login/div/div/div/div[3]/p/a[1]");
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
        //inicio sesion
        private By btnLogin = By.ClassName("btnSubmit");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(loginUrl);
        }

        public void clickIniciarSesion()
        {
            presionandoElemento(btnIniciarSesion);
        }

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

        public void agregarPaisFormulario(string fecha)
        {
            seleccionar(selectPaisFormulario, fecha);
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
            presionandoElemento(btnLogin);
            Console.WriteLine("Se presiono...");
        }




    }
}
