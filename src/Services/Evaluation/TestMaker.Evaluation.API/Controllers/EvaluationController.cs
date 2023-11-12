using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMaker.Evaluation.Application.Interfaces;
using TestMaker.Evaluation.Domain.Interfaces;

namespace TestMaker.Evaluation.API.Controllers
{
    [ApiController]
    [Route("api/evaluations")]
    public class EvaluationController : ControllerBase
    {
        private const int EvaluationCacheTimeout = 600;
        private readonly IEvaluationRepository _repository;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;

        public EvaluationController(IEvaluationRepository repository, ICacheService cache, IMapper mapper)
        {
            _repository = repository;
            _cache = cache;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.EvaluationModel evaluationModel)
        {
            if (evaluationModel is null)
                return BadRequest("Invalid evaluation.");

            var evaluation = _mapper.Map<Domain.Entities.Evaluation>(evaluationModel);
            await _repository.CreateOrUpdateAsync(evaluation);
            await _cache.AddAsync(evaluation.Guid, JsonConvert.SerializeObject(evaluation), EvaluationCacheTimeout);

            return CreatedAtAction(nameof(Get), new { guid = evaluation.Guid }, evaluation);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string guid)
        {
            var evaluation = await _cache.GetAsync(guid, async () =>
            {
                return await _repository.Get(guid);
            }, EvaluationCacheTimeout);
            return Ok(evaluation);
        }
    }
}
