    namespace App1.Models {
        using System;

        public class Record
        {
            public string cropName { get; set; }
            public string docType { get; set; }
            public string imgUrl { get; set; }
            public string organization { get; set; }
            public string packageCode { get; set; }
            public string status { get; set; }
            
            public DateTime timestamp { get; set; }
        }
    }
