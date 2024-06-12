using Bogus;
using IndustriellMaskinpark.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustriellMaskinpark.Data
{

    public class SeedData
    {
        private static Faker faker;

        public static async Task InitAsync(MaskinparkDbContext maskinparkDbContext)
        {
            //cancel the seeddata initalization if we have data in tournament database table
            if (await maskinparkDbContext.Devices.AnyAsync())
            {
                return;
            }

            faker = new Faker("sv");

            //generera devices
            var devices = GenerateDevices(100);
            await maskinparkDbContext.AddRangeAsync(devices);

            //save changes to the database
            await maskinparkDbContext.SaveChangesAsync();
        }

        private static IEnumerable<Device> GenerateDevices(int numberOfDevices)
        {
            var faker = new Faker();
            var sensorTypes = new[] { "Temperature", "Humidity", "Pressure", "Light", "Motion" };

            var deviceFaker = new Faker<Device>()
                .RuleFor(d => d.Location, f => f.Address.Country())
                .RuleFor(d => d.Date, f => f.Date.Past())
                .RuleFor(d => d.Type, f => f.PickRandom(sensorTypes))
                .RuleFor(d => d.Status, f => f.Random.Bool());

            var devices = deviceFaker.Generate(numberOfDevices);
            return devices;
        }
    }
}
