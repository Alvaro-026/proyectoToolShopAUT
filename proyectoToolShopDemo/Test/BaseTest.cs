using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using proyectoToolShopDemo.Genericos;

namespace proyectoToolShopDemo.Test
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;


        protected string reportTestPage = "";

        // REPORTE-> Generación de test para crear reportes por cada caso de prueba
        public static ExtentTest extentTest;

        // REPORTE-> Herramienta para generar reportes dinámicos por ejecución
        public static ExtentReports extent;

        // Constructor que recibe el nombre del reporte
        public BaseTest(string pageContext)
        {
            this.reportTestPage = pageContext;
        }

        // Setup que se ejecuta antes de cada test
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = ChromeFactory.CrearDriver(options);
        }

        // TearDown que se ejecuta después de cada test
        [TearDown]
        public void TearDown()
        {
            try
            {
                Driver?.Dispose();
            }
            catch (Exception ex) {

                Console.WriteLine("Fallo el metodo");

                extentTest.Log(AventStack.ExtentReports.Status.Fail, "Error al Navegación Error: " + ex.Message);
                Driver.Close();
                Driver.Quit();
                Assert.Fail(ex.Message); 

            }
        }
        
        // REPORTE-> Se configura el entorno de reportería antes de ejecutar todos los tests
        [OneTimeSetUp]
        public void reportsForTests()
        {
            try
            {
                // Fecha con hora para diferenciar reportes por ejecución
                DateTime today = DateTime.Now;
                string fecha = today.Day + "-" + today.Month + "-" + today.Year + "__" + today.Hour + "" + today.Minute;

                // Inicializa ExtentReports y define el path del archivo de reporte
                extent = new ExtentReports();
                string currectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootName = Directory.GetParent(currectDirectory).Parent.Parent.Parent.FullName;
                string reportFolder = Path.Combine(projectRootName, "Reportes");
                string reportPath = Path.Combine(reportFolder, "_" + fecha + "_" + this.reportTestPage);

                ExtentSparkReporter extentSparkReporter = new ExtentSparkReporter(reportPath);
                extent.AttachReporter(extentSparkReporter);
            }
            catch (Exception ex)
            {
                // REPORTE-> Registra el error si falla la inicialización del reporte
                extentTest.Log(AventStack.ExtentReports.Status.Fail, "Error al Navegación Error : " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        // REPORTE-> Finaliza y guarda el reporte después de ejecutar todos los tests
        [OneTimeTearDown]
        public void reportTearDown()
        {
            try
            {
                extent.Flush(); // Genera el archivo final del reporte
            }
            catch (Exception ex)
            {
                // REPORTE-> Registra el error si falla el guardado del reporte
                extentTest.Log(AventStack.ExtentReports.Status.Fail, "Error al Navegación Error : " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        public void tomarCaptura(string nombre)
        {
            ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string carpeta = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            Directory.CreateDirectory(carpeta); // Asegura que la carpeta exista

            string ruta = Path.Combine(carpeta, $"{nombre}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
          //  screenshot.SaveAsFile("ruta.png", ScreenshotImageFormat.Png);

            extentTest.AddScreenCaptureFromPath(ruta);
        }



    }
}
