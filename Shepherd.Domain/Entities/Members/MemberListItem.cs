﻿using Shepherd.Domain.Entities.Members.Contracts;
using Shepherd.Core.Helpers;
using Shepherd.Data.Contracts;
using Shepherd.Data.Repository.Contracts;
using SMM = Shepherd.Model.Models;
using System;

namespace Shepherd.Domain.Entities.Members
{
	public sealed class MemberListItem : IMemberListItem<MemberListItem>
	{
		private IUnitOfWork unitOfWork;

		public int MemberId { get; private set; }

		public string Name { get; set; }

		public int AgeInSpirit { get; set; }

		public string Status { get; set; }

		public MemberListItem(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public MemberListItem LoadChild(SMM.Member entity)
		{
			if (entity != null && entity.Person != null)
			{
				this.MemberId = entity.Id;
				this.Name = string.Format("{0} {1}", entity.Person.FirstName, entity.Person.LastName);
				this.AgeInSpirit = DateTimeHelpers.ComputeAge(entity.DateBabtized);

				var lookup = unitOfWork.LookupRepository.GetById(entity.StatusId);
				if (lookup != null)
				{
					this.Status = lookup.Name;
				}
			}

			return this;
		}
	}
}