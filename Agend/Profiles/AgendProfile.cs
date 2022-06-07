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
            CreateMap<AgendViewModel, AgendsModel>();
        }
    }
}
