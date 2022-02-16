using BoletoNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Treino.Web.Utils;

namespace Treino.Web.Controllers
{
    public class BoletoController : Controller
    {
        public IBanco _banco;

        public BoletoController()
        {
            
        }
        // GET: BoletoController
        public ActionResult Index()
        {
            var contaBancaria = new ContaBancaria
            {
                Agencia = "1234",
                DigitoAgencia = "X",
                Conta = "123456",
                DigitoConta = "X",
                CarteiraPadrao = "09",
                TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa
            };
            _banco = Banco.Instancia(Bancos.Bradesco);
            _banco.Beneficiario = BoletoCriacao.GerarBeneficiario("1213141", "", "", contaBancaria);
            _banco.FormataBeneficiario();

            var html = $"<html><title>PDF</title><body><b>{_banco.Nome} {contaBancaria}</b></body></html>";


            var htmlToPdf = new HtmlToPDFCore.HtmlToPDF();
            var pdf = htmlToPdf.ReturnPDF(html);

            FileStream fs = new FileStream("teste1.pdf", FileMode.CreateNew);
            fs.Write(pdf, 0, pdf.Length);
            fs.Close();

            return View(fs);
        }

        // GET: BoletoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoletoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoletoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoletoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoletoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}