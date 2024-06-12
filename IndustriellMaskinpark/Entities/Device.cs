namespace IndustriellMaskinpark.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public List<DeviceSensorReading> SensorReadings { get; set; } = new List<DeviceSensorReading>();
    }
}
