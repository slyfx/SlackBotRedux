﻿using System;

namespace SlackBotRedux.Core.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
