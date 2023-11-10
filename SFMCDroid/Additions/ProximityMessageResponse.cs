using Com.Salesforce.Marketingcloud.Location;

namespace Com.Salesforce.Marketingcloud.Messages.Proximity
{
    public partial class ProximityMessageResponse : global::Com.Salesforce.Marketingcloud.Messages.IMessageResponse
    {
        public LatLon RefreshCenter => InvokeRefreshCenter();

        public int RefreshRadius => InvokeRefreshRadius();
    }
}