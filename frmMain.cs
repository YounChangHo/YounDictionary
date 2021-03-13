using System;
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
                case Keys.F2:
                    if (webBrowser1.Url == new System.Uri("about:blank"))
                    {
                        webBrowser1.ScrollBarsEnabled = true;
                        //webBrowser1.Url = new System.Uri("http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain");
                        webBrowser1.Url = new System.Uri("https://en.dict.naver.com/#/mini/main");
                        this.Text = "Youn's 영어사전";
                    }
                    else if (webBrowser1.Url == new System.Uri("https://en.dict.naver.com/#/mini/main"))
                    {
                        webBrowser1.ScrollBarsEnabled = true;
                        webBrowser1.Url = new System.Uri("https://hanja.dict.naver.com/small");
                        this.Text = "Youn's 한자사전";
                    }
                    else if (webBrowser1.Url == new System.Uri("https://hanja.dict.naver.com/small"))
                    {
                        webBrowser1.ScrollBarsEnabled = true;
                        webBrowser1.Url = new System.Uri("http://www.thecall.co.kr");
                        this.Text = "Youn's 스팸번호";
                    }
                    else if (webBrowser1.Url.Host == new System.Uri("http://www.thecall.co.kr").Host)
                    {
                        //host : www.thecall.co.kr
                        webBrowser1.ScrollBarsEnabled = false;
                        //webBrowser1.Url = new System.Uri("https://hanja.dict.naver.com/");
                        webBrowser1.Url = new System.Uri("https://fast.com/ko/");
                        this.Text = "Youn's 속도테스트";
                    }
                    //else if (webBrowser1.Url.Host == new System.Uri("https://hanja.dict.naver.com/").Host)
                    //{
                    //    //host : www.thecall.co.kr
                    //    //size 조정?  
                    //    webBrowser1.ScrollBarsEnabled = false;
                    //    webBrowser1.Url = new System.Uri("https://fast.com/ko/");
                    //    this.Text = "Youn's 속도테스트";
                    //}
                    else
                    {
                        webBrowser1.ScrollBarsEnabled = false;

                        webBrowser1.Url = new System.Uri("about:blank");
                        FillDocument();
                        this.Text = "Youn's 우편번호";
                    }
                    break;
            }
        }

        private void frmMain_Shown(object sender, System.EventArgs e)
        {
            webBrowser1.ScrollBarsEnabled = true;

            //http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain
            //webBrowser1.Url = new System.Uri("http://endic.naver.com/popManager.nhn?sLn=kr&m=miniPopMain");
            webBrowser1.Url = new System.Uri("https://en.dict.naver.com/#/mini/main");
            //webBrowser1.Url = new System.Uri("http://www.thecall.co.kr");
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
            //sb.Append("<script src='http://dmaps.daum.net/map_js_init/postcode.v2.js'></script>");
            sb.Append("<script src='http://t1.daumcdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js'></script>");

            sb.Append("</head>");

            //sb.Append("<body>");
            sb.Append("<body onload='execDaumPostcode()'>");
            //sb.Append("<input type='text' name='userName'/><br/>");
            //sb.Append("<input type='text' id='postCode' placeholder='우편번호'>");
            //sb.Append("<input type='button' onclick='execDaumPostcode()' value='우편번호 찾기'><br>");
            sb.Append("<div id='wrap' style='display:block;border:0px solid;width:397px;height:500px; margin:-5px; position:relative;'></div>");

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

        //private void FillDocument(string str)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(str);

        //    string sText = @"</title>";
        //    int n = sb.ToString().IndexOf(sText);
        //    int l = sText.Length;

        //    //<meta http-equiv="X-UA-Compatible" content="IE=11" >
        //    string mText = "<meta http-equiv=\"X - UA - Compatible\" content=\"IE = 11\" >";
        //    sb.Insert(n + l, mText);

        //    webBrowser1.DocumentText = string.Empty;
        //    webBrowser1.DocumentText = sb.ToString();
        //}

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            // 브라우저 버전문제 해결 
            //Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION",
            //  Application.ProductName + ".exe", 10001);

            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";

            using (var Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            {
                if (Key.GetValue(appName) != null && Convert.ToInt32(Key.GetValue(appName)).Equals(99999))
                    return;
                
                Key.SetValue(appName, 99999, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }
    }
}
