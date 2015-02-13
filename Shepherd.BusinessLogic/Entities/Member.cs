using Shepherd.BusinessLogic.Entities.Contracts;
using System;

namespace Shepherd.BusinessLogic.Entities
{
	internal sealed class Member : IMember
	{
		public int PersonId { get; private set; }

		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }


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

		public IMember Fetch(int id)
		{
			throw new NotImplementedException();
		}
	}
}