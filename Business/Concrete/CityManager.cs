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

        public Task<IResult> DeleteAsync(int cityId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<City>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<City>>> GetAllByNonDeletedAndActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<City>>> GetAllByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<City>> GetAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDeleteAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(City city, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
