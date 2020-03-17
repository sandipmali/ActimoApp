using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Models
{

    public class ReportInsightMapping
    {
        public int id { get; set; }
        public List<InsightsValue2> insightsValues { get; set; }
    }

    public class EnagementModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public decimal? value { get; set; }
        public int? upperThreshold { get; set; }
        public int? lowerThreshold { get; set; }
        public string suffix { get; set; }
    }

    public class Tips
    {
    }

    public class InsightsValue
    {
        public object title { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public int insightsBar { get; set; }
        public object value { get; set; }
        public int? upperThreshold { get; set; }
        public int? lowerThreshold { get; set; }
        public string suffix { get; set; }
        public List<object> categories { get; set; }
        public Tips tips { get; set; }
        public int possible { get; set; }
    }

    public class Data
    {
        public List<InsightsValue> insightsValues { get; set; }
    }

    public class Tips2
    {
    }

    public class InsightsValue2
    {
        public object title { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public int insightsBar { get; set; }
        public decimal? value { get; set; }
        public int? upperThreshold { get; set; }
        public int? lowerThreshold { get; set; }
        public string suffix { get; set; }
        public List<object> categories { get; set; }
        public Tips2 tips { get; set; }
        public int possible { get; set; }
    }

    public class Report
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public object lastName { get; set; }
        public string name { get; set; }
        public List<InsightsValue2> insightsValues { get; set; }
        public string initials { get; set; }
        public DateTime? lastActive { get; set; }
        public object avatarUrl { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public object lastName { get; set; }
        public string name { get; set; }
        public string initials { get; set; }
        public object title { get; set; }
        public object department { get; set; }
        public string email { get; set; }
        public object countryCode { get; set; }
        public object phoneNumber { get; set; }
        public object phone { get; set; }
        public bool active { get; set; }
        public bool allowSms { get; set; }
        public bool allowEmail { get; set; }
        public bool allowContactInfo { get; set; }
        public bool allowPushNotifications { get; set; }
        public DateTime lastActive { get; set; }
        public object avatarUrl { get; set; }
        public List<object> relationships { get; set; }
        public Data data { get; set; }
        public List<Report> reports { get; set; }
        public object ratingLink { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }
}
