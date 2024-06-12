namespace IndustriellMaskinpark.Entities
{
    public class DeviceSensorReading
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
