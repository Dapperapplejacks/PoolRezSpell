using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

public static class SwaggerExtensions
{
    public static void SaveSwaggerJson(this IServiceProvider provider)
    {
        ISwaggerProvider sw = provider.GetRequiredService<ISwaggerProvider>();
        OpenApiDocument doc = sw.GetSwagger("v1", null, "/");
        string swaggerFile = doc.SerializeAsJson(Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
        File.WriteAllText("bin\\Debug\\net8.0\\swaggerfile.json", swaggerFile);
    }
}