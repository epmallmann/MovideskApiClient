using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Utils
{
    public class OData
    {
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public string Select { get; set; }
        public string Expand { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(Filter))
                stringBuilder.Append($"$&$filter={Filter}");
            if (!string.IsNullOrEmpty(OrderBy))
                stringBuilder.Append($"$&orderby={OrderBy}");
            if (Top.HasValue)
                stringBuilder.Append($"$&top={Top.Value}");
            if (Skip.HasValue)
                stringBuilder.Append($"$&skip={Skip.Value}");
            if (!string.IsNullOrEmpty(Select))
                stringBuilder.Append($"$&select={Select}");
            if (!string.IsNullOrEmpty(Expand))
                stringBuilder.Append($"$&expand={Expand}");

            return stringBuilder.ToString();
        }

    }
}
