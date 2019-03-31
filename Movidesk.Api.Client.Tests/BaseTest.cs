using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Tests
{
    public class BaseTest
    {
        private IConfigurationRoot _configuration;

        public string Token { get { return _configuration["token"]; } }

        public BaseTest()
        {
            _configuration = TestHelper.GetConfiguration();
        }
    }
}
