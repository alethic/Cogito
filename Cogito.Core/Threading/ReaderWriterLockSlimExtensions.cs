using System;
using System.Threading;

namespace Cogito.Core.Threading
{

    /// <summary>
    /// Provides extensions to the <see cref="ReaderWriterLockSlim"/>.
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {

        /// <summary>
        /// Enters and exits a read lock.
        /// </summary>
        public readonly struct ReadLock : IDisposable
        {

            readonly ReaderWriterLockSlim rw;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="rw"></param>
            public ReadLock(ReaderWriterLockSlim rw)
            {
                this.rw = rw ?? throw new ArgumentNullException(nameof(rw));

                rw.EnterReadLock();
            }

            public void Dispose()
            {
                rw.ExitReadLock();
            }

        }

        /// <summary>
        /// Enters and exits a read lock.
        /// </summary>
        public readonly struct WriteLock : IDisposable
        {

            readonly ReaderWriterLockSlim rw;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="rw"></param>
            public WriteLock(ReaderWriterLockSlim rw)
            {
                this.rw = rw ?? throw new ArgumentNullException(nameof(rw));

                rw.EnterWriteLock();
            }

            public void Dispose()
            {
                rw.ExitWriteLock();
            }

        }

        /// <summary>
        /// Enters and exits an upgradable read lock.
        /// </summary>
        public readonly struct UpgradableReadLock : IDisposable
        {

            readonly ReaderWriterLockSlim rw;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="rw"></param>
            public UpgradableReadLock(ReaderWriterLockSlim rw)
            {
                this.rw = rw ?? throw new ArgumentNullException(nameof(rw));

                rw.EnterUpgradeableReadLock();
            }

            public void Dispose()
            {
                rw.ExitUpgradeableReadLock();
            }

        }

        /// <summary>
        /// Begins a read lock.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ReadLock BeginReadLock(this ReaderWriterLockSlim self)
        {
            return new ReadLock(self);
        }

        /// <summary>
        /// Begins a write lock.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static WriteLock BeginWriteLock(this ReaderWriterLockSlim self)
        {
            return new WriteLock(self);
        }

        /// <summary>
        /// Begins an upgradable read lock.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static UpgradableReadLock BeginUpgradableReadLock(this ReaderWriterLockSlim self)
        {
            return new UpgradableReadLock(self);
        }

    }

}
