using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using proyectoToolShopDemo.PageObject;

namespace proyectoToolShopDemo.Test
{
    [TestFixture]
    public class LoginTest: BaseTest
    {

        public LoginTest() : base("LoginPage.html")
        {
            // Función para pasar el nombre del reporte a nivel herencia
        }


        [Test]
        public void validarRegistroIncorrecto()
        {
            extentTest = extent.CreateTest("Validación de registro incorrecto.");
            string state = "";

            try
            {
                var pom = new LoginPage(Driver);

                state = "Navegar a la página de login.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Iniciar Sesión'.";
                pom.clickIniciarSesion();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Registrar Cuenta'.";
                pom.clickRegistrarCuenta();
                extentTest.Log(Status.Pass, state);

                state = "Llenar campos de dirección y contacto.";
                pom.agregarNombreFormulario("Alvaro");
                pom.agregarApellidoFormulario("Martinez Rojas");
                pom.agregarCalleFormulario("Siquirres");
                pom.agregarCodigoPostalFormulario("262626");
                pom.agregarTelefonoFormulario("89893232");
                extentTest.Log(Status.Pass, state);

                state = "Llenar campos de acceso.";
                pom.agregarEmailFormulario("alvaro2602.am5@gmail.com");
                pom.agregarPasswordFormulario("mrAL620....");
                pom.clickBtnOjoPassword();
                extentTest.Log(Status.Pass, state);

                state = "Agregar fecha de nacimiento y país/ciudad.";
                pom.agregarFechaNacimientoFormulario("26032002");
                pom.agregarPaisFormulario("Costa Rica");
                pom.agregarCiudadFormulario("Limon");
                extentTest.Log(Status.Pass, state);

                state = "Enviar formulario sin estado (esperando error).";
                pom.clickBtnRegistrarseFormulario();
                extentTest.Log(Status.Pass, state);

                state = "Verificar aparición de alerta de error.";
                bool hayError = pom.errorAlRegistrar();

                if (hayError)
                {
                    extentTest.Log(Status.Pass, "Se mostró correctamente una alerta de error.");
                }
                else
                {
                    extentTest.Log(Status.Fail, "No se mostró la alerta esperada.");
                }

                Assert.IsTrue(hayError, "La alerta no se mostró.");
                Thread.Sleep(2000);
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("FalloRegistroIncorrecto");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("ErrorRegistroIncorrecto");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }


        [Test]
        public void validarRegistroCorrecto()
        {
            extentTest = extent.CreateTest("Validación de registro correcto.");
            string state = ""; 

            try
            {
                var pom = new LoginPage(Driver);

                state = "Navegar a la página de login.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Iniciar Sesión'.";
                pom.clickIniciarSesion();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Registrar Cuenta'.";
                pom.clickRegistrarCuenta();
                extentTest.Log(Status.Pass, state);

                state = "Agregar nombre y apellido.";
                pom.agregarNombreFormulario("Alvaro");
                pom.agregarApellidoFormulario("Martinez Rojas");
                extentTest.Log(Status.Pass, state);

                state = "Completar datos de dirección.";
                pom.agregarCalleFormulario("Siquirres");
                pom.agregarCodigoPostalFormulario("262626");
                pom.agregarTelefonoFormulario("89893232");
                extentTest.Log(Status.Pass, state);

                state = "Agregar credenciales.";
                pom.agregarEmailFormulario("alvaro2602@gmail.com");
                pom.agregarPasswordFormulario("mrAL620....");
                pom.clickBtnOjoPassword();
                extentTest.Log(Status.Pass, state);

                state = "Agregar fecha de nacimiento y ubicación.";
                pom.agregarFechaNacimientoFormulario("26032002");
                pom.agregarPaisFormulario("Costa Rica");
                pom.agregarCiudadFormulario("Limon");
                pom.agregarEstadoFormulario("San Isidro");
                extentTest.Log(Status.Pass, state);

                state = "Enviar formulario de registro.";
                pom.clickBtnRegistrarseFormulario();
                extentTest.Log(Status.Info, state);

                state = "Verificar si hay errores de formulario.";
                bool hayError = pom.errorAlRegistrar();

                if (hayError)
                {
                    extentTest.Log(Status.Fail, "Se mostró una alerta de error en el formulario.");
                }
                else
                {
                    extentTest.Log(Status.Pass, "Registro completado sin errores.");
                }

                Assert.IsFalse(hayError, "Se mostró una alerta de error. Registro no exitoso.");
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(5000);

                extentTest.Log(Status.Pass, "La validación de registro correcto ha sido exitosa.");
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarInicioSesionCorrecto()
        {
            extentTest = extent.CreateTest("Validación de iniciar sesion correctamente.");
            string state = "";

            try
            {
                var pom = new LoginPage(Driver);

                state = "Navegar a la página de login.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Iniciar Sesión'.";
                pom.clickIniciarSesion();
                extentTest.Log(Status.Pass, state);

                state = "Agregar credenciales.";
                pom.agregarEmailFormulario("alvaro2602.am5@gmail.com");
                pom.agregarPasswordFormulario("mrAL620....");
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Login' para iniciar sesion.";
                pom.clickBtnLogin();
                extentTest.Log(Status.Pass, state);


                state = "Validar que no aparezca alerta de error.";
                Assert.IsFalse(pom.errorAlRegistrar(), "Se mostró una alerta de error. Registro no exitoso.");
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "La validación de iniciar sesion correctamente es exitosa.");
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarInicioSesionIncorrecto()
        {
            extentTest = extent.CreateTest("Validación de iniciar sesion incorrectamente.");
            string state = "";

            try
            {
                var pom = new LoginPage(Driver);

                state = "Navegar a la página de login.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Iniciar Sesión'.";
                pom.clickIniciarSesion();
                extentTest.Log(Status.Pass, state);

                state = "Agregar credenciales incorrectos.";
                pom.agregarEmailFormulario("alvaro2602.am50@gmail.com");
                pom.agregarPasswordFormulario("mrAL620...");
                extentTest.Log(Status.Pass, state);

                state = "Clic en 'Login' para iniciar sesion.";
                pom.clickBtnLogin();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                state = "Validar que aparezca la alerta de error.";
                Assert.IsTrue(pom.errorAlRegistrar(), "La alerta no se mostró.");
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);
                extentTest.Log(Status.Pass, "La validación de iniciar sesion incorrectamente es exitosa.");
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }
    }
}
