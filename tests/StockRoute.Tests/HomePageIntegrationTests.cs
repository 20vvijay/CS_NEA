using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace StockRoute.Tests;

public sealed class HomePageIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HomePageIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHome_ReturnsSuccessAndLoginForm()
    {
        var response = await _client.GetAsync("/");

        response.EnsureSuccessStatusCode();

        var page = await response.Content.ReadAsStringAsync();
        Assert.Contains("id=\"Username\"", page);
        Assert.Contains("id=\"Password\"", page);
    }
}
