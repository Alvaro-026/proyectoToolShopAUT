using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace proyectoToolShopDemo.Test
{

    // Marca esta clase como una clase de pruebas de NUnit
    [TestFixture]
    public class HomeTest : BaseTest
    {
        // Constructor: envía el nombre del archivo de reporte al constructor base
        public HomeTest() : base("HomePage.html")
        {
            // Función para pasar el nombre del reporte a nivel herencia
        }

        // === Test para verificar que el login con credenciales válidas funciona correctamente ===
        [Test]
        public void ingresarAProducto()
        {
            extentTest = extent.CreateTest("Validación de ingresar Exitoso.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Hacer clic en un producto.";
                home.clickProducto();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Se realizó correctamente la navegación.");
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Fallo_IngresarProducto");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Error_IngresarProducto");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }


        [Test]
        public void validarLogo()
        {
            extentTest = extent.CreateTest("Validación del logo Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                state = "Hacer clic en el logo.";
                home.clickLogo();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                extentTest.Log(Status.Pass, "Se realizó correctamente la navegación.");
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Fallo_ValidarLogo");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Error_ValidarLogo");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }


        [Test]
        public void validarProductosVisiblesYCantidad()
        {
            extentTest = extent.CreateTest("Validación de productos visibles y cantidad Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Esperar productos visibles.";
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElements(By.CssSelector(".card")).Count > 0);
                extentTest.Log(Status.Pass, state);

                state = "Verificar si hay productos visibles.";
                bool hayProductos = home.hayProductosVisibles();
                extentTest.Log(Status.Pass, $"{state}: {hayProductos}");
                Assert.IsTrue(hayProductos, "No se encontraron productos visibles en la página de inicio.");

                state = "Obtener cantidad de productos.";
                int cantidadProductos = home.obtenerCantidadDeProductos();
                extentTest.Log(Status.Pass, $"{state}: {cantidadProductos}");
                Assert.Greater(cantidadProductos, 0, "No se encontraron productos en la página de inicio.");

                extentTest.Log(Status.Pass, "Productos visibles y cantidad correctamente validados.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_ProductosVisibles");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_ProductosVisibles");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarClickSiguienteAnterior()
        {
            extentTest = extent.CreateTest("Validación de los btn siguiente y anterior Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                state = "Hacer clic en botón Siguiente.";
                home.clickSiguiente();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);
                
                state = "Hacer clic en botón Anterior.";
                home.clickAnterior();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Navegación con botones Siguiente y Anterior realizada correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_ValidarClickSiguienteAnterior");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_ValidarClickSiguienteAnterior");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarNavegacionPorTodasLasPaginas()
        {
            extentTest = extent.CreateTest("Validación de navegar por todas las páginas Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                int numeroPagina = 1;
                bool paginaExiste = true;

                while (paginaExiste)
                {
                    state = $"Hacer clic en la página {numeroPagina}";
                    paginaExiste = home.ClickEnPaginaSiExiste(numeroPagina);
                    if (paginaExiste)
                    {
                        extentTest.Log(Status.Pass, state);
                        Thread.Sleep(2000);
                        numeroPagina++;
                    }
                    else
                    {
                        extentTest.Log(Status.Pass, $"No existe la página {numeroPagina}, finalizando navegación.");
                    }
                }

                extentTest.Log(Status.Pass, $"Se recorrieron {numeroPagina - 1} páginas de productos correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_ValidarNavegacionPorTodasLasPaginas");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_ValidarNavegacionPorTodasLasPaginas");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarNavegacionEligiendoNumero()
        {
            extentTest = extent.CreateTest("Validación navegación por número Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                int numeroPagina = 4;
                state = $"Navegar a la página número {numeroPagina}";
                bool navego = home.ClickEnPaginaSiExiste(numeroPagina);
                Assert.IsTrue(navego, $"La página número {numeroPagina} no existe.");
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Navegación por número realizada correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_ValidarNavegacionEligiendoNumero");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_ValidarNavegacionEligiendoNumero");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarClickCategoria()
        {
            extentTest = extent.CreateTest("Validación de click en categoría Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                state = "Hacer click en categoría.";
                home.clickCategoria();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                state = "Hacer click en subcategoría.";
                home.clickSubCategoria();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(5000);

                state = "Hacer click en siguiente.";
                home.clickSiguiente();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(5000);

                extentTest.Log(Status.Pass, "Navegación por categoría realizada correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickCategoria");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickCategoria");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarClickBuscador()
        {
            extentTest = extent.CreateTest("Validación de búsqueda Exitosa.");
            string state = "";

            try
            {
                var home = new HomePage(Driver);

                state = "Ir a la página principal.";
                home.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Escribir en el buscador: 'Hammer'";
                home.escribirEnElBuscador("Hammer");
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                state = "Hacer click en el buscador.";
                home.clickBuscador();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                extentTest.Log(Status.Pass, "Búsqueda realizada correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickBuscador");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickBuscador");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

    }
}





