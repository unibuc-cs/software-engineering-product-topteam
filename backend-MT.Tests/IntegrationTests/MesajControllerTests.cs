namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class MesajControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public MesajControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all messages
    [Fact]
    public async Task GetAllMessages_ReturnsOk_WithListOfMessages()
    {
        var response = await _client.GetAsync("/api/mesaj");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var messages = await response.Content.ReadFromJsonAsync<List<Mesaj>>();
        messages.Should().NotBeNull();
        messages.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get message by ID
    [Fact]
    public async Task GetMessageById_ExistingId_ReturnsOk_WithMessage()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/mesaj/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var message = await response.Content.ReadFromJsonAsync<Mesaj>();
        message.Should().NotBeNull();
        message.mesajId.Should().Be(testId);
    }

    // Test: Get message by ID (non-existent ID)
    [Fact]
    public async Task GetMessageById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/mesaj/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new message
    [Fact]
    public async Task AddMessage_ValidInput_ReturnsCreatedMessage()
    {
        var newMessage = new Mesaj
        {
            mesajId = 0,
            mesajText = "This is a test message.",
            tipMesaj = "Privat",
            emitatorId = 1,
            receptorId = 2
        };

        var response = await _client.PostAsJsonAsync("/api/mesaj", newMessage);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdMessage = await response.Content.ReadFromJsonAsync<Mesaj>();
        createdMessage.Should().NotBeNull();
        createdMessage.mesajText.Should().Be(newMessage.mesajText);
        createdMessage.tipMesaj.Should().Be(newMessage.tipMesaj);
        createdMessage.emitatorId.Should().Be(newMessage.emitatorId);
        createdMessage.receptorId.Should().Be(newMessage.receptorId);
    }

    // Test: Update an existing message
    [Fact]
    public async Task UpdateMessage_ValidInput_ReturnsNoContent()
    {
        var updatedMessage = new Mesaj
        {
            mesajId = 1,
            mesajText = "Updated message text.",
            tipMesaj = "Grup",
            emitatorId = 1,
            receptorId = 3
        };

        var response = await _client.PutAsJsonAsync($"/api/mesaj/{updatedMessage.mesajId}", updatedMessage);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update message with mismatched ID
    [Fact]
    public async Task UpdateMessage_MismatchedId_ReturnsBadRequest()
    {
        var updatedMessage = new Mesaj
        {
            mesajId = 1,
            mesajText = "Mismatched message text.",
            tipMesaj = "Privat",
            emitatorId = 1,
            receptorId = 2
        };

        var response = await _client.PutAsJsonAsync("/api/mesaj/99999", updatedMessage);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing message
    [Fact]
    public async Task DeleteMessage_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/mesaj/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/mesaj/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete message with non-existent ID
    [Fact]
    public async Task DeleteMessage_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/mesaj/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
