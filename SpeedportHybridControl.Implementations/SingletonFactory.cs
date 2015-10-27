using System.Threading;

namespace SpeedportHybridControl.Implementations {
	public abstract class SingletonFactory<T> where T : SingletonFactory<T>, new() {
		private static T _instance;

		public static T getInstance () {
			if (_instance == null)
				Interlocked.CompareExchange(ref _instance, new T(), null);

			return _instance;
		}
	}
}
