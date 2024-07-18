using System.Text.Json;

namespace EfInheritance.Domain.Utilities;

public partial class IOJsonHandler : Policy<JsonDocument>
{
    protected override string SecreteFileName => "secrete.json";

    private JsonDocument SecreteJson;

    private string SecreteFilePath;

    protected override async Task<JsonDocument> ReadSecreteAsync()
    {
        SecreteFilePath = Path.Combine(Environment.CurrentDirectory, SecreteFileName);
        if (!File.Exists(SecreteFilePath))
            throw new IOException($"file not foun at expected path {SecreteFilePath}");
        using var secreteContentStream = new FileStream(SecreteFilePath, FileMode.Open, FileAccess.Read);
        return SecreteJson = await JsonDocument.ParseAsync(secreteContentStream);
    }

    protected override string GetConnectionString(JsonDocument secrete)
    {
        ArgumentNullException.ThrowIfNull(secrete);
        ArgumentException.ThrowIfNullOrEmpty(SecreteFilePath);
        (string connectionString, string elementKey)
            =
        (string.Empty, "ConnectionString");
        connectionString = secrete.RootElement.GetProperty(elementKey).ToString();
        return connectionString;
    }

    public override async Task<string> GetConnectionStringFacadeAsync()
    {
        await ReadSecreteAsync();
        return GetConnectionString(SecreteJson);
    }

    protected override void DisposeIoResources()
    {
        if (SecreteJson is not null)
            SecreteJson.Dispose();
    }
}