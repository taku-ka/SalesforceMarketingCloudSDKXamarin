using Com.Salesforce.Marketingcloud.Location;

namespace Com.Salesforce.Marketingcloud.Messages.Geofence
{
    public partial class GeofenceMessageResponse : global::Com.Salesforce.Marketingcloud.Messages.IMessageResponse
    {
        public LatLon RefreshCenter => InvokeRefreshCenter();

        public int RefreshRadius => InvokeRefreshRadius();
    }
}

