namespace Sitecore.Experiment.Notification.Events
{
    using Sitecore.Events;
    using Sitecore.Install.Events;
    using System;

    public class PackageInstallationEvent
    {
        public void OnPackageInstallItemsEndHandler(object sender, EventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var sitecoreEventArgs = e as SitecoreEventArgs;

            if (sitecoreEventArgs == null || sitecoreEventArgs.Parameters == null || sitecoreEventArgs.Parameters.Length != 1)
            {
                return;
            }

            var parameter = sitecoreEventArgs.Parameters[0] as InstallationEventArgs;

            if (parameter == null || parameter.ItemsToInstall == null)
            {
                return;
            }                     

            Context.ClientPage.ClientResponse.Eval("scForm.postMessage(\"" + ("cms:notification(eventName=package:end)") + "\")");
        }
    }
}
