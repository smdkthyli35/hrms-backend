using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<IResult> AddAsync(City city, string createdByName)
        {
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

        public async Task<IDataResult<List<City>>> GetAllAsync()
        {
            var cities = await _cityDal.GetAllAsync();
            if (cities.Count > -1)
            {
                return new SuccessDataResult<List<City>>();
            }
            return new ErrorDataResult<List<City>>(Messages.City.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<City>>> GetAllByNonDeletedAndActiveAsync()
        {
            var cities = await _cityDal.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (cities.Count > -1)
            {
                return new SuccessDataResult<List<City>>();
            }
            return new ErrorDataResult<List<City>>(Messages.City.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<City>>> GetAllByNonDeletedAsync()
        {
            var cities = await _cityDal.GetAllAsync(c => !c.IsDeleted);
            if (cities.Count > -1)
            {
                return new SuccessDataResult<List<City>>();
            }
            return new ErrorDataResult<List<City>>(Messages.City.NotFound(isPlural: true));
        }

        public async Task<IDataResult<City>> GetAsync(int cityId)
        {
            var city = await _cityDal.GetAsync(c => c.Id == cityId);
            if (city != null)
            {
                return new SuccessDataResult<City>();
            }
            return new ErrorDataResult<City>(Messages.City.NotFound(isPlural: false));
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

        public async Task<IResult> UpdateAsync(City city, string modifiedByName)
        {
            var oldCity = await _cityDal.GetAsync(a => a.Id == city.Id);
            oldCity.ModifiedByName = modifiedByName;
            var updatedCity = await _cityDal.UpdateAsync(oldCity);
            return new SuccessResult(Messages.City.Update(updatedCity.Name));
        }
    }
}
