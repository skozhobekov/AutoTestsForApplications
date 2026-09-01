// using Microsoft.Extensions.DependencyInjection;
// using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
//
// namespace apitest.Modules;
//
// public static class UsersModule
// {
//     public static IServiceCollection AddUsersModule(
//         this IServiceCollection services,
//         string baseUrl)
//     // {
//     services
//         .AddRefitClient<IUserApi>()
//         .ConfigureHttpClient(client =>
//         {
//             client.BaseAddress = new Uri(baseUrl);
//         });
//     
//     services.AddScoped<IUserService, UserService>();
//     
//     return services;
//     // }
// }
//
//     
// }