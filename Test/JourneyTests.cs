using Api.Controllers;
using Application.Interfaces;
using Application.References;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class JourneyTests
    {
        private JourneyController journeyController;
        private Guid IdBill = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var mockRepo = new Mock<IJourneyServices>();
            mockRepo.Setup(repo => repo.Get("MZL", "CAN",1)).Returns(Get());
            journeyController = new JourneyController(mockRepo.Object);
        }

        [Test]
        public async Task GetSucces()
        {
            var response = await journeyController.Get("MZL", "CAN", 1) as OkObjectResult;
            Assert.AreEqual(200, response.StatusCode);
            var journeys = response.Value as BaseResponse<List<Journey>>;
            Assert.IsNotNull(journeys);
            Assert.IsNotNull(journeys.Data);
            var journey = journeys.Data.FirstOrDefault();
            Assert.IsNotNull(journey);
            Assert.AreEqual(journey.Origin, "MZL");
            Assert.AreEqual(journey.Destination, "CAN");
        }

        private async Task<BaseResponse<List<Journey>>> Get()
        {
            var response = new BaseResponse<List<Journey>>();
            var journeys = new List<Journey>();
            var journey = new Journey();
            journey.Origin = "MZL";
            journey.Destination = "CAN";
            journey.Price = 500;
            journeys.Add(journey);
            response.Data = journeys;

            return response;
        }


    }
}