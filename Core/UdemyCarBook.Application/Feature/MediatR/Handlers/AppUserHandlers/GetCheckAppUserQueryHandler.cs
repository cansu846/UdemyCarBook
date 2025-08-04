using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Queries.AppUserQueries;
using UdemyCarBook.Application.Feature.MediatR.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;

namespace UdemyCarBook.Application.Feature.MediatR.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            var value = new GetCheckAppUserQueryResult();
            if (appUser == null)
            {
                value.IsUserExist = false;
            }
            else
            {
                value.IsUserExist = true;
                value.AppUserId=appUser.AppUserId;
                value.Username=appUser.Username;
                value.Role=appUser.AppRole.AppRoleName;
            }
            return value;
        }
    }
}
