using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Application.Models.DTOs;
using TwitterProject.Application.Services.Interfaces;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.UnitOfWork;

namespace TwitterProject.Application.Services.Concretes
{
    public class MentionService : IMentionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MentionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task AddMention(AddMentionDTO addMentionDTO)
        {
            var mention = _mapper.Map<AddMentionDTO, Mention>(addMentionDTO);

            await _unitOfWork.MentionRepository.Add(mention);
            await _unitOfWork.Commit();
        }
    }
}
