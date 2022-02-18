using System.Web.Mvc;

namespace Treino.WebReportViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pessoaDataSet = new Models.PessoasDataSet();
            pessoaDataSet.Pessoa.AddPessoaRow("1", "Lima", "Sales");
            pessoaDataSet.Pessoa.AddPessoaRow("2", "Vane", "Ramalho");
            pessoaDataSet.Pessoa.AddPessoaRow("3", "Linda", "Fagunde");

            var viewer = new Microsoft.Reporting.WebForms.ReportViewer();
            viewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\RelatorioListaPessoas.rdlc";
            viewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PessoaDataSet", (System.Data.DataTable)pessoaDataSet.Pessoa));

            viewer.SizeToReportContent = true;
            viewer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            viewer.Height = System.Web.UI.WebControls.Unit.Percentage(100);

            ViewBag.ReportViewer = viewer;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}