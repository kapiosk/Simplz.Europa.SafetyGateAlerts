// using InfluxDB3.Client;
// using InfluxDB3.Client.Write;

// namespace Simplz.Europa.SafetyGateAlerts.Services;

// public sealed class InfluxDBService : IDisposable
// {
//     private readonly InfluxDBClient _client;

//     private InfluxDBService()
//     {
//         var influx_connectionstring = Environment.GetEnvironmentVariable("INFLUXDB_CONNECTIONSTRING");
//         _client = new InfluxDBClient(influx_connectionstring);
//     }

//     public static InfluxDBService CreateService()
//     {
//         return new InfluxDBService();
//     }

//     public async Task WriteDataAsync(string measurement, string name, float value, DateTime timestamp, CancellationToken cancellationToken = default)
//     {
//         await _client.WritePointAsync(
//             PointData.Measurement(measurement)
//                 .SetField(name, value)
//                 .SetTimestamp(timestamp.ToUniversalTime()
//         ), cancellationToken: cancellationToken);
//     }

//     public void Dispose()
//     {
//         _client?.Dispose();
//     }
// }
