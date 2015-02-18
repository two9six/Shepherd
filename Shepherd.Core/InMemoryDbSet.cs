using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shepherd.Core
{
	public class InMemoryDbSet<T>
		: IDbSet<T> where T : class
	{
		private ObservableCollection<T> data;
		public ObservableCollection<T> Adds { get; private set; }
		public ObservableCollection<T> Removes { get; private set; }
		public ObservableCollection<T> Attaches { get; private set; }
		public ObservableCollection<T> Detaches { get; private set; }

		private Dictionary<string, T> ResultsForFind;

		private IQueryable query;

		public InMemoryDbSet()
		{
			this.data = new ObservableCollection<T>();
			this.Adds = new ObservableCollection<T>();
			this.Removes = new ObservableCollection<T>();
			this.Attaches = new ObservableCollection<T>();
			this.Detaches = new ObservableCollection<T>();
			this.query = this.data.AsQueryable();
		}

		public InMemoryDbSet(Dictionary<object[], T> resultsForFind)
			: this()
		{
			if (resultsForFind == null)
			{
				throw new ArgumentNullException("resultsForFind");
			}

			this.ResultsForFind = new Dictionary<string, T>();
			foreach (var entry in resultsForFind)
			{
				this.ResultsForFind.Add(string.Join(",", entry.Key), entry.Value);
			}
		}

		public void ClearCollections()
		{
			this.Adds.Clear();
			this.Removes.Clear();
			this.Attaches.Clear();
			this.Detaches.Clear();
		}

		public T Add(T entity)
		{
			this.data.Add(entity);
			this.Adds.Add(entity);
			return entity;
		}

		public T Attach(T entity)
		{
			this.data.Add(entity);
			this.Attaches.Add(entity);
			return entity;
		}

		public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
		{
			return Activator.CreateInstance<TDerivedEntity>();
		}

		public T Create()
		{
			return Activator.CreateInstance<T>();
		}

		public T Find(params object[] keyValues)
		{
			if (keyValues == null || keyValues.Count() == 0 || keyValues.Count() > 1)
			{
				throw new ArgumentException("Parameter is of unexpected size", "keyValues");
			}

			var key = string.Join(",", keyValues);

			if (string.IsNullOrWhiteSpace(key))
			{
				throw new InvalidCastException("Parameter is of unexpected type");
			}

			return this.ResultsForFind != null && this.ResultsForFind.ContainsKey(key) ? this.ResultsForFind[key] : null;
		}

		public ObservableCollection<T> Local
		{
			get { return this.data; }
		}

		public T Remove(T entity)
		{
			this.data.Remove(entity);
			this.Removes.Add(entity);
			return entity;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.data.GetEnumerator();
		}

		public Type ElementType
		{
			get { return this.query.ElementType; }
		}

		public Expression Expression
		{
			get { return this.query.Expression; }
		}

		public IQueryProvider Provider
		{
			get { return this.query.Provider; }
		}
	}
}