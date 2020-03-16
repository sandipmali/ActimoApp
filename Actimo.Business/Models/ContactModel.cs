using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Models
{
    public class ContactModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public string country_code { get; set; }
        public string phone_number { get; set; }
        public string company { get; set; }
        public string company_reg { get; set; }
        public object department { get; set; }        
        public string addr_line_1 { get; set; }
        public string addr_line_2 { get; set; }
        public string addr_city { get; set; }
        public string addr_state { get; set; }
        public object addr_zip { get; set; }
        public string addr_country { get; set; }
        public string data1 { get; set; }
        public string data2 { get; set; }
        public object data3 { get; set; }
        public object data4 { get; set; }
        public object data5 { get; set; }
        public object data6 { get; set; }
        public object data7 { get; set; }
        public object data8 { get; set; }
        public object data9 { get; set; }
        public object data10 { get; set; }
        public object data11 { get; set; }
        public object data12 { get; set; }
        public object data13 { get; set; }
        public object data14 { get; set; }
        public string data15 { get; set; }
        public string data16 { get; set; }
        public string data17 { get; set; }
        public string data18 { get; set; }
        public string data19 { get; set; }
        public string data20 { get; set; }
        public bool? opt_out { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        public DateTime updated_at { get; set; }        
        public DateTime? last_active { get; set; }
    }

    public class ContactRoot
    {
        public string status { get; set; }
        public List<ContactModel> data { get; set; }
    }
}
