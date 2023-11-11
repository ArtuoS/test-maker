using AutoMapper;
using TestMaker.Evaluation.API.Models;

namespace TestMaker.Evaluation.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Evaluation, EvaluationModel>();
            CreateMap<EvaluationModel, Domain.Entities.Evaluation>();

            CreateMap<Domain.Entities.Question, QuestionModel>();
            CreateMap<QuestionModel, Domain.Entities.Question>();

            CreateMap<Domain.Entities.Alternative, AlternativeModel>();
            CreateMap<AlternativeModel, Domain.Entities.Alternative>();

            CreateMap<Domain.Entities.AlternativeAttributes, AlternativeAttributesModel>();
            CreateMap<AlternativeAttributesModel, Domain.Entities.AlternativeAttributes>();
        }
    }
}
