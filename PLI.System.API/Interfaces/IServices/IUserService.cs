﻿using PLI.System.API.Entities.Business;
using PLI.System.API.Interfaces.IServices;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IUserService : IBaseService<UserViewModel>
    {
        new Task<IEnumerable<UserViewModel>> GetAll(CancellationToken cancellationToken);
        new Task<PaginatedDataViewModel<UserViewModel>> GetPaginatedData(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<UserViewModel> GetById(int id, CancellationToken cancellationToken);
        Task<ResponseViewModel> Create(UserCreateViewModel model, CancellationToken cancellationToken);
        Task<ResponseViewModel> Update(UserUpdateViewModel model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        //Task<ResponseViewModel> ResetPassword(ResetPasswordViewModel model);
    }
}