namespace Com.Salesforce.Marketingcloud.Messages.Proximity
{
    public partial class ProximityMessageResponse
    {
        public global::Com.Salesforce.Marketingcloud.Location.LatLon RefreshCenter => InvokeRefreshCenter();

        public int RefreshRadius => InvokeRefreshRadius();
    }
}
