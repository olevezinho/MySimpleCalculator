using MySimpleCalculator;
using MySimpleCalculatorWebAPI.Extensions;
using NUnit.Framework;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MySimpleCalculatorWebAPI.IntegrationTests
{
    public class CalcControllerTests
    {
        /// <summary>Integration test on the web api</summary>
        [TestFixture]
        [NonParallelizable]
        public class IntegrationTestModelClassAPI
        {
            [Theory]
            [TestCase(1, 1, 2)]
            public async Task TestForResponseTypeAdd(int n1, int n2, int result)
            {
                //Arrange
                using var client = new SetupTestServer().Client; //Initializes the client

                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/add/{n1}/{n2}", new StringContent(
                    JsonSerializer.Serialize(new Calculator().Add(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK)); //Asserting that the request returns a 200 OK 
                    Assert.That(result.ToString(), Is.EqualTo(response)); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }

            [Theory]
            [TestCase(1, 1, 0)]
            public async Task TestForResponseTypeSubtract(int n1, int n2, int result)
            {

                using (var client = new SetupTestServer().Client) //Initializes the client
                {
                    //Arrange
                    var Initial = DateTime.UtcNow;
                    var request = await client.PostAsync($"/api/calc/sub/{n1}/{n2}", new StringContent(
                        JsonSerializer.Serialize(new Calculator().Subtract(n1, n2)),
                        Encoding.UTF8, "application/json"));
                    request.EnsureSuccessStatusCode();

                    //Act
                    var response = request.Content.ReadAsStringAsync().Result;
                    var dif = DateTime.Now - Initial;

                    //Assert
                    if (dif.TotalSeconds < 2)
                    {
                        Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK)); //Asserting that the request returns a 200 OK 
                        Assert.That(result.ToString(), Is.EqualTo(response)); //Asserting that the calculation of the Calculator.Add() method is as expected
                    }
                }
            }

            [Theory]
            [TestCase(1, 1, 1)]
            public async Task TestForResponseTypeMultiply(int n1, int n2, int result)
            {

                using (var client = new SetupTestServer().Client) //Initializes the client
                {
                    //Arrange
                    var Initial = DateTime.UtcNow;
                    var request = await client.PostAsync($"/api/calc/mul/{n1}/{n2}", new StringContent(
                        JsonSerializer.Serialize(new Calculator().Multiply(n1, n2)),
                        Encoding.UTF8, "application/json"));
                    request.EnsureSuccessStatusCode();

                    //Act
                    var response = request.Content.ReadAsStringAsync().Result;
                    var dif = DateTime.Now - Initial;

                    //Assert
                    if (dif.TotalSeconds < 2)
                    {
                        Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK)); //Asserting that the request returns a 200 OK 
                        Assert.Equals(result.ToString(), response); //Asserting that the calculation of the Calculator.Add() method is as expected
                    }
                }
            }

            [Test]
            [TestCase(4, 2, 2)]
            public async Task TestForResponseTypeDivide(int n1, int n2, int result)
            {
                //Arrange
                using var client = new SetupTestServer().Client; //Initializes the client

                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/div/{n1}/{n2}", new StringContent(
                    JsonSerializer.Serialize(new Calculator().Divide(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK)); //Asserting that the request returns a 200 OK 
                    Assert.That(result.ToString(), Is.EqualTo(response)); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }

            [Test]
            [TestCase(4, 2, 0)]
            public async Task TestForResponseTypeMod(int n1, int n2, int result)
            {
                //Arrange
                using var client = new SetupTestServer().Client; //Initializes the client

                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/div/{n1}/{n2}", new StringContent(
                    JsonSerializer.Serialize(new Calculator().Mod(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK)); //Asserting that the request returns a 200 OK 
                    Assert.That(result.ToString(), Is.EqualTo(response)); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }
        }
    }
}
