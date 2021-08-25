using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace SalesWebMvc.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            StiReport report = new StiReport();
            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}
