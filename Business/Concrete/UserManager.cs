using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<IResult> DeleteAsync(int userId, string modifiedByName)
        {
            var result = await _userDal.AnyAsync(u => u.Id == userId);
            if (result)
            {
                var user = await _userDal.GetAsync(u => u.Id == userId);
                user.IsActive = false;
                user.ModifiedByName = modifiedByName;
                user.ModifiedDate = DateTime.Now;
                await _userDal.UpdateAsync(user);
                return new SuccessResult(Messages.User.Delete(user.FirstName, user.LastName));
            }
            return new ErrorResult(Messages.User.NotFound(isPlural: false));
        }

        public async Task<IDataResult<List<User>>> GetAllAsync()
        {
            var users = await _userDal.GetAllAsync();
            if (users.Count > -1)
            {
                return new SuccessDataResult<List<User>>();
            }
            return new ErrorDataResult<List<User>>(Messages.User.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<User>>> GetAllByNonDeletedAndActiveAsync()
        {
            var users = await _userDal.GetAllAsync(u => !u.IsDeleted && u.IsActive);
            if (users.Count > -1)
            {
                return new SuccessDataResult<List<User>>();
            }
            return new ErrorDataResult<List<User>>(Messages.User.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<User>>> GetAllByNonDeletedAsync()
        {
            var users = await _userDal.GetAllAsync(u => !u.IsDeleted);
            if (users.Count > -1)
            {
                return new SuccessDataResult<List<User>>();
            }
            return new ErrorDataResult<List<User>>(Messages.User.NotFound(isPlural: true));
        }

        public async Task<IDataResult<User>> GetAsync(int userId)
        {
            var user = await _userDal.GetAsync(u => u.Id == userId);
            if (user != null)
            {
                return new SuccessDataResult<User>();
            }
            return new ErrorDataResult<User>(Messages.User.NotFound(isPlural: true));
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email);
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }

        public async Task<IResult> HardDeleteAsync(int userId)
        {
            var result = await _userDal.AnyAsync(u => u.Id == userId);
            if (result)
            {
                var user = await _userDal.GetAsync(u => u.Id == userId);
                await _userDal.DeleteAsync(user);
                return new SuccessResult(Messages.User.HardDelete(user.FirstName, user.LastName));
            }
            return new SuccessResult(Messages.User.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(User user, string modifiedByName)
        {
            var oldUser = await _userDal.GetAsync(u => u.Id == user.Id);
            oldUser.ModifiedByName = modifiedByName;
            var updatedUser = await _userDal.UpdateAsync(oldUser);
            return new SuccessResult(Messages.User.Update(updatedUser.FirstName, updatedUser.LastName));
        }
    }
}
