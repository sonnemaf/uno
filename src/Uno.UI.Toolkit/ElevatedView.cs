using System;
using System.Collections.Generic;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Uno.Disposables;
using Uno;
using Uno.Extensions;
using Uno.UI.Extensions;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

namespace Uno.UI.Toolkit
{
	public partial class ElevatedView : ContentControl
	{
		public ElevatedView()
		{
			DefaultStyleKey = typeof(ElevatedView);
		}

		public double Elevation
		{
			get => (double)GetValue(ElevationProperty);
			set => SetValue(ElevationProperty, value);
		}

		public static readonly DependencyProperty ElevationProperty = DependencyProperty.Register(
			nameof(Elevation),
			typeof(double),
			typeof(ElevatedView),
			new PropertyMetadata(default(double), OnElevationChanged));

		private static void OnElevationChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (dependencyObject is UIKit.UIView view && args.NewValue is double elevation)
			{
				// Values for 1dp elevation according to https://material.io/guidelines/resources/shadows.html#shadows-illustrator
				//const float Opacity = 0.26f;
				//const float X = 0;
				//const float Y = 0.92f * 0.5f; // Looks more accurate than the recommended 0.92f. 
				//const float Blur = 0.5f;

				//view.Layer.MasksToBounds = false;
				//view.Layer.ShadowOpacity = Opacity;
				//view.Layer.ShadowRadius = (nfloat)(Blur * elevation);
				//view.Layer.ShadowOffset = new CGSize(X * elevation, Y * elevation);
			}
		}

	}
}
