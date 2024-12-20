using EvieWizarding.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EvieWizarding.HealthChecks
{
    public class TeacherHealthCheck : IHealthCheck
    {

        private TeachersModel _TeacherModel { get; set; }

        public TeacherHealthCheck(TeachersModel model)
        {
            _TeacherModel = model;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken token = default)
        {
            var count = _TeacherModel.ReturnTeacher().Count;

            if (count <= 0 || count == null)
            {
                return HealthCheckResult.Unhealthy("There are no teachers available!");

            }

            return HealthCheckResult.Healthy($"There are {_TeacherModel.ReturnTeacher().Count} teachers available.");
        }

    }
}
