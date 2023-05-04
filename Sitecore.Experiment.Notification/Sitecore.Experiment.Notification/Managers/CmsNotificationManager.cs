namespace Sitecore.Experiment.Notification.Managers
{
    using Sitecore.Events;
    using Sitecore.Experiment.Notification.Models;
    using Sitecore.Web.UI.Sheer;
    using System;

    public class CmsNotificationManager
    {
        private static bool _initialized;

        private static readonly object globalLock = new object();

        public static void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            lock (globalLock)
            {
                if (_initialized)
                {
                    return;
                }

                try
                {
                    Event.Subscribe("cms:notify", new EventHandler(CmsNotifier));
                }
                finally
                {
                    _initialized = true;
                }
            }
        }

        private static void CmsNotifier(object sender, EventArgs args)
        {
            var parameters = Event.ExtractParameter<NotifierArgs>(args, 0);

            var message = string.Empty;

            switch (parameters.EventName)
            {
                case "package:end":
                    {
                        message = "The package installation has completed";

                        break;
                    }
                case "item:save":
                    {
                        message = "The item has been saved";

                        break;
                    }
            }

            var script = $"toastr.info('{message}')";

            SheerResponse.Eval(script);
        }
    }
}