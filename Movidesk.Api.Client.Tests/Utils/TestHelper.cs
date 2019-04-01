using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Tests.Utils
{
    public class TestHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
        }
    }
}
