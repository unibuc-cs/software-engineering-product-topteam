namespace backend_MT.Tests.IntegrationTests.Tests;

using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models; // Adjust namespace
using FluentAssertions;
using Xunit;

public class CursControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public CursControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    // Test: Get all courses
    [Fact]
    public async Task GetAllCourses_ReturnsOk_WithListOfCourses()
    {
        var response = await _client.GetAsync("/api/curs");

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var courses = await response.Content.ReadFromJsonAsync<List<Curs>>();
        courses.Should().NotBeNull();
        courses.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get course by ID
    [Fact]
    public async Task GetCourseById_ExistingId_ReturnsOk_WithCourse()
    {
        var testId = 1; // Ensure test data includes an ID 1

        var response = await _client.GetAsync($"/api/curs/{testId}");

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var course = await response.Content.ReadFromJsonAsync<Curs>();
        course.Should().NotBeNull();
        course.cursId.Should().Be(testId);
    }

    // Test: Get course by ID (non-existent ID)
    [Fact]
    public async Task GetCourseById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/curs/99999");

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new course
    [Fact]
    public async Task AddCourse_ValidInput_ReturnsCreatedCourse()
    {
        var newCourse = new Curs
        {
            cursId = 99, // Will be assigned by the DB
            denumire = "Test Course",
            descriere = "This is a test course.",
            nrSedinte = 10,
            pret = 300
        };

        var response = await _client.PostAsJsonAsync("/api/curs", newCourse);

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdCourse = await response.Content.ReadFromJsonAsync<Curs>();
        createdCourse.Should().NotBeNull();
        createdCourse.denumire.Should().Be(newCourse.denumire);
    }

    // Test: Update an existing course
    [Fact]
    public async Task UpdateCourse_ValidInput_ReturnsNoContent()
    {
        var updatedCourse = new Curs
        {
            cursId = 1, // Ensure this ID exists in seed data
            denumire = "Updated Course",
            descriere = "Updated description.",
            nrSedinte = 15,
            pret = 400,
            abonamente = new List<Abonament>()
        };

        var response = await _client.PutAsJsonAsync($"/api/curs/{updatedCourse.cursId}", updatedCourse);

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update course with mismatched ID
    [Fact]
    public async Task UpdateCourse_MismatchedId_ReturnsBadRequest()
    {
        var updatedCourse = new Curs
        {
            cursId = 1, // Ensure this ID exists in seed data
            denumire = "Mismatched Course",
            descriere = "Mismatched description.",
            nrSedinte = 12,
            pret = 350
        };

        var response = await _client.PutAsJsonAsync("/api/curs/99999", updatedCourse);

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing course
    [Fact]
    public async Task DeleteCourse_ExistingId_ReturnsNoContent()
    {
        var testId = 1; // Ensure this ID exists in seed data

        var response = await _client.DeleteAsync($"/api/curs/{testId}");

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/curs/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete course with non-existent ID
    [Fact]
    public async Task DeleteCourse_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/curs/99999");

        // If the response is not successful, log the error details
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
