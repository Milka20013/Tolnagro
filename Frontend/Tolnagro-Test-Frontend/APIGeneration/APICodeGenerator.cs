using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace Tolnagro_Test_Frontend.APIGeneration
{
    public class APICodeGenerator
    {
        public async static Task Generate(HttpClient client)
        {

            var json = await client.GetStringAsync("swagger/v1/swagger.json");

            var document = await OpenApiDocument.FromJsonAsync(json);

            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "GeneratedAPIs",
                CSharpGeneratorSettings = { Namespace = "Tolnagro_Test_Backend.API" }
            };

            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();

            File.WriteAllText("Generated/GeneratedAPIs.cs", code);
        }
    }
}
