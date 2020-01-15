using Uno.UI.Samples.Controls;
using Uno.UI.Samples.Presentation.SamplePages;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Samples.Content.UITests.ButtonTestsControl
{
	[SampleControlInfo("Button", "Custom_Button_With_ContentTemplate_And_StackPanel", typeof(ButtonTestsViewModel))]

	public sealed partial class Custom_Button_With_ContentTemplate_And_StackPanel : Page
	{
		public Custom_Button_With_ContentTemplate_And_StackPanel()
		{
			this.InitializeComponent();
			DataContext = new ButtonTestsViewModel(Dispatcher);
		}
	}
}
