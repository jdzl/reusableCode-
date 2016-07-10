/*
	nuged console 
	PM> Install-Package DotNetZip

*/

// model use
using Ionic.Zip;
using System.Collections.Generic;
using System.Web.Mvc;

namespace namespace.Models
{
    public class ZipResult : ActionResult
    {
        private IEnumerable<string> _files;
        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName ?? "Imagenes.zip";
            }
            set { _fileName = value; }
        }

        public ZipResult(params string[] files)
        {
            this._files = files;
        }

        public ZipResult(IEnumerable<string> files)
        {
            this._files = files;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            using (ZipFile zf = new ZipFile())
            {
                zf.AddFiles(_files, false, "");
                context.HttpContext
                    .Response.ContentType = "application/zip";
                context.HttpContext
                    .Response.AppendHeader("content-disposition", "attachment; filename=" + FileName);
                zf.Save(context.HttpContext.Response.OutputStream);
            }
        }

    }
}

//controller

public ActionResult Descargar()
        {
            return new ZipResult(
                Server.MapPath("/fotos/asd.txt"),     
                Server.MapPath("/fotos/asd2.txt")
            );
        }



//View 
/*
<li>@Html.ActionLink("Descargar", "Descargar", "Controller")</li>
*/