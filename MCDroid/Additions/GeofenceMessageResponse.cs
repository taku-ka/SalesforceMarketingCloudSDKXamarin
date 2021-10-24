namespace Com.Salesforce.Marketingcloud.Messages.Geofence
{
    public partial class GeofenceMessageResponse
    {
        public global::Com.Salesforce.Marketingcloud.Location.LatLon RefreshCenter => InvokeRefreshCenter();

        public int RefreshRadius => InvokeRefreshRadius();
    }
}
