
using Microsoft.Owin;

[assembly: OwinStartup(typeof(BasicApi.Api.Start))]
namespace BasicApi.Api
{
    public class Start : Startup { }
}
