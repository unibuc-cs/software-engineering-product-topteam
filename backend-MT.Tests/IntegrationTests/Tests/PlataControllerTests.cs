namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class PlataControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public PlataControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    // Helper method for logging error responses
    private async Task LogErrorResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }
    }

    // Test: Get all payments
    [Fact]
    public async Task GetAllPayments_ReturnsOk_WithListOfPayments()
    {
        var response = await _client.GetAsync("/api/plata");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var payments = await response.Content.ReadFromJsonAsync<List<Plata>>();
        payments.Should().NotBeNull();
        payments.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get payment by ID
    [Fact]
    public async Task GetPaymentById_ExistingId_ReturnsOk_WithPayment()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/plata/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var payment = await response.Content.ReadFromJsonAsync<Plata>();
        payment.Should().NotBeNull();
        payment.plataId.Should().Be(testId);
    }

    // Test: Get payment by ID (non-existent ID)
    [Fact]
    public async Task GetPaymentById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/plata/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new payment
    [Fact]
    public async Task AddPayment_ValidInput_ReturnsCreatedPayment()
    {
        var newPayment = new Plata
        {
            plataId = 0,
            suma = 150,
            data = DateTime.UtcNow,
            userId = 1, // Assuming this user exists
            cursId = 1  // Assuming this course exists
        };

        var response = await _client.PostAsJsonAsync("/api/plata", newPayment);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdPayment = await response.Content.ReadFromJsonAsync<Plata>();
        createdPayment.Should().NotBeNull();
        createdPayment.suma.Should().Be(newPayment.suma);
        createdPayment.userId.Should().Be(newPayment.userId);
        createdPayment.cursId.Should().Be(newPayment.cursId);
    }

    // Test: Update an existing payment
    [Fact]
    public async Task UpdatePayment_ValidInput_ReturnsNoContent()
    {
        var updatedPayment = new Plata
        {
            plataId = 1,
            suma = 200,
            data = DateTime.UtcNow,
            userId = 2, // Assuming UserId 2 exists
            cursId = 2  // Assuming CursId 2 exists
        };

        var response = await _client.PutAsJsonAsync($"/api/plata/{updatedPayment.plataId}", updatedPayment);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update payment with mismatched ID
    [Fact]
    public async Task UpdatePayment_MismatchedId_ReturnsBadRequest()
    {
        var updatedPayment = new Plata
        {
            plataId = 1,
            suma = 300,
            data = DateTime.UtcNow,
            userId = 2,
            cursId = 2
        };

        var response = await _client.PutAsJsonAsync("/api/plata/99999", updatedPayment);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing payment
    [Fact]
    public async Task DeletePayment_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/plata/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/plata/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete payment with non-existent ID
    [Fact]
    public async Task DeletePayment_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/plata/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
