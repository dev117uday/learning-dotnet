using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Commander.Controller
{
    [Route("api")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo,IMapper mapper)
        {
            _commanderRepo = commanderRepo;
            _mapper = mapper;
        }

        // GET : api/
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET : api/{id}
        [HttpGet("{id}",Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _commanderRepo.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));    
            }

            return NotFound();

        }
        
        // POST : api/
        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandItem = _mapper.Map<Command>(commandCreateDto);
            _commanderRepo.CreateCommand(commandItem);
            _commanderRepo.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandItem);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            //return Ok(commandItem);
        }
        
        // PUT : api/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _commanderRepo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _commanderRepo.UpdateCommand(commandModelFromRepo);
            _commanderRepo.SaveChanges();
            return NoContent();
        }
        
        // PATCH : api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepo = _commanderRepo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            
            _commanderRepo.UpdateCommand(commandModelFromRepo);

            _commanderRepo.SaveChanges();

            return NoContent();

        }
        
    }
}