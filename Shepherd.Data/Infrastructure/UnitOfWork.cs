using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Contracts.Repository;
using Shepherd.Data.Repository;
using Shepherd.Entities;
using Shepherd.Entities.Contracts;
using System;

namespace Shepherd.Data.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private static readonly UnitOfWork instance = new UnitOfWork();
		public static UnitOfWork Instance { get { return instance; } }

		private IShepherdContext context;
		public IShepherdContext Context
		{
			get
			{
				if (context == null)
				{
                    context = new ShepherdContext();
				}
				return context;
			}
			set
			{
				context = value;
			}
		}

		private IDesignationRepository designationRepository;
		public IDesignationRepository DesignationRepository
		{
			get
			{
				if (designationRepository == null)
				{
					designationRepository = new DesignationRepository();
					designationRepository.Context = this.Context;
				}
				return designationRepository;
			}
			set
			{
				designationRepository = value;
			}
		}

		private IGatheringTypeRepository gatheringTypeRepository;
		public IGatheringTypeRepository GatheringTypeRepository
		{
			get
			{
				if (gatheringTypeRepository == null)
				{
					gatheringTypeRepository = new GatheringTypeRepository();
					gatheringTypeRepository.Context = this.Context;
				}
				return gatheringTypeRepository;
			}
			set
			{
				gatheringTypeRepository = value;
			}
		}

		private IMemberRepository memberRepository;
		public IMemberRepository MemberRepository
		{
			get
			{
				if (memberRepository == null)
				{
					memberRepository = new MemberRepository();
					memberRepository.Context = this.Context;
				}
				return memberRepository;
			}
			set
			{
				memberRepository = value;
			}
		}

		private IMemberStatusRepository memberStatusRepository;
		public IMemberStatusRepository MemberStatusRepository
		{
			get
			{
				if (memberStatusRepository == null)
				{
					memberStatusRepository = new MemberStatusRepository();
					memberStatusRepository.Context = this.Context;
				}
				return memberStatusRepository;
			}
			set
			{
				memberStatusRepository = value;
			}
		}

		private IDesignationTypeRepository memberTypeRepository;
		public IDesignationTypeRepository MemberTypeRepository
		{
			get
			{
				if (memberTypeRepository == null)
				{
					memberTypeRepository = new DesignationTypeRepository();
					memberTypeRepository.Context = this.Context;
				}
				return memberTypeRepository;
			}
			set
			{
				memberTypeRepository = value;
			}
		}

		private IPersonRepository personRepository;
		public IPersonRepository PersonRepository
		{
			get
			{
				if (personRepository == null)
				{
					personRepository = new PersonRepository();
					personRepository.Context = this.Context;
				}
				return personRepository;
			}
			set
			{
				personRepository = value;
			}
		}

		public int Save()
		{
			// TODO: Provide exception handling
			return this.Context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing && context != null)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}