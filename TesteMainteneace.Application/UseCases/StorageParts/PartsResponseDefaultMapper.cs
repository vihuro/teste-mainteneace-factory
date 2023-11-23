using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMainteneace.Domain.Entities.StorageParts;
using TesteMainteneace.Domain.Interfaces.Storage;

namespace TesteMainteneace.Application.UseCases.StorageParts
{
    public class PartsResponseDefaultMapper : Profile
    {
        public PartsResponseDefaultMapper() 
        {
            CreateMap<StoragePartsEntity, PartsResponseDefault>();
        }
    }
}
