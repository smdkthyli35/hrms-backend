﻿using Business.Dtos;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IDataResult<CityDto>> GetAsync(int cityId);
        Task<IDataResult<CityListDto>> GetAllAsync();
        Task<IDataResult<CityListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CityListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(CityAddDto cityAddDto, string createdByName);
        Task<IResult> UpdateAsync(CityUpdateDto cityUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int cityId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int cityId);
    }
}
