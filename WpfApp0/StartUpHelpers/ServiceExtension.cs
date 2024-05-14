using Microsoft.Extensions.DependencyInjection;
using System;

namespace WpfApp0.StartUpHelpers
{
    public static class ServiceExtension
    {
        public static void AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
            services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
        }
    }
}
