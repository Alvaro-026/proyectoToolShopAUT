using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using proyectoToolShopDemo.PageObject;

namespace proyectoToolShopDemo.Test
{
    [TestFixture]
    public class CarritoTest : BaseTest
    {
        public CarritoTest() : base("CarritoPage.html")
        {
            // Función para pasar el nombre del reporte a nivel herencia
        }
        /*
                [Test]
                public void validarClickIconoCarrito()
                {
                    extentTest = extent.CreateTest("Validación de ingresar al carrito exitosa.");

                    var pom = new CarritoPage(Driver);
                    pom.GoTo();
                    pom.irAlProducto();
                    pom.agregarAlCarrito();
                    Thread.Sleep(3000);
                    pom.irAlCarrito();
                    Thread.Sleep(3000);

                     extentTest.Log(AventStack.ExtentReports.Status.Pass, "Se Ingresan correctamente.");

                }*/

        [Test]
        public void validarClickIconoCarrito()
        {
            extentTest = extent.CreateTest("Validación de ingreso al carrito exitosa.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar a la página del carrito.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                pom.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito.";
                pom.agregarAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);
                Thread.Sleep(4000);

                extentTest.Log(Status.Pass, "La navegación al carrito se realizó correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickIconoCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickIconoCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarAgregarProductoDentroDelCarrito()
        {
            extentTest = extent.CreateTest("Validación de ingreso al carrito exitosa.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar a la página del carrito.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto seleccionado aleatoriamente y agregarlo al carrito.";
                Random rnd = new Random();
                int repeticiones = rnd.Next(1, 6); // 6 es exclusivo, así que va del 1 al 5
                Console.WriteLine($"Se agregarán {repeticiones} productos aleatorios al carrito.");
                extentTest.Log(Status.Pass, state);

                for (int i = 0; i < repeticiones; i++)
                {
                    Console.WriteLine($"Agregando producto #{i + 1}...");
                    pom.seleccionarYPresionarCardAleatorio();
                    pom.productoEstaAgotado();
                    pom.agregarAlCarritoSiEsta();
                    Thread.Sleep(3000);
                    pom.volverHome();
                }

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Agregar o disminuir la catidad de un producto aleatorio.";
                int cantidad = rnd.Next(1, 21);
                pom.insertarCantidadEnInputAleatorio($"{cantidad}");
                extentTest.Log(Status.Pass, state);

                state = "Eliminar un producto aleatorio.";
                pom.presionarBotonEliminarAleatorio();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                extentTest.Log(Status.Pass, "La validacion al agregar,elegir cantidad y eliminar un producto del carrito es exitosa.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarAgregarProductoDentroDelCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarAgregarProductoDentroDelCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarClickPasarPorCaja()
        {
            extentTest = extent.CreateTest("Validación de flujo hasta pasar por caja.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar al producto.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                pom.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito.";
                pom.agregarAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                state = "Clic en pasar por caja.";
                pom.clickPasarPorCaja();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(3000);

                extentTest.Log(Status.Pass, "Se navegó correctamente hasta pasar por caja.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarClickPasarPorCaja");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarClickPasarPorCaja");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarLoginErroneoCarrito()
        {
            extentTest = extent.CreateTest("Validación de login erróneo desde el carrito.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar al producto.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                pom.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito.";
                pom.agregarAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Clic en pasar por caja.";
                pom.clickPasarPorCaja();
                extentTest.Log(Status.Pass, state);

                state = "Agregar email incorrecto.";
                pom.agregarEmailCarrito("alvaro2602.am5@gmail.com");
                extentTest.Log(Status.Pass, state);

                state = "Agregar contraseña incorrecta.";
                pom.agregarPasswordCarrito("mrAL620...");
                extentTest.Log(Status.Pass, state);

                state = "Clic en botón login.";
                pom.clickBtnLoginCarrito();
                extentTest.Log(Status.Pass, state);

                string mensajeError = pom.obteniendoAlertaError();
                extentTest.Log(Status.Info, $"Mensaje de error capturado: {mensajeError}");

                Assert.That(mensajeError, Is.EqualTo("Invalid email or password"));

                Thread.Sleep(3000);

                extentTest.Log(Status.Pass, "Login erróneo validado correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarLoginErroneoCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarLoginErroneoCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarLoginCorrectoCarrito()
        {
            extentTest = extent.CreateTest("Validación de login correcto desde el carrito.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar al producto.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                pom.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito.";
                pom.agregarAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Clic en pasar por caja.";
                pom.clickPasarPorCaja();
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
                pom.agregarEmailFormulario("alvaro26@gmail.com");
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

                Thread.Sleep(2000);

                extentTest.Log(Status.Pass, "Login correcto validado correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarLoginCorrectoCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Fallo_validarLoginCorrectoCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }

        [Test]
        public void validarCompraCarrito()
        {
            extentTest = extent.CreateTest("Validación de realizar compra exitosa.");
            string state = "";

            try
            {
                var pom = new CarritoPage(Driver);

                state = "Navegar al producto.";
                pom.GoTo();
                extentTest.Log(Status.Pass, state);

                state = "Ir al producto.";
                pom.irAlProducto();
                extentTest.Log(Status.Pass, state);

                state = "Agregar producto al carrito.";
                pom.agregarAlCarrito();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(7000);

                state = "Ir al carrito.";
                pom.irAlCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Clic en pasar por caja.";
                pom.clickPasarPorCaja();
                extentTest.Log(Status.Pass, state);

                state = "Agregar email correcto.";
                pom.agregarEmailCarrito("alvaro26020@gmail.com");
                extentTest.Log(Status.Pass, state);

                state = "Agregar contraseña correcta.";
                pom.agregarPasswordCarrito("mrAL620....");
                extentTest.Log(Status.Pass, state);

                state = "Clic en botón login.";
                pom.clickBtnLoginCarrito();
                extentTest.Log(Status.Pass, state);

                state = "Verificar si hay errores al iniciar sesion.";
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

                state = "Clic en botón pasar por la caja.";
                pom.clickBtnPasarPorLaCaja();
                extentTest.Log(Status.Pass, state);

                Thread.Sleep(2000);

                state = "Validar que los campos no estén vacíos.";
                bool camposValidos = pom.validarInputsNoVacios();
                Assert.IsTrue(camposValidos, "Uno o más campos están vacíos.");
                extentTest.Log(Status.Pass, state);

                extentTest.Log(Status.Pass, "Todos los campos del formulario tienen valor.");

                state = "Clic en botón pasar por la caja de afirmacion.";
                pom.clickBtnPasarPorLaCajaAfirmacion();
                extentTest.Log(Status.Pass, state);

                state = "Agregar tipo de pago.";
                pom.agregarTipoPago("Cash on Delivery");
                extentTest.Log(Status.Pass, state);

                state = "Clic en botón de afirmacion para realizar la compra.";
                pom.clickBtnAfirmacionCompra();
                extentTest.Log(Status.Pass, state);

                state = "Verificar si la compra se realizo correctamente.";
                bool compraCorrecta = pom.alertaCompraExitosa();

                if (compraCorrecta)
                {
                    extentTest.Log(Status.Pass, "Se mostró una alerta de exito en la compra.");
                }
                else
                {
                    extentTest.Log(Status.Fail, "No se mostró la alerta de exito en la compra.");
                }

                Thread.Sleep(3000);

                extentTest.Log(Status.Pass, "Compra en el carrito validado correctamente.");
            }
            catch (AssertionException ex)
            {
                tomarCaptura("Fallo_validarCompraCarrito");
                extentTest.Log(Status.Fail, $"Fallo en la prueba: {state}. Detalles: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                tomarCaptura("Error_validarCompraCarrito");
                extentTest.Log(Status.Fail, $"Error inesperado en la prueba: {state}. Detalles: {ex.Message}");
                Assert.Fail($"Error inesperado en la prueba: {state}", ex);
            }
        }




    }
}
