using Sitecore.Experiment.Notification.Managers;
using Sitecore.Pipelines;

namespace Sitecore.Experiment.Notification.Initializers
{
    public class InitializeCmsNotification
    {
        public void Process(PipelineArgs args) => CmsNotificationManager.Initialize();
    }
}
