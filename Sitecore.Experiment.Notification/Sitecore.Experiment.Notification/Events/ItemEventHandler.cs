using Sitecore.Diagnostics;
using System;

namespace Sitecore.Experiment.Notification.Events
{
    public class ItemEventHandler
    {
        public void OnItemSaved(object sender, EventArgs e)
        {
            try
            {
                if (Context.ClientPage != null && Context.ClientPage != null && Context.ClientPage.ClientResponse != null)
                {
                    Context.ClientPage.ClientResponse.Eval("scContent.postMessage(\"" + ("cms:notification(eventName=item:saved)") + "\")");
                }
            }
            catch(Exception ex)
            {
                Log.Error($"[NOTIFICATION] Error on event handler.\n\n\rMessage: {ex.Message}.\n\n\rStackTrace: {ex.StackTrace}", this);
            }
        }
    }
}
