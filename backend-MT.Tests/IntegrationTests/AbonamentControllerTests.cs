namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models; // Adjust namespace
using FluentAssertions;
using Xunit;

public class AbonamentControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public AbonamentControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all subscriptions
    [Fact]
    public async Task GetAllSubscriptions_ReturnsOk_WithListOfSubscriptions()
    {
        // Act
        var response = await _client.GetAsync("/api/abonament");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var subscriptions = await response.Content.ReadFromJsonAsync<List<Abonament>>();
        subscriptions.Should().NotBeNull();
        subscriptions.Should().HaveCountGreaterThan(0); // Ensure seeded data exists
    }

    // Test: Get subscription by ID
    [Fact]
    public async Task GetSubscriptionById_ExistingId_ReturnsOk_WithSubscription()
    {
        // Arrange
        var testId = 1; // Ensure test data includes an ID 1

        // Act
        var response = await _client.GetAsync($"/api/abonament/{testId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var subscription = await response.Content.ReadFromJsonAsync<Abonament>();
        subscription.Should().NotBeNull();
        subscription.abonamentId.Should().Be(testId);
        subscription.user.Should().NotBeNull();
        subscription.curs.Should().NotBeNull();
    }

    // Test: Get subscription by ID (non-existent ID)
    [Fact]
    public async Task GetSubscriptionById_NonExistentId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/abonament/99999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new subscription
    [Fact]
    public async Task AddSubscription_ValidInput_ReturnsCreatedSubscription()
    {
        // Arrange
        var newSubscription = new Abonament
        {
            abonamentId = 0, // Will be assigned by the DB
            userId = 1, // Assuming user with ID 1 exists in seed data
            cursId = 1 // Assuming curs with ID 1 exists in seed data
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/abonament", newSubscription);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdSubscription = await response.Content.ReadFromJsonAsync<Abonament>();
        createdSubscription.Should().NotBeNull();
        createdSubscription.userId.Should().Be(newSubscription.userId);
        createdSubscription.cursId.Should().Be(newSubscription.cursId);
    }

    // Test: Update an existing subscription
    [Fact]
    public async Task UpdateSubscription_ValidInput_ReturnsNoContent()
    {
        // Arrange
        var updatedSubscription = new Abonament
        {
            abonamentId = 1, // Ensure this ID exists in seed data
            userId = 2, // Assuming user with ID 2 exists
            cursId = 2  // Assuming curs with ID 2 exists
        };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/abonament/{updatedSubscription.abonamentId}", updatedSubscription);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Delete an existing subscription
    [Fact]
    public async Task DeleteSubscription_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var testId = 1; // Ensure this ID exists in seed data

        // Act
        var response = await _client.DeleteAsync($"/api/abonament/{testId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Ensure the subscription is deleted
        var checkResponse = await _client.GetAsync($"/api/abonament/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete subscription with non-existent ID
    [Fact]
    public async Task DeleteSubscription_NonExistentId_ReturnsNotFound()
    {
        // Act
        var response = await _client.DeleteAsync("/api/abonament/99999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
