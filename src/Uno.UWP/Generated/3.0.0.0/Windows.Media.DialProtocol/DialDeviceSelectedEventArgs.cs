#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.DialProtocol
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class DialDeviceSelectedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::Windows.Media.DialProtocol.DialDevice SelectedDialDevice
		{
			get
			{
				throw new global::System.NotImplementedException("The member DialDevice DialDeviceSelectedEventArgs.SelectedDialDevice is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.DialProtocol.DialDeviceSelectedEventArgs.SelectedDialDevice.get
	}
}
