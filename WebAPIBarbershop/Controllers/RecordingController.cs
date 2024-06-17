using Microsoft.AspNetCore.Mvc;

namespace WebAPIBarbershop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordingController : ControllerBase
    {
        private static readonly string[] AdminRecordingTime = new[]
        {
            "11:00", "9:45", "10:20", "12:00", "13:45", "11:25", "8:55", "15:20", "16:00", "19:45"

        };

        private static readonly string[] AdminDateRecording = new[]
        {
            "14.06.2024", "14.06.2024", "14.06.2024", "15.06.2024", "15.06.2024", "15.06.2024", "16.06.2024", "16.06.2024", "16.06.2024", "17.06.2024"

        };

        private static readonly int[] AdminNumberMaster = new[]
        {
            11, 12, 13, 14, 10, 15

        };

        private static readonly int[] AdminWorks = new[]
        {
            1, 2, 3, 4, 5
        };

        public IEnumerable<Recording> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Recording
            {
                RecordingTime = AdminRecordingTime[Random.Shared.Next(AdminRecordingTime.Length)],

                DateRecording = AdminDateRecording[Random.Shared.Next(AdminDateRecording.Length)],

                NumberMaster = AdminNumberMaster[Random.Shared.Next(AdminNumberMaster.Length)],

                Works = AdminWorks[Random.Shared.Next(AdminWorks.Length)]

            })
            .ToArray();
        }
    }
}
