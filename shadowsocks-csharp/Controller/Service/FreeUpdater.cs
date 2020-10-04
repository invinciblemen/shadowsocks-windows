using NLog;
using System;
using System.Threading.Tasks;

namespace Shadowsocks.Controller
{
    public class FreeResultEventArgs : EventArgs
    {
        public bool Success;

        public FreeResultEventArgs(bool success)
        {
            this.Success = success;
        }
    }

    public static class FreeUpdater
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static event EventHandler<FreeResultEventArgs> FreeUpdateCompleted;

        public static void ResetEvent()
        {
            FreeUpdateCompleted = null;
        }

        static FreeUpdater()
        {

        }

        public static async Task UpdateFreeConf(ShadowsocksController controller)
        {
            controller.socket.Emit("latest");
            FreeUpdateCompleted?.Invoke(null,new FreeResultEventArgs(true));
        }
    }
}