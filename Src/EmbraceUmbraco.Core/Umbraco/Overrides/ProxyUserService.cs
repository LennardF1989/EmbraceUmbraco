using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Persistence.Querying;
using Umbraco.Cms.Core.Services;

namespace EmbraceUmbraco.Core.Umbraco.Overrides;

public class ProxyUserService : IUserService
{
    private readonly IUserService _originalUserService;

    public ProxyUserService(IUserService originalUserService)
    {
        _originalUserService = originalUserService;
    }

    public int GetCount(MemberCountType countType)
    {
        return _originalUserService.GetCount(countType);
    }

    public bool Exists(string username)
    {
        return _originalUserService.Exists(username);
    }

    public IUser CreateWithIdentity(string username, string email, string passwordValue, string memberTypeAlias)
    {
        return _originalUserService.CreateWithIdentity(username, email, passwordValue, memberTypeAlias);
    }

    public IUser CreateWithIdentity(string username, string email, string passwordValue, string memberTypeAlias,
        bool isApproved)
    {
        return _originalUserService.CreateWithIdentity(username, email, passwordValue, memberTypeAlias, isApproved);
    }

    public IUser GetByProviderKey(object id)
    {
        return _originalUserService.GetByProviderKey(id);
    }

    public IUser GetByEmail(string email)
    {
        return _originalUserService.GetByEmail(email);
    }

    public IUser GetByUsername(string username)
    {
        return _originalUserService.GetByUsername(username);
    }

    public void Delete(IUser membershipUser)
    {
        _originalUserService.Delete(membershipUser);
    }

    public void Save(IUser entity)
    {
        _originalUserService.Save(entity);
    }

    public void Save(IEnumerable<IUser> entities)
    {
        _originalUserService.Save(entities);
    }

    public IEnumerable<IUser> FindByEmail(string emailStringToMatch, long pageIndex, int pageSize,
        out long totalRecords,
        StringPropertyMatchType matchType = StringPropertyMatchType.StartsWith)
    {
        return _originalUserService.FindByEmail(emailStringToMatch, pageIndex, pageSize, out totalRecords,
            matchType);
    }

    public IEnumerable<IUser> FindByUsername(string login, long pageIndex, int pageSize, out long totalRecords,
        StringPropertyMatchType matchType = StringPropertyMatchType.StartsWith)
    {
        return _originalUserService.FindByUsername(login, pageIndex, pageSize, out totalRecords, matchType);
    }

    public IEnumerable<IUser> GetAll(long pageIndex, int pageSize, out long totalRecords)
    {
        return _originalUserService.GetAll(pageIndex, pageSize, out totalRecords);
    }

    public IUser CreateUserWithIdentity(string username, string email)
    {
        return _originalUserService.CreateUserWithIdentity(username, email);
    }

    public Guid CreateLoginSession(int userId, string requestingIpAddress)
    {
        return _originalUserService.CreateLoginSession(userId, requestingIpAddress);
    }

    public bool ValidateLoginSession(int userId, Guid sessionId)
    {
        return _originalUserService.ValidateLoginSession(userId, sessionId);
    }

    public void ClearLoginSession(Guid sessionId)
    {
        _originalUserService.ClearLoginSession(sessionId);
    }

    public int ClearLoginSessions(int userId)
    {
        return _originalUserService.ClearLoginSessions(userId);
    }

    public IDictionary<UserState, int> GetUserStates()
    {
        return _originalUserService.GetUserStates();
    }

    public IEnumerable<IUser> GetAll(long pageIndex, int pageSize, out long totalRecords, string orderBy,
        Direction orderDirection,
        UserState[] userState = null, string[] includeUserGroups = null, string[] excludeUserGroups = null,
        IQuery<IUser> filter = null)
    {
        return _originalUserService.GetAll(pageIndex, pageSize, out totalRecords, orderBy, orderDirection, userState,
            includeUserGroups, excludeUserGroups, filter);
    }

    public IEnumerable<IUser> GetAll(long pageIndex, int pageSize, out long totalRecords, string orderBy,
        Direction orderDirection,
        UserState[] userState = null, string[] userGroups = null, string filter = null)
    {
        return _originalUserService.GetAll(pageIndex, pageSize, out totalRecords, orderBy, orderDirection,
            userState, userGroups, filter);
    }

    public void Delete(IUser user, bool deletePermanently)
    {
        _originalUserService.Delete(user, deletePermanently);
    }

    public IProfile GetProfileById(int id)
    {
        return _originalUserService.GetProfileById(id);
    }

    public IProfile GetProfileByUserName(string username)
    {
        return _originalUserService.GetProfileByUserName(username);
    }

    public IUser GetUserById(int id)
    {
        return _originalUserService.GetUserById(id);
    }

    public IEnumerable<IUser> GetUsersById(params int[] ids)
    {
        return _originalUserService.GetUsersById(ids);
    }

    public void DeleteSectionFromAllUserGroups(string sectionAlias)
    {
        _originalUserService.DeleteSectionFromAllUserGroups(sectionAlias);
    }

    public EntityPermissionCollection GetPermissions(IUser user, params int[] nodeIds)
    {
        return _originalUserService.GetPermissions(user, nodeIds);
    }

    public EntityPermissionCollection
        GetPermissions(IUserGroup[] groups, bool fallbackToDefaultPermissions, params int[] nodeIds)
    {
        return _originalUserService.GetPermissions(groups, fallbackToDefaultPermissions, nodeIds);
    }

    public EntityPermissionSet GetPermissionsForPath(IUser user, string path)
    {
        return _originalUserService.GetPermissionsForPath(user, path);
    }

    public EntityPermissionSet GetPermissionsForPath(IUserGroup[] groups, string path,
        bool fallbackToDefaultPermissions = false)
    {
        return _originalUserService.GetPermissionsForPath(groups, path, fallbackToDefaultPermissions);
    }

    public void ReplaceUserGroupPermissions(int groupId, IEnumerable<char> permissions, params int[] entityIds)
    {
        _originalUserService.ReplaceUserGroupPermissions(groupId, permissions, entityIds);
    }

    public void AssignUserGroupPermission(int groupId, char permission, params int[] entityIds)
    {
        _originalUserService.AssignUserGroupPermission(groupId, permission, entityIds);
    }

    public IEnumerable<IUser> GetAllInGroup(int? groupId)
    {
        return _originalUserService.GetAllInGroup(groupId);
    }

    public IEnumerable<IUser> GetAllNotInGroup(int groupId)
    {
        return _originalUserService.GetAllNotInGroup(groupId);
    }

    public IEnumerable<IUser> GetNextUsers(int id, int count)
    {
        return _originalUserService.GetNextUsers(id, count);
    }

    public IEnumerable<IUserGroup> GetAllUserGroups(params int[] ids)
    {
        return _originalUserService.GetAllUserGroups(ids);
    }

    public IEnumerable<IUserGroup> GetUserGroupsByAlias(params string[] alias)
    {
        return _originalUserService.GetUserGroupsByAlias(alias);
    }

    public IUserGroup GetUserGroupByAlias(string name)
    {
        return _originalUserService.GetUserGroupByAlias(name);
    }

    public IUserGroup GetUserGroupById(int id)
    {
        return _originalUserService.GetUserGroupById(id);
    }

    public void Save(IUserGroup userGroup, int[] userIds = null)
    {
        _originalUserService.Save(userGroup, userIds);
    }

    public void DeleteUserGroup(IUserGroup userGroup)
    {
        _originalUserService.DeleteUserGroup(userGroup);
    }
}