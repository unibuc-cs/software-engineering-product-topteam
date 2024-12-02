namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class NotificareControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public NotificareControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all notifications
    [Fact]
    public async Task GetAllNotifications_ReturnsOk_WithListOfNotifications()
    {
        var response = await _client.GetAsync("/api/notificare");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var notifications = await response.Content.ReadFromJsonAsync<List<Notificare>>();
        notifications.Should().NotBeNull();
        notifications.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get notification by ID
    [Fact]
    public async Task GetNotificationById_ExistingId_ReturnsOk_WithNotification()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/notificare/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var notification = await response.Content.ReadFromJsonAsync<Notificare>();
        notification.Should().NotBeNull();
        notification.notificareId.Should().Be(testId);
    }

    // Test: Get notification by ID (non-existent ID)
    [Fact]
    public async Task GetNotificationById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/notificare/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new notification
    [Fact]
    public async Task AddNotification_ValidInput_ReturnsCreatedNotification()
    {
        var newNotification = new Notificare
        {
            notificareId = 0,
            titlu = "Test Notification",
            mesaj = "This is a test notification.",
            data = DateTime.UtcNow,
            tipNotificare = "User",
            receptorId = 1 // Assuming UserId or another valid receptor exists in the database
        };

        var response = await _client.PostAsJsonAsync("/api/notificare", newNotification);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdNotification = await response.Content.ReadFromJsonAsync<Notificare>();
        createdNotification.Should().NotBeNull();
        createdNotification.titlu.Should().Be(newNotification.titlu);
        createdNotification.mesaj.Should().Be(newNotification.mesaj);
        createdNotification.tipNotificare.Should().Be(newNotification.tipNotificare);
        createdNotification.receptorId.Should().Be(newNotification.receptorId);
    }

    // Test: Update an existing notification
    [Fact]
    public async Task UpdateNotification_ValidInput_ReturnsNoContent()
    {
        var updatedNotification = new Notificare
        {
            notificareId = 1,
            titlu = "Updated Notification",
            mesaj = "Updated notification message.",
            data = DateTime.UtcNow,
            tipNotificare = "Group",
            receptorId = 2
        };

        var response = await _client.PutAsJsonAsync($"/api/notificare/{updatedNotification.notificareId}", updatedNotification);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update notification with mismatched ID
    [Fact]
    public async Task UpdateNotification_MismatchedId_ReturnsBadRequest()
    {
        var updatedNotification = new Notificare
        {
            notificareId = 1,
            titlu = "Mismatched Notification",
            mesaj = "Mismatched notification message.",
            data = DateTime.UtcNow,
            tipNotificare = "User",
            receptorId = 1
        };

        var response = await _client.PutAsJsonAsync("/api/notificare/99999", updatedNotification);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing notification
    [Fact]
    public async Task DeleteNotification_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/notificare/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/notificare/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete notification with non-existent ID
    [Fact]
    public async Task DeleteNotification_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/notificare/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
