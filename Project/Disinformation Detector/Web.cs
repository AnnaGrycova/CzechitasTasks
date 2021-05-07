using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Web
    {
        public string Domain { get; set; } //TODO validation of domain in setter
        public double Credibility { get; set; }
        public Web(string domain)
        {
            Domain = domain;
        }
        public Web(string domain, double credibility)
        {
            Domain = domain;
            Credibility = credibility;
        }

        public Web()
        {
        }
    }
}
