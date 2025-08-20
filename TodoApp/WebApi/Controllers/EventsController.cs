﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context=context;
        }
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events=context.Events.OrderByDescending(x => x.Id).ToList();
            return Ok(events);

        }
        [HttpGet("{id}")]
        public IActionResult GetEvents(int id)
        {
            var evt = context.Events.Find(id);
            if(evt == null)
            {
                return NotFound();
            }
            return Ok(evt);
        }
        [HttpGet]
        public IActionResult CreateEvent(EventDto eventDto)
        {
            var evt = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                Allday = eventDto.Allday,
                CreatedAt = DateTime.Now,
            };
            context.Events.Add(evt);
            context.SaveChanges();
            return Ok(evt);
        }
        [HttpPut("{id}")]
        public IActionResult EditEvent(int id, EventDto eventDto)
        {
            var evt = context.Events.Find(id);
            if(evt == null)
            {
                return NotFound();
            }
            evt.Title = eventDto.Title;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.Allday = eventDto.Allday;
            context.SaveChanges();
            return Ok(evt);

        }
        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            var evt = context.Events.Find(id);
            if( evt == null)
            {
                return NotFound();
            }
            context.Events.Remove(evt);
            context.SaveChanges();
            return Ok();
        }

    }
}
