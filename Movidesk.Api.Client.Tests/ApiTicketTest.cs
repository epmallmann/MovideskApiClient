//using Movidesk.Api.Client.Clients;
////using Movidesk.Api.Client.Models;
//using Movidesk.Api.Client.Utils;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace Movidesk.Api.Client.Tests
//{
//    public class ApiTicketTest : BaseTest
//    {
//        private readonly MovideskApiClientOptions _options;

//        public ApiTicketTest()
//        {
//            _options = new MovideskApiClientOptions { Token = Token };
//        }

//        [Fact]
//        public void GetAllNoSelectTest()
//        {
//            var client = new TicketClient(_options);
//            var result = client.Get(new OData { Select = "" }).Result;

//            Assert.False(result.InnerResponse.IsSuccessStatusCode);
//        }

//        [Fact]
//        public void GetAllIdTest()
//        {
//            var client = new TicketClient(_options);
//            var result = client.Get(new OData { Select = "id" }).Result;

//            Assert.True(result.InnerResponse.IsSuccessStatusCode);
//            Assert.True(result.ResponseObject.Count > 0);
//            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.Subject));
//        }

//        //[Fact]
//        //public void PostFailTest()
//        //{
//        //    var client = new TicketClient(_options);
//        //    var result = client.Post(new Ticket { }).Result;
//        //}
//    }
//}
