using CoreProject.ToDo.BusinessLayer.Interfaces;
using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getProcessAppUserId")]
    public class ProcessAppUserIdTagHelper : TagHelper
    {
        private readonly IProcessService _processService;
        public ProcessAppUserIdTagHelper(IProcessService processService)
        {
            _processService = processService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Process> listprocess = _processService.GetWithAppUserId(AppUserId);
            int finishedProcess = listprocess.Where(I => I.Status).Count();
            int continueProcess = listprocess.Where(I => !I.Status).Count();

            string htmlstring = $"<strong>Tamamlanan görev sayısı :</strong>{finishedProcess} <br> <strong>Üstünde çalıştığı görev sayısı :</strong>{continueProcess}";
            output.Content.SetHtmlContent(htmlstring);
        }
    }
}
