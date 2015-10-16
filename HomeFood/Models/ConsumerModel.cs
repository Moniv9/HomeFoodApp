using System;

namespace HomeFood.Models
{
    public class ConsumerModel
    {
        public string ProviderId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime BookDateTime { get; set; }
    }
}