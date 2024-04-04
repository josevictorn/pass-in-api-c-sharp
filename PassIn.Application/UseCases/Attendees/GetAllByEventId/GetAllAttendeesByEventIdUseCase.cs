﻿using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId
{
    public class GetAllAttendeesByEventIdUseCase
    {
        private readonly PassInDbContext _dbContext;

        public GetAllAttendeesByEventIdUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseAllAttendeesJson Execute(Guid eventID)
        {
            var entity = _dbContext.Events.Include(ev => ev.Attendees).ThenInclude(attendee => attendee.CheckIn).FirstOrDefault(ev => ev.Id == eventID);

            if (entity == null)
                throw new NotFoundException("An event with id don't exist.");

            return new ResponseAllAttendeesJson
            {
                Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
                {
                    Id = attendee.Id,
                    Name = attendee.Name,
                    Email = attendee.Email,
                    CreatedAt = attendee.Created_at,
                    CheckedInAt = attendee.CheckIn?.Created_at,
                }).ToList(),
            };
        }
    }
}
