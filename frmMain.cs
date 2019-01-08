using System.Text;
using System.Windows.Forms;

namespace YunDictionary
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    if (webBrowser1.Url == new System.Uri("about:blank"))
                    {
                        webBrowser1.Url = new System.Uri("http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain");
                    }
                    else
                    {
                        webBrowser1.Url = new System.Uri("about:blank");
                        FillDocument();
                    }
                    break;
            }
        }

        private void frmMain_Shown(object sender, System.EventArgs e)
        {

            //http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain
            webBrowser1.Url = new System.Uri("http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain");

        }

        private void FillDocument()
        {
            webBrowser1.DocumentText = string.Empty;

            StringBuilder sb = new StringBuilder();
            //postcode.map.daum.net/guide
            sb.Append("<!DOCTYPE HTML>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title></title>");
            sb.Append("<link rel='stylesheet' href='http://dmaps.daum.net/s1.daumcdn.net/svc/attach/U03/cssjs/postcode/1512713799440/guide.v2.min.css' />");
            sb.Append("<script src='http://dmaps.daum.net/map_js_init/postcode.v2.js'></script>");

            sb.Append("</head>");

            //sb.Append("<body>");
            sb.Append("<body onload='execDaumPostcode()'>");
            //sb.Append("<input type='text' name='userName'/><br/>");
            //sb.Append("<input type='text' id='postCode' placeholder='우편번호'>");
            //sb.Append("<input type='button' onclick='execDaumPostcode()' value='우편번호 찾기'><br>");
            sb.Append("<div id='wrap' style='display:block;border:0px solid;width:397px;height:490px; margin:-5px; position:relative;'></div>");

            sb.Append("<script>");
            sb.Append("var element_wrap=document.getElementById('wrap');");

            sb.Append("function execDaumPostcode(){");
            sb.Append(" new daum.Postcode({");
            sb.Append("     oncomplete:function(data){");
            sb.Append("         element_wrap.style.display='none';");
            sb.Append("     },");
            sb.Append("     onresize:function(size){");
            sb.Append("         element_wrap.style.height=size.height+'px';");
            sb.Append("     },");
            sb.Append("     width:'100%',");
            sb.Append("     height:'100%'");
            sb.Append(" }).embed(element_wrap);");
            sb.Append(" element_wrap.display='block';");
            sb.Append("}");
            sb.Append("</script>");

            sb.Append("</body>");
            sb.Append("</html>");

            webBrowser1.DocumentText = sb.ToString();
        }
    }
}
