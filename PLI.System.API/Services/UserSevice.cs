using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.Core.Services;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using System.Linq.Expressions;

namespace PLI.System.API.Services
{
    public class UserService : BaseService<User, UserViewModel>, IUserService
    {
        private readonly IBaseMapper<User, UserViewModel> _userViewModelMapper;
        private readonly IUserRepository _userRepository;

        public UserService(
            IBaseMapper<User, UserViewModel> userViewModelMapper,
            IUserRepository userRepository)
            : base(userViewModelMapper, userRepository)
        {
            _userViewModelMapper = userViewModelMapper;
            _userRepository = userRepository;
        }

        //public new async Task<IEnumerable<UserViewModel>> GetAll(CancellationToken cancellationToken)
        //{
        //    var includeList = new List<Expression<Func<User, object>>> { x => x.Role };
        //    var entities = await _userRepository.GetAll(includeList, cancellationToken);

        //    return _userViewModelMapper.MapList(entities);
        //}

        //public new async Task<PaginatedDataViewModel<UserViewModel>> GetPaginatedData(int pageNumber, int pageSize, CancellationToken cancellationToken)
        //{
        //    var includeList = new List<Expression<Func<User, object>>> { x => x.Role };

        //    var paginatedData = await _userRepository.GetPaginatedData(includeList, pageNumber, pageSize, cancellationToken);
        //    var mappedData = _userViewModelMapper.MapList(paginatedData.Data);
        //    var paginatedDataViewModel = new PaginatedDataViewModel<UserViewModel>(mappedData.ToList(), paginatedData.TotalCount);
        //    return paginatedDataViewModel;
        //}

        //public async Task<UserViewModel> GetById(int id, CancellationToken cancellationToken)
        //{
        //    var includeList = new List<Expression<Func<User, object>>> { x => x.Role };

        //    return _userViewModelMapper.MapModel(await _userRepository.GetById(includeList, id, cancellationToken));
        //}

        public async Task<int> Create(UserCreateViewModel model, CancellationToken cancellationToken)
        {
            //var result = await _userRepository.Create(model);
            //if (result.Succeeded)
            //{
            //    return new ResponseViewModel { Success = true, Message = "User created successfully" };
            //}
            //else
            //{
            //    return new ResponseViewModel
            //    {
            //        Success = false,
            //        Message = "User creation failed",
            //        Error = new ErrorViewModel
            //        {
            //            Code = "USER_CREATION_ERROR",
            //            Message = string.Join(", ", result.Errors.Select(e => e.Description))
            //        }
            //    };
            //}
            return 0;
        }

        public async Task<int> Update(UserUpdateViewModel model, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Update(model);
            //if (result.Succeeded)
            //{
            //    return new ResponseViewModel { Success = true, Message = "User updated successfully" };
            //}
            //else
            //{
            //    return new ResponseViewModel
            //    {
            //        Success = false,
            //        Message = "User update failed",
            //        Error = new ErrorViewModel
            //        {
            //            Code = "USER_UPDATE_ERROR",
            //            Message = string.Join(", ", result.Errors.Select(e => e.Description))
            //        }
            //    };
            //}
            return 0;
        }

        //public async Task<ResponseViewModel> ResetPassword(ResetPasswordViewModel model)
        //{
        //    var result = await _userRepository.ResetPassword(model);
        //    if (result.Succeeded)
        //    {
        //        return new ResponseViewModel { Success = true, Message = "Password reset successfully" };
        //    }
        //    else
        //    {
        //        return new ResponseViewModel
        //        {
        //            Success = false,
        //            Message = "Password reset failed",
        //            Error = new ErrorViewModel
        //            {
        //                Code = "PASSWORD_RESET_ERROR",
        //                Message = string.Join(", ", result.Errors.Select(e => e.Description))
        //            }
        //        };
        //    }
        //}

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetById(id, cancellationToken);
            await _userRepository.Delete(entity, cancellationToken);
        }

        //Task<IEnumerable<UserViewModel>> IUserService.GetAll(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<PaginatedDataViewModel<UserViewModel>> IUserService.GetPaginatedData(int pageNumber, int pageSize, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        Task<UserViewModel> IUserService.GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //Task<ResponseViewModel> IUserService.Create(UserCreateViewModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<ResponseViewModel> IUserService.Update(UserUpdateViewModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserService.Delete(int id, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}