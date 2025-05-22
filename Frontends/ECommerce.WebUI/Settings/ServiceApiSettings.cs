﻿namespace ECommerce.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string IdentityServerUrl { get; set; }

        public ServiceApi Catalog { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi Message { get; set; }
        public ServiceApi Order { get; set; }


        public class ServiceApi
        {
            public string Path { get; set; }
        }
    }
}

//her bir mikroservisin bir path/port olacak