using System;
using System.Collections.Concurrent;

namespace FaceRecognitionDotNet.Server.Helpers
{

    internal static class Cache
    {

        #region Properties

        private static readonly ConcurrentBag<IResource<FaceRecognition>> Resources = new ConcurrentBag<IResource<FaceRecognition>>();

        #endregion

        #region Methods

        public static void Initialize(string directory, uint cacheSize)
        {
            foreach (var resource in Resources) resource?.Object?.Dispose();
            for (var count = 0; count < cacheSize; count++)
                Resources.Add(new Resource(FaceRecognition.Create(directory), Resources));
        }

        public static bool TryGetResource(out IResource<FaceRecognition> resource)
        {
            return Resources.TryTake(out resource);
        }

        #endregion

        private class Resource : IResource<FaceRecognition>
        {

            #region Fields

            private readonly ConcurrentBag<IResource<FaceRecognition>> _Bag;

            #endregion

            #region Constructors

            public Resource(FaceRecognition obect, ConcurrentBag<IResource<FaceRecognition>> bag)
            {
                this.Object = obect;
                this._Bag = bag;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets a value indicating whether this instance has been disposed.
            /// </summary>
            /// <returns>true if this instance has been disposed; otherwise, false.</returns>
            private bool IsDisposed
            {
                get;
                set;
            }

            public FaceRecognition Object
            {
                get;
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Releases all resources used by this <see cref="DisposableObject"/>.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
                this.Dispose(true);
            }

            /// <summary>
            /// Releases all resources used by this <see cref="DisposableObject"/>.
            /// </summary>
            /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
            private void Dispose(bool disposing)
            {
                if (this.IsDisposed)
                {
                    return;
                }

                this.IsDisposed = true;

                if (disposing)
                {
                    this._Bag.Add(new Resource(this.Object, this._Bag));
                }

            }

            #endregion

        }

    }

}
