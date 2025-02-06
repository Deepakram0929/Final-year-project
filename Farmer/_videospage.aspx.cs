using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace cropPrediction.Farmer
{
    public partial class _videospage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string path = "~/Videos/v1.mp4";
            //Page.Controls.Add(new LiteralControl("<video width='320' height='240' controls='controls'><source src=" + path + " type='Example/video/mp4'></video>"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path1 = "V1-1.m4v";
            string path2 = "V2-1.m4v";
            path1 = path1.Replace(" ", "");
            path2 = path2.Replace(" ", "");
            //FileUpload1.SaveAs(Server.MapPath("~/Videos/") + path);
            String link1 = "Videos/" + path1;
            String link2 = "Videos/" + path2;
            Literal1.Text = "<video width=400 Controls><Source src=" + link1 + " type=video/mp4></video>";
            Literal2.Text = "<video width=400 Controls><Source src=" + link2 + " type=video/mp4></video>";
        }
    }
}