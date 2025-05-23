
using AventStack.ExtentReports;
using proyectoToolShopDemo.PageObject;

namespace proyectoToolShopDemo.Test
{


    // Marca esta clase como una clase de pruebas de NUnit
    [TestFixture]
    public class ArticuloTest : BaseTest
    {
        // Constructor: envía el nombre del archivo de reporte al constructor base
        public ArticuloTest() : base("ArticuloPage.html")
        {
            // Función para pasar el nombre del reporte a nivel herencia
        }


        [Test]
        public void validarClickAumentarDisminuir()
        {
            extentTest = extent.CreateTest("Validación de aumentar y disminuir producto Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página de producto.";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Seleccionar un producto.";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Aumentar cantidad del producto.";
                articuloPage.clickAumentar();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                state = "Disminuir cantidad del producto.";
                articuloPage.clickDisminuir();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Interacción con botones de cantidad realizada correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickAumentarDisminuir");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickAumentarDisminuir");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }


        [Test]
        public void validarClickFavoritos()
        {
            extentTest = extent.CreateTest("Validación de favoritos Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página de producto.";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Seleccionar un producto.";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Hacer clic en favoritos.";
                articuloPage.clickFavoritos();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Producto agregado correctamente a favoritos.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickFavoritos");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickFavoritos");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarValorInput()
        {
            extentTest = extent.CreateTest("Validación del número del input Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página del artículo.";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Seleccionar un producto.";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Aumentar valor del input 5 veces.";
                for (int i = 0; i < 5; i++)
                {
                    articuloPage.clickAumentar();
                    Thread.Sleep(500);
                }
                extentTest.Log(Status.Pass, state);

                state = "Obtener valor actual del input.";
                var valor = articuloPage.saberValorInput();
                extentTest.Log(Status.Info, $"Valor actual en el input: {valor}");

                Thread.Sleep(2000);
                extentTest.Log(Status.Pass, "Valor del input validado correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarValorInput");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarValorInput");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }


        [Test]
        public void validarClickCarrito()
        {
            extentTest = extent.CreateTest("Validación de presionar el botón 'Agregar al carrito' Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página del artículo.";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Seleccionar un producto.";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Hacer clic en 'Agregar al carrito'.";
                articuloPage.clickInsertarCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Verificar si el ícono del carrito es visible.";
                bool carrito = articuloPage.visualizarIconoCarrito();

                if (carrito)
                {
                    Console.WriteLine("El ícono del carrito está visible.");
                    extentTest.Log(Status.Pass, "El ícono del carrito está visible.");
                }
                else
                {
                    Console.WriteLine("El ícono del carrito NO está visible.");
                    extentTest.Log(Status.Fail, "El ícono del carrito NO está visible.");
                }

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Producto agregado correctamente al carrito.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarVisualizacionCarrito()
        {
            extentTest = extent.CreateTest("Validación de la visualización del carrito incorrecta Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página del artículo.";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Verificar si el ícono del carrito es visible.";
                bool carrito = articuloPage.visualizarIconoCarrito();

                if (carrito)
                {
                    Console.WriteLine("El ícono del carrito está visible.");
                    extentTest.Log(Status.Fail, "El ícono del carrito está visible.");
                }
                else
                {
                    Console.WriteLine("El ícono del carrito NO está visible.");
                    extentTest.Log(Status.Pass, "El ícono del carrito NO está visible.");
                }

                Thread.Sleep(2000);
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Fallo_VisualizacionCarrito");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Error_VisualizacionCarrito");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

       /* [Test]
        public void validarVisualizacionCarritoCorrecta()
        {
            extentTest = extent.CreateTest("Validación de la visualización del carrito Exitosa.");
            string state = "";

            try
            {
                var articuloPage = new ArticuloPage(Driver);

                state = "Ir a la página del artículo";
                articuloPage.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto";
                articuloPage.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito";
                articuloPage.clickInsertarCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Verificar si el ícono del carrito es visible";
                bool carrito = articuloPage.visualizarIconoCarrito();

                if (carrito)
                {
                    Console.WriteLine("El ícono del carrito está visible.");
                    extentTest.Log(Status.Pass, "El ícono del carrito está visible.");
                }
                else
                {
                    Console.WriteLine("El ícono del carrito NO está visible.");
                    extentTest.Log(Status.Fail, "El ícono del carrito NO está visible.");
                }

                Thread.Sleep(2000);
            }
            catch (AssertionException ex)
            {
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Fallo_VisualizacionCarrito");
                throw;
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                tomarCaptura("Error_VisualizacionCarrito");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }*/


    }
}
