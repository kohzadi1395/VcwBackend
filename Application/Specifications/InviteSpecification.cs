using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Specifications
{
    public class InviteSpecification : BaseSpecification<Invite>
    {
//        public InviteSpecification(Guid inviteId)
//            : base(b => b.Id == inviteId)
//        {
//            AddInclude(b => b.PersonalInfo);
//        }
        public InviteSpecification(Expression<Func<Invite, bool>> criteria) : base(criteria)
        {
            AddInclude(x => x.Challenge);
            AddInclude(x => x.User);
        }
    }
}