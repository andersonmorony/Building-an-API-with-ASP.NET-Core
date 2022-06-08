using Agend.Models;
using Agend.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agend.ViewModel;

namespace Agend.Profiles
{
    public class AgendProfile : Profile
    {
        public AgendProfile()
        {
            CreateMap<AgendsModel, AgendViewModel>()
                .ForMember(d => d.Service, o => o.MapFrom(m => m.ServiceType.Name))
                .ForMember(s => s.ServiceStatus, m => m.MapFrom(d => d.ServiceType.IsActive));
        }
    }
}
