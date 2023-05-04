namespace Sitecore.Experiment.Notification
{
    using Sitecore.Data.Events;
    using Sitecore.Events;
    using Sitecore.Experiment.Notification.Models;
    using Sitecore.Shell.Applications.ContentManager;
    using Sitecore.Web.UI.Sheer;
    using System;

    public class ContentEditorExtension : ContentEditorForm
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var site = Client.Site;

            site.Notifications.ItemSaved += new ItemSavedDelegate(this.CmsNotification);
        }

        private void CmsNotification(object sender, ItemSavedEventArgs args)
        {
            var model = new NotifierArgs
            {
                EventName = "item:save"
            };

            Event.RaiseEvent("cms:notify", model);
        }

        public override void HandleMessage(Message message)
        {
            base.HandleMessage(message);

            var model = new NotifierArgs
            {
                EventName = message.Arguments["eventName"]
            };

            switch (message.Name)
            {
                case "cms:notification":
                    {
                        Event.RaiseEvent("cms:notify", model);
                        break;
                    }
            }
        }
    }
}
