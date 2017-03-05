using System.Linq;
using System.Threading;

using WebApi.Repositories.Exceptions;

namespace WebApi.Repositories.InMemory
{
	public abstract class BaseWritableRepository<TKey, TValue> : IWritableRepository<TKey, TValue> where TValue : IWritableRecord<TKey>
	{
		private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);


		public TValue Get(TKey id)
		{
			return GetAll()
				.FirstOrDefault(value => value.Id.Equals(id));
		}

		public IQueryable<TValue> GetAll()
		{
			readerWriterLock.EnterReadLock();
			try
			{
				return GetValues();
			}
			finally
			{
				readerWriterLock.ExitReadLock();
			}
		}


		public void Put(TValue value)
		{
			readerWriterLock.EnterUpgradeableReadLock();
			try
			{
				var oldVersion = value.Version;
				value.Version++;
				if (oldVersion == 0)
				{
					readerWriterLock.EnterWriteLock();
					try
					{
						value.Id = GetNextId();
						Save(value);
					}
					finally
					{
						readerWriterLock.ExitWriteLock();
					}
				}
				else
				{
					var oldValue = Get(value.Id);
					if (oldValue == null)
					{
						throw new UpdateAgainstMissingRecordException<TKey, TValue>(value);
					}
					if (oldValue.Version != value.Version - 1)
					{
						throw new ConcurrentModificationException<TKey, TValue>(oldValue, value);
					}


					readerWriterLock.EnterWriteLock();
					try
					{
						Update(value);
					}
					finally
					{
						readerWriterLock.ExitWriteLock();
					}
				}
			}
			finally
			{
				readerWriterLock.ExitUpgradeableReadLock();
			}
		}

		public void Delete(TKey key)
		{
			readerWriterLock.EnterUpgradeableReadLock();
			try
			{
				var value = Get(key);
				if (value == null)
				{
					return;
				}


				readerWriterLock.EnterWriteLock();
				try
				{
					Delete(value);
				}
				finally
				{
					readerWriterLock.ExitWriteLock();
				}
			}
			finally
			{
				readerWriterLock.ExitUpgradeableReadLock();
			}
		}


		protected abstract IQueryable<TValue> GetValues();

		protected abstract TKey GetNextId();

		protected abstract void Save(TValue value);

		protected abstract void Update(TValue value);

		protected abstract void Delete(TValue value);
	}
}
