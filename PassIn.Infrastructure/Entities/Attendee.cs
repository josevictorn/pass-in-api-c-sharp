﻿namespace PassIn.Infrastructure.Entities
{
    public class Attendee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public Guid Event_id { get; set; }
        public DateTime Created_at { get; set; }
        public CheckIn? CheckIn { get; set; }
    }
}
