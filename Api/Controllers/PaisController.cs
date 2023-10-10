using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Domain.Interface;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class PaisController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public PaisController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get(){
            var records = await _UnitOfWork.Paises!.GetAllAsync();
            return _Mapper.Map<List<PaisDto>>(records);
        }

        // [HttpGet]
        // [MapToApiVersion("1.1")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<Pager<PaisDto>>> Get11([FromQuery] Params recordParams)
        // {
        //     var record = await _UnitOfWork.Paises!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        //     var lstrecordsDto = _Mapper.Map<List<PaisDto>>(record.registros);
        //     return new Pager<PaisDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        // }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Get(string id)
        {
            var record = await _UnitOfWork.Paises!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<PaisDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(PaisDto recordDto){
            var record = _Mapper.Map<Pais>(recordDto);
            _UnitOfWork.Paises!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            recordDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= recordDto.Id}, recordDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Put(string id, [FromBody]PaisDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Pais>(recordDto);
            _UnitOfWork.Paises!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Paises!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Paises.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

    }
