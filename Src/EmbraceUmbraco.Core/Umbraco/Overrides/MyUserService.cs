using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;

namespace EmbraceUmbraco.Core.Umbraco.Overrides;

public class MyUserService : ProxyUserService, IMembershipMemberService<IUser>
{
    public MyUserService(IUserService originalUserService) 
        : base(originalUserService)
    {
        //Do nothing
    }
    
    IUser IMembershipMemberService<IUser>.GetByEmail(string email)
    {
        return base.GetByEmail(email);
    }
}