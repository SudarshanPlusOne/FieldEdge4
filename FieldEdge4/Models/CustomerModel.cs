namespace FieldEdge4.Models;

public class CustomerCompleteModel1
    {
         public string id { get; set; }
        public string salutation { get; set; }
        public string initials { get; set; }
         public string firstname { get; set; }
        public string firstname_ascii { get; set; }
         public string gender { get; set; }
        public string firstname_country_rank { get; set; }
        public string firstname_country_frequency { get; set; }
         public string lastname { get; set; }
        public string lastname_ascii { get; set; }
        public string lastname_country_rank { get; set; }
        public string lastname_country_frequency { get; set; }
     public string email { get; set; }
        public string password { get; set; }
         public string country_code { get; set; }
        public string country_code_alpha { get; set; }
         public string country_name { get; set; }
        public string primary_language_code { get; set; }
        public string primary_language { get; set; }
        public float balance { get; set; }
        public string phone_Number { get; set; }
        public string currency { get; set; }
    }

        public class CustomerMandatoryModel
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public float balance { get; set; }
        public string currency { get; set; }
        public string phone_Number { get; set; }
    }

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ETag
    {
    }

    public class CustomerCompleteModel
    {
        public string id { get; set; }
        public string salutation { get; set; }
        public string initials { get; set; }
        public string firstname { get; set; }
        public string firstname_ascii { get; set; }
        public string gender { get; set; }
        public string firstname_country_rank { get; set; }
        public string firstname_country_frequency { get; set; }
        public string lastname { get; set; }
        public string lastname_ascii { get; set; }
        public string lastname_country_rank { get; set; }
        public string lastname_country_frequency { get; set; }
        public string email { get; set; }
        // public string password { get; set; }
        public string country_code { get; set; }
        public string country_code_alpha { get; set; }
        public string country_name { get; set; }
        public string primary_language_code { get; set; }
        public string primary_language { get; set; }
        public double balance { get; set; }
        public string phone_Number { get; set; }
        public string currency { get; set; }
        public string partitionKey { get; set; }
        public string rowKey { get; set; }
        public DateTime timestamp { get; set; }
        public ETag eTag { get; set; }
    }

