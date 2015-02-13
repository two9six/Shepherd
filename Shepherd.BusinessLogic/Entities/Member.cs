using Shepherd.BusinessLogic.Entities.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using System;

namespace Shepherd.BusinessLogic.Entities
{
	public sealed class Member : IMember
	{
		private readonly IMemberRepository memberRepository;
		private readonly IPersonRepository personRepository;
		private readonly IUnitOfWork unitOfWork;

		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public Member()
		{
			this.memberRepository = new Shepherd.Data.Repository.MemberRepository(new Shepherd.Data.Infrastructure.DatabaseFactory());
			this.personRepository = new Shepherd.Data.Repository.PersonRepository(new Shepherd.Data.Infrastructure.DatabaseFactory()); ;
			this.unitOfWork = new Shepherd.Data.Infrastructure.UnitOfWork(new Shepherd.Data.Infrastructure.DatabaseFactory());
		}

		public Member(IMemberRepository memberRepository, IPersonRepository personRepository, IUnitOfWork unitOfWork)
		{
			this.memberRepository = memberRepository;
			this.personRepository = personRepository;
			this.unitOfWork = unitOfWork;
		}


		public void Create(IMember entity)
		{
			throw new NotImplementedException();
		}

		public void Edit(IMember entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Fetch(int id)
		{
			var member = memberRepository.GetById(id);

			if (member != null)
			{
				this.MemberId = member.Id;
				this.GeneratedId = member.GeneratedId;

				var person = personRepository.GetById(member.PersonId);

				if (person != null)
				{
					this.LastName = person.LastName;
					this.FirstName = person.FirstName;
					this.MiddleName = person.MiddleName;
					this.BirthDate = person.BirthDate;
				}
			}
		}
	}
}