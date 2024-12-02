namespace backend_MT.Tests.IntegrationTests;

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

    public CursControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all courses
    [Fact]
    public async Task GetAllCourses_ReturnsOk_WithListOfCourses()
    {
        // Act
        var response = await _client.GetAsync("/api/curs");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var courses = await response.Content.ReadFromJsonAsync<List<Curs>>();
        courses.Should().NotBeNull();
        courses.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get course by ID
    [Fact]
    public async Task GetCourseById_ExistingId_ReturnsOk_WithCourse()
    {
        // Arrange
        var testId = 1; // Ensure test data includes an ID 1

        // Act
        var response = await _client.GetAsync($"/api/curs/{testId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var course = await response.Content.ReadFromJsonAsync<Curs>();
        course.Should().NotBeNull();
        course.cursId.Should().Be(testId);
        course.denumire.Should().NotBeNullOrEmpty();
        course.descriere.Should().NotBeNullOrEmpty();
    }

    // Test: Get course by ID (non-existent ID)
    [Fact]
    public async Task GetCourseById_NonExistentId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/curs/99999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new course
    [Fact]
    public async Task AddCourse_ValidInput_ReturnsCreatedCourse()
    {
        // Arrange
        var newCourse = new Curs
        {
            cursId = 99, // Will be assigned by the DB
            denumire = "Test Course",
            descriere = "This is a test course.",
            nrSedinte = 10,
            pret = 300
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/curs", newCourse);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdCourse = await response.Content.ReadFromJsonAsync<Curs>();
        createdCourse.Should().NotBeNull();
        createdCourse.denumire.Should().Be(newCourse.denumire);
        createdCourse.descriere.Should().Be(newCourse.descriere);
        createdCourse.nrSedinte.Should().Be(newCourse.nrSedinte);
        createdCourse.pret.Should().Be(newCourse.pret);
    }

    // Test: Update an existing course
    [Fact]
    public async Task UpdateCourse_ValidInput_ReturnsNoContent()
    {
        // Arrange
        var updatedCourse = new Curs
        {
            cursId = 1, // Ensure this ID exists in seed data
            denumire = "Updated Course",
            descriere = "Updated description.",
            nrSedinte = 15,
            pret = 400
        };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/curs/{updatedCourse.cursId}", updatedCourse);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update course with mismatched ID
    [Fact]
    public async Task UpdateCourse_MismatchedId_ReturnsBadRequest()
    {
        // Arrange
        var updatedCourse = new Curs
        {
            cursId = 1, // Ensure this ID exists in seed data
            denumire = "Mismatched Course",
            descriere = "Mismatched description.",
            nrSedinte = 12,
            pret = 350
        };

        // Act
        var response = await _client.PutAsJsonAsync("/api/curs/99999", updatedCourse);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing course
    [Fact]
    public async Task DeleteCourse_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var testId = 1; // Ensure this ID exists in seed data

        // Act
        var response = await _client.DeleteAsync($"/api/curs/{testId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Ensure the course is deleted
        var checkResponse = await _client.GetAsync($"/api/curs/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete course with non-existent ID
    [Fact]
    public async Task DeleteCourse_NonExistentId_ReturnsNotFound()
    {
        // Act
        var response = await _client.DeleteAsync("/api/curs/99999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
