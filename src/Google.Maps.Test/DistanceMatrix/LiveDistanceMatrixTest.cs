﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.DistanceMatrix;

namespace Google.Maps.Test.DistanceMatrix
{
	[TestFixture]
	public class LiveDistanceMatrixTest
	{
		[SetUp]
		public void Setup()
		{

		}

		public LiveDistanceMatrixTest()
		{
			//GoogleSigned.AssignAllServices(new GoogleSigned(apiKey: "your-api-key"));
		}

		[Test]
		public void DrivingDistancebyLngLat()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new Waypoint(lat: 53.378243m, lng: -1.462131m));
			//rotherham
			request.AddOrigin(new Waypoint(lat: 53.434297m,lng: -1.364678m));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);

		}

		[Test]
		public void DrivingDistancebyAddressAndLngLat()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new Waypoint("Sheffield"));
			//rotherham
			request.AddOrigin(new Waypoint(lat: 53.434297m, lng: -1.364678m));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);

		}

		[Test]
		public void DrivingDistancebyAddress()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new Waypoint("Sheffield"));
			//rotherham
			request.AddOrigin(new Waypoint("Rotherham"));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);

		}

		[Test]
		public void DrivingDistancebyLngLatHasOneOriginAndDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Waypoint(lat: 53.434297m, lng: -1.364678m));
			//sheffield
			request.AddDestination(new Waypoint(lat: 53.378243m, lng: -1.462131m));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);
			Assert.IsTrue(response.DestinationAddresses.Length == 1);
			Assert.IsTrue(response.OriginAddresses.Length == 1);

		}

		[Test]
		public void DrivingDistancebyAddressHasOneOriginAndDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Waypoint("Rotherham"));
			//sheffield
			request.AddDestination(new Waypoint("Sheffield"));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);
			Assert.IsTrue(response.DestinationAddresses.Length == 1);
			Assert.IsTrue(response.OriginAddresses.Length == 1);

		}



		[Test]
		public void DrivingDistancebyLngLatHasOneOriginAndMultipleDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Waypoint(lat: 53.434297m, lng: -1.364678m));
			//sheffield
			request.AddDestination(new Waypoint(lat: 53.378243m, lng: -1.462131m));
			request.AddDestination(new Waypoint(lat: 51.378243m, lng: -1.162131m));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);
			Assert.IsTrue(response.DestinationAddresses.Length > 1);
			Assert.IsTrue(response.OriginAddresses.Length == 1);

		}

		[Test]
		public void DrivingDistancebyAddressHasOneOriginAndMultipleDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Waypoint("Rotherham"));
			//sheffield
			request.AddDestination(new Waypoint("Sheffield"));
			request.AddDestination(new Waypoint("London"));

			request.Sensor = true;
			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);
			Assert.IsTrue(response.DestinationAddresses.Length > 1);
			Assert.IsTrue(response.OriginAddresses.Length == 1);
		}
	}
}