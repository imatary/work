using System.Threading;
using System.Web;

namespace OQC.Web.Core
{
    public static class UsingTimer
    {
        private static Timer threadingTimer;

        public static void StartTimer()
        {
            if (threadingTimer == null)
            {
                //raise timer callback every 5 minutes
                threadingTimer = new Timer(new TimerCallback(CheckData),
                                          HttpContext.Current, 5 * 60000, 5 * 60000);
            }
        }
        /// <summary>
        /// Sau 5 phút hàm sẽ được gọi
        /// </summary>
        /// <param name="sender"></param>
        private static void CheckData(object sender)
        {
            // Code here
            // Làm bất cứ thứ gì bạn thích ở đây
            //string item = HttpContext.Current.Application.Count.ToString();
            //HttpContext.Current.Response.Write(item);
            
        }
    }
}
