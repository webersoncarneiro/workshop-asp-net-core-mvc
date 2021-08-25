using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;
using SalesWebMvc.Data;
using System.Data;
using System.Data.SqlClient;


namespace SalesWebMvc.Controllers
{
    public class ViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/relatorio_teste.mrt"));
            DataSet dataSet = new DataSet("dataSet");
            DataTable dataTable = new DataTable("Gastos");
            string sql = @"select CONVERT(VARCHAR(10),Data,103) as Data
                 ,Area
                 ,FORMAT(VALOR, 'c', 'pt-BR') as Valor
                from Gastos";
            dataTable = data.retornaDataTable<SqlConnection>(sql);
            dataSet.Tables.Add(dataTable);
            report.RegData("dataSet", "dataSet", dataSet);
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public ActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
