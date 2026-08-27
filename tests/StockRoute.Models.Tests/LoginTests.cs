using Xunit;

namespace StockRoute.Models.Tests;

public sealed class LoginTests
{
    [Fact]
    public void Login_CanBeCreated()
    {
        var model = new Login("test-user", "hashed-password");

        Assert.NotNull(model);
    }
}
