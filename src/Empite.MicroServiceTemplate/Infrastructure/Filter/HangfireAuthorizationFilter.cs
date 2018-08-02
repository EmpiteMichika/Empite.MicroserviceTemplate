using Hangfire.Dashboard;

namespace Empite.MicroserviceTemplate.Infrastructure.Filter
{
    public class HangfireAuthorizationFilter: IDashboardAuthorizationFilter
    {
        /// <summary>
        /// Authorizes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
