using Globomantics.Core.Models;
using System.Collections.Generic;

namespace Globomantics.Models
{
    // TODO: Move to external class
    public class CreditCardWidgetVM
    {
        public string WidgetTitle { get; set; }
        public string WidgetSubTitle { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
