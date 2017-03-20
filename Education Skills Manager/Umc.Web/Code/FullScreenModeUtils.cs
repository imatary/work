using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using DevExpress.Web.Internal;
using DevExpress.XtraPrinting.BarCode;

namespace Umc.Web {
    public class FullScreenModeResolution {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public static class FullScreenModeUtils {
        public static readonly string FullScreenViewerUrl = "~/UserControls/FullScreenViewer.aspx";
        public static readonly string FullScreenViewerQRCodeUrl = "~/UserControls/FullScreenViewerQRCode.aspx";

        static List<FullScreenModeResolution> resolutions;

        public static List<FullScreenModeResolution> Resolutions {
            get {
                if(resolutions == null) {
                    resolutions = new List<FullScreenModeResolution>();
                    resolutions.Add(new FullScreenModeResolution { Name = "Fullscreen", Width = 0, Height = 0 });
                    resolutions.Add(new FullScreenModeResolution { Name = "1200x800", Width = 1200, Height = 800 });
                    resolutions.Add(new FullScreenModeResolution { Name = "800x1200", Width = 800, Height = 1200 });
                    resolutions.Add(new FullScreenModeResolution { Name = "768x576", Width = 768, Height = 576 });
                    resolutions.Add(new FullScreenModeResolution { Name = "576x768", Width = 576, Height = 768 });
                }
                return resolutions;
            }
        }
        public static string GetUrl(Page page, string targetUrl, int width, int height) {
            string url = FullScreenViewerUrl;
            if(!string.IsNullOrEmpty(targetUrl)) {
                url += "?url=" + page.ResolveUrl(targetUrl);
                if(width > 0)
                    url += "&width=" + width.ToString();
                if(height > 0)
                    url += "&height=" + height.ToString();
            }
            return url;
        }
        public static string GetQRCodeImageUrl(Page page, string url) {
            return string.Format("{0}?url={1}", page.ResolveUrl(FullScreenViewerQRCodeUrl), page.ResolveUrl(url));
        }
        public static System.Drawing.Image GetQRCodeImage(string url) {
            const int imageSize = 120;
            HttpRequest request = HttpUtils.GetRequest();
            string resolvedUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, url);

            var image = new Bitmap(imageSize, imageSize);
            using(var graphicsObj = Graphics.FromImage(image)) {
                var gdiGraphics = new DevExpress.XtraPrinting.GdiGraphicsWrapper(graphicsObj);
                var qrcode = new QRCodeGenerator() { CompactionMode = QRCodeCompactionMode.Byte };
                var rectf = new RectangleF(0, 0, imageSize, imageSize);
                var barcodeData = new QRBarCodeData(resolvedUrl);
                qrcode.DrawContent(gdiGraphics, rectf, barcodeData);
            }
            return image;
        }
    }

    public class QRBarCodeData : IBarCodeData {
        readonly string text;
        readonly DevExpress.XtraPrinting.BrickStyle style;

        public QRBarCodeData(string text) {
            this.text = text;
            this.style = new DevExpress.XtraPrinting.BrickStyle {
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Padding = new DevExpress.XtraPrinting.PaddingInfo()
            };
        }

        DevExpress.XtraPrinting.TextAlignment IBarCodeData.Alignment { get { return DevExpress.XtraPrinting.TextAlignment.MiddleCenter; } }
        bool IBarCodeData.AutoModule { get { return true; } }
        double IBarCodeData.Module { get { return 3.0; } }
        BarCodeOrientation IBarCodeData.Orientation { get { return BarCodeOrientation.Normal; } }
        bool IBarCodeData.ShowText { get { return false; } }
        DevExpress.XtraPrinting.BrickStyle IBarCodeData.Style { get { return style; } }
        string IBarCodeData.Text { get { return text; } }
    }
}
