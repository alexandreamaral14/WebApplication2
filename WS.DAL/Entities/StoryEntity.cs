﻿using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.DAL.Entities
{
    public class StoryEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DeserializeAs(Name = "url")]
        public string uri { get; set; }

        [DeserializeAs(Name = "by")]
        public string PostedBy { get; set; }
        [DeserializeAs(Name = "time")]
        public DateTime Date { get; set; }
        public int Score { get; set; }

        [DeserializeAs(Name = "kids")]
        public IEnumerable<int> CommentsID { get; set; }
    }
}
