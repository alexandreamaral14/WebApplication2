using System;
using System.Collections.Generic;
using System.Text;

namespace WS.DTO.DTOs
{
    public class StorieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string uri { get; set; }
        public string PostedBy { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public int NumberComments { get; set; }
    }
}
