﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Uno.Extensions;
using Uno.Logging;

namespace Uno.UI.Extensions
{
	public static partial class UIElementExtensions
	{
		public static Thickness GetPadding(this UIElement uiElement)
		{
			if(uiElement is FrameworkElement fe && fe.TryGetPadding(out var padding))
			{
				return padding;
			}

			var property = uiElement.GetDependencyPropertyUsingReflection("PaddingProperty");
			return property != null && uiElement.GetValue(property) is Thickness t ? t : default;
		}

		public static Thickness GetBorderThickness(this UIElement uiElement)
		{
			if (uiElement is FrameworkElement fe && fe.TryGetBorderThickness(out var borderThickness))
			{
				return borderThickness;
			}

			var property = uiElement.GetDependencyPropertyUsingReflection("BorderThicknessProperty");
			return property != null && uiElement.GetValue(property) is Thickness t ? t : default;
		}

		public static bool SetPadding(this UIElement uiElement, Thickness padding)
		{
			if (uiElement is FrameworkElement fe && fe.TrySetPadding(padding))
			{
				return true;
			}

			var property = uiElement.GetDependencyPropertyUsingReflection("PaddingProperty");
			if(property != null)
			{
				uiElement.SetValue(property, padding);
				return true;
			}

			return false;
		}

		public static bool SetBorderThickness(this UIElement uiElement, Thickness borderThickness)
		{
			if (uiElement is FrameworkElement fe && fe.TrySetBorderThickness(borderThickness))
			{
				return true;
			}

			var property = uiElement.GetDependencyPropertyUsingReflection("BorderThicknessProperty");
			if (property != null)
			{
				uiElement.SetValue(property, borderThickness);
				return true;
			}

			return false;
		}

		private static Dictionary<(Type type, string property), DependencyProperty> _dependencyPropertyReflectionCache;

		internal static DependencyProperty GetDependencyPropertyUsingReflection(this UIElement uiElement, string propertyName)
		{
			var type = uiElement.GetType();
			var key = (ownerType: type, propertyName);

			_dependencyPropertyReflectionCache =
				_dependencyPropertyReflectionCache
				?? new Dictionary<(Type, string), DependencyProperty>(2);

			if (_dependencyPropertyReflectionCache.TryGetValue(key, out var property))
			{
				return property;
			}

			property =
				type
					.GetTypeInfo()
					.GetDeclaredProperty(propertyName)
					?.GetValue(null) as DependencyProperty
				?? type
					.GetTypeInfo()
					.GetDeclaredField(propertyName)
					?.GetValue(null) as DependencyProperty;

			_dependencyPropertyReflectionCache[key] = property;

			if (property == null)
			{
				uiElement.Log().Warn($"The {propertyName} dependency property does not exist on {type}");
			}

			return property;
		}
	}
}
