using AutoMapper;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models;
using System;


namespace heroesCompanyAngular.Mapping {
    public class HeroProfile : Profile {
        const decimal MAX_POWER = 100;
        const decimal MIN_POWER = 1;
        public decimal SetPower(decimal power) {
            if (power < MIN_POWER)
                return MIN_POWER;
            if (power > MAX_POWER)
                return MAX_POWER;
            return power;
        }
        public HeroProfile() {
            CreateMap<HeroDto, Hero>()
            .ForMember(hero => hero.Id, opt => opt.MapFrom(heroDto => Guid.NewGuid()))
            .ForMember(hero => hero.InitialTrainDate, opt => opt.MapFrom(heroDto => DateTime.Now))
            .ForMember(hero => hero.TrainedDate, opt => opt.MapFrom(heroDto => DateTime.Now))
            .ForMember(hero => hero.StartingPower, opt => opt.MapFrom(heroDto => SetPower(heroDto.StartingPower)))
            .ForMember(hero => hero.CurrentPower, opt => opt.MapFrom(heroDto => SetPower(heroDto.StartingPower)));
        }  
    }
}
