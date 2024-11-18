using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace lab3testapi.StepDefinitions
{
    [Binding]
    public class CrudApiStepDefinitions
    {
        private RestClient client =  new RestClient("https://restful-booker.herokuapp.com");
        private RestRequest request;
        private IRestResponse response;

        private int bookingID = 219;
        private int bookingDELETE = 100;

        [Given(@"I have a valid booking ID for GET")]
        public void GivenIHaveAValidBookingIDForGET()
        {
            client = new RestClient("https://restful-booker.herokuapp.com");
        }

        [When(@"I send a GET request to the ""([^""]*)"" endpoint")]
        public void WhenISendAGETRequestToTheEndpoint(string endPoint)
        {
            request = new RestRequest(endPoint, Method.GET);
        }

        [Then(@"the response status code for GET should be (.*)")]
        public void ThenTheResponseStatusCodeForGETShouldBe(int p0)
        {
            response= client.Execute(request);
        }

        [Then(@"the response should contain the booking details")]
        public void ThenTheResponseShouldContainTheBookingDetails()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Given(@"I have a valid booking payload")]
        public void GivenIHaveAValidBookingPayload()
        {
            request = new RestRequest("/booking", Method.POST);
            //request.RequestFormat = DataFormat.Json;
           // request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                firstname = "John",
                lastname = "Doe",
                totalprice = 150,
                depositpaid = true,
                bookingdates =new
                {
                    checkin = "2024-01-01",
                    checkout = "2024-01-10"
                },
                additionalneeds = "Breakfast"
            });

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
        }

        [When(@"I send a POST request to the ""([^""]*)"" endpoint")]
        public void WhenISendAPOSTRequestToTheEndpoint(string endPoint)
        {
            response = client.Execute(request);
        }

        [Then(@"the response status code for POST should be (.*)")]
        public void ThenTheResponseStatusCodeForPOSTShouldBe(int expectedStatusCode)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }


        [Given(@"I have a valid booking ID and update payload")]
        public void GivenIHaveAValidBookingIDAndUpdatePayload()
        {          
            request = new RestRequest($"/booking/{bookingID}", Method.PUT);
            request.AddJsonBody(new
            {
                firstname = "Jane",
                lastname = "Smith",
                totalprice = 200,
                depositpaid = false,
                bookingdates = new
                {
                    checkin = "2024-02-01",
                    checkout = "2024-02-10"
                },
                additionalneeds = "Dinner"
            });
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
        }

        [When(@"I send a PUT request to the ""([^""]*)"" endpoint")]
        public void WhenISendAPUTRequestToTheEndpoint(string endPoint)
        {
            response = client.Execute(request);
            
        }

        [Then(@"the response status code for PUT should be (.*)")]
        public void ThenTheResponseStatusCodeForPUTShouldBe(int status)
        {
            Assert.AreEqual(status, (int)response.StatusCode);
        }

        [Given(@"I have a valid booking ID for DELETE")]
        public void GivenIHaveAValidBookingIDForDELETE()
        {
            request = new RestRequest($"/booking/{bookingDELETE}", Method.DELETE);
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
        }

        [When(@"I send a DELETE request to the ""([^""]*)"" endpoint")]
        public void WhenISendADELETERequestToTheEndpoint(string p0)
        {
            response = client.Execute(request);
        }

        [Then(@"the response status code for DELETE should be (.*)")]
        public void ThenTheResponseStatusCodeForDELETEShouldBe(int status)
        {
            Assert.AreEqual(status, (int)response.StatusCode);
        }

    }
}
