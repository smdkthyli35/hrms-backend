using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly IMapper _mapper;

        public CityManager(ICityDal cityDal, IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }

        [SecuredOperation("city.add,admin")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        public async Task<IResult> AddAsync(CityAddDto cityAddDto, string createdByName)
        {
            var city = _mapper.Map<City>(cityAddDto);
            city.CreatedByName = createdByName;
            city.ModifiedByName = createdByName;
            var addCity = await _cityDal.AddAsync(city);
            return new SuccessResult(Messages.City.Add(addCity.Name));
        }

        public async Task<IResult> DeleteAsync(int cityId, string modifiedByName)
        {
            var result = await _cityDal.AnyAsync(c => c.Id == cityId);
            if (result)
            {
                var city = await _cityDal.GetAsync(c => c.Id == cityId);
                city.IsDeleted = true;
                city.ModifiedByName = modifiedByName;
                city.ModifiedDate = DateTime.Now;
                await _cityDal.UpdateAsync(city);
                return new SuccessResult(Messages.City.Delete(city.Name));
            }
            return new ErrorResult(Messages.City.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<CityListDto>> GetAllAsync()
        {
            var cities = await _cityDal.GetAllAsync();
            if (cities.Count > -1)
            {
                return new SuccessDataResult<CityListDto>(new CityListDto
                {
                    Cities = cities
                });
            }
            return new ErrorDataResult<CityListDto>(Messages.City.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CityListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var cities = await _cityDal.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (cities.Count > -1)
            {
                return new SuccessDataResult<CityListDto>(new CityListDto
                {
                    Cities = cities
                });
            }
            return new ErrorDataResult<CityListDto>(Messages.City.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CityListDto>> GetAllByNonDeletedAsync()
        {
            var cities = await _cityDal.GetAllAsync(c => !c.IsDeleted);
            if (cities.Count > -1)
            {
                return new SuccessDataResult<CityListDto>(new CityListDto
                {
                    Cities = cities
                });
            }
            return new ErrorDataResult<CityListDto>(Messages.City.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CityDto>> GetAsync(int cityId)
        {
            var city = await _cityDal.GetAsync(c => c.Id == cityId);
            if (city != null)
            {
                return new SuccessDataResult<CityDto>(new CityDto
                {
                    City = city
                });
            }
            return new ErrorDataResult<CityDto>(Messages.City.NotFound(isPlural: false));
        }

        public async Task<IDataResult<CityDto>> GetByName(string name)
        {
            var result = await _cityDal.GetByName(name);
            if (result != null)
            {
                return new SuccessDataResult<CityDto>();
            }
            return new ErrorDataResult<CityDto>();
        }

        public async Task<IDataResult<CityListDto>> GetByNameContains(string name)
        {
            var result = await _cityDal.GetByNameContains(name);
            if (result.Count > -1)
            {
                return new SuccessDataResult<CityListDto>();
            }
            return new ErrorDataResult<CityListDto>();
        }

        public async Task<IResult> HardDeleteAsync(int cityId)
        {
            var result = await _cityDal.AnyAsync(c => c.Id == cityId);
            if (result)
            {
                var city = await _cityDal.GetAsync(c => c.Id == cityId);
                await _cityDal.DeleteAsync(city);
                return new SuccessResult(Messages.City.HardDelete(city.Name));
            }
            return new ErrorResult(Messages.City.NotFound(isPlural: false));
        }

        [SecuredOperation("city.update,admin")]
        [ValidationAspect(typeof(CityValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        public async Task<IResult> UpdateAsync(CityUpdateDto cityUpdateDto, string modifiedByName)
        {
            var oldCity = await _cityDal.GetAsync(c => c.Id == cityUpdateDto.Id);
            var city = _mapper.Map<CityUpdateDto, City>(cityUpdateDto, oldCity);
            city.ModifiedByName = modifiedByName;
            await _cityDal.UpdateAsync(city);
            return new SuccessResult(Messages.City.Update(city.Name));
        }
    }
}
