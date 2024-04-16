using System;
using System.Net.Http;
using System.Threading.Tasks;

// Мікросервіс Auth

class AuthToken
{
    public string Token { get; set; }
}

class AuthService
{
    public async Task<AuthToken> RegisterUser(string email, string password)
    {
        Console.WriteLine($"User with email {email} registered successfully.");
        return new AuthToken() { Token = "generated_token" };
    }
}

// Мікросервіс Subscriptions

class SubscriptionService
{
    public async Task<bool> Subscribe(string userId, string serviceId)
    {
        Console.WriteLine($"User with ID {userId} subscribed to service with ID {serviceId}.");
        return true;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        string email = "example@example.com";
        string password = "password123";

        AuthService authService = new AuthService();
        AuthToken token = await authService.RegisterUser(email, password);

        Console.WriteLine($"Token: {token.Token}");
        string userId = "user123";
        string serviceId = "service123";

        SubscriptionService subscriptionService = new SubscriptionService();
        bool subscribed = await subscriptionService.Subscribe(userId, serviceId);

        if (subscribed)
        {
            Console.WriteLine($"User with ID {userId} subscribed successfully to service with ID {serviceId}.");
        }
        else
        {
            Console.WriteLine($"Failed to subscribe user with ID {userId} to service with ID {serviceId}.");
        }
    }
}
