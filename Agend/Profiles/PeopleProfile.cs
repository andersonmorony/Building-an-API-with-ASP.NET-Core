using Agend.Models;
using Agend.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<AgendsModel, PeopleViewModel>()
                .ForMember(e => e.Firstname, a => a.MapFrom(b=> b.People.Firstname))
                .ForMember(e => e.Lastname, a=>a.MapFrom(b=>b.People.Lastname));
        }
    }
}
