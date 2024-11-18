using RestSharp;
using System;
using System.Net;
using System.Net.NetworkInformation;
using TechTalk.SpecFlow;

namespace lab3testapi.StepDefinitions
{
    [Binding]
    public class ComicStepDefinitions
    {
        RestClient client;
        private RestRequest request;
        private IRestResponse response;
        [Given(@"I have a valid payload for GET")]
        public void GivenIHaveAValidPayloadForGET()
        {
             client = new RestClient("http://xkcd.com/info.0.json");
        }

        [When(@"I send a GET request")]
        public void WhenISendAGETRequest()
        {
            request = new RestRequest("", Method.GET);
            response = client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int status)
        {
            Assert.AreEqual(status, (int)response.StatusCode);
        }
    }
}
