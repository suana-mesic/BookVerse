using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Translate
{
    public class GetLibreTranslateQuery
    {
        public string Q { get; set; }
        public string Source { get; set; } = "auto";
        public string Target { get; set; }
        public string Format { get; set; } = "text";
    }
}
