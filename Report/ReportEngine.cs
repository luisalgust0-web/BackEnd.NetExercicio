namespace WebExercicios.Report;

using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating; // For extension methods.

public class ReportEngine
{

    private IWebHostEnvironment _webHostEnvironment;

    public ReportEngine(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public object GerarReport()
    {
        string path = Path.Combine(this._webHostEnvironment.ContentRootPath, "Report/Templates/RelatorioAluguel.cshtml");
        string templateCshtml = System.IO.File.ReadAllText(path);
        var viewBag = new DynamicViewBag();

        var teste = new Teste{Nome = "Luis"};
        
        string template = "Hello  welcome to RazorEngine!";

        var config = new TemplateServiceConfiguration();
// .. configure your instance

        var service = RazorEngineService.Create(config);

        Engine.Razor = service;

        var result = Engine.Razor.RunCompile(templateCshtml, typeof(Teste), teste, null);

        return null;
    }
}

class Teste {
    public string Nome { get; set; } 
}
