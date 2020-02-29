﻿using System.Windows;
using System.Windows.Media;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public static class ButtonProgressAssist
	{
		public static readonly DependencyProperty MinimumProperty = DependencyProperty.RegisterAttached(
			"Minimum", typeof(double), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(double)));

		public static readonly DependencyProperty MaximumProperty = DependencyProperty.RegisterAttached(
			"Maximum", typeof(double), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(100.0));

		public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
			"Value", typeof(double), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(double)));

		public static readonly DependencyProperty IsIndeterminateProperty = DependencyProperty.RegisterAttached(
			"IsIndeterminate", typeof(bool), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(bool)));
		
		public static readonly DependencyProperty IndicatorForegroundProperty = DependencyProperty.RegisterAttached(
			"IndicatorForeground", typeof(Brush), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(Brush)));

		public static readonly DependencyProperty IndicatorBackgroundProperty = DependencyProperty.RegisterAttached(
			"IndicatorBackground", typeof(Brush), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(Brush)));

		public static readonly DependencyProperty IsIndicatorVisibleProperty = DependencyProperty.RegisterAttached(
			"IsIndicatorVisible", typeof(bool), typeof(ButtonProgressAssist), new FrameworkPropertyMetadata(default(bool)));


		public static double GetMinimum(DependencyObject element)
		{
			return (double)element.GetValue(MinimumProperty);
		}
		public static void SetMinimum(DependencyObject element, double value)
		{
			element.SetValue(MinimumProperty, value);
		}

		public static double GetMaximum(DependencyObject element)
		{
			return (double)element.GetValue(MaximumProperty);
		}
		public static void SetMaximum(DependencyObject element, double value)
		{
			element.SetValue(MaximumProperty, value);
		}

		public static double GetValue(DependencyObject element)
		{
			return (double)element.GetValue(ValueProperty);
		}
		public static void SetValue(DependencyObject element, double value)
		{
			element.SetValue(ValueProperty, value);
		}

		public static bool GetIsIndeterminate(DependencyObject element)
		{
			return (bool)element.GetValue(IndicatorForegroundProperty);
		}
		public static void SetIsIndeterminate(DependencyObject element, bool isIndeterminate)
		{
			element.SetValue(IsIndeterminateProperty, isIndeterminate);
		}

		public static Brush GetIndicatorForeground(DependencyObject element)
		{
			return (Brush)element.GetValue(IndicatorForegroundProperty);
		}
		public static void SetIndicatorForeground(DependencyObject element, Brush indicatorForeground)
		{
			element.SetValue(IndicatorForegroundProperty, indicatorForeground);
		}

		public static Brush GetIndicatorBackground(DependencyObject element)
		{
			return (Brush)element.GetValue(IndicatorForegroundProperty);
		}
		public static void SetIndicatorBackground(DependencyObject element, Brush indicatorBackground)
		{
			element.SetValue(IndicatorBackgroundProperty, indicatorBackground);
		}

		public static bool GetIsIndicatorVisible(DependencyObject element)
		{
			return (bool)element.GetValue(IndicatorForegroundProperty);
		}
		public static void SetIsIndicatorVisible(DependencyObject element, bool isIndicatorVisible)
		{
			element.SetValue(IsIndicatorVisibleProperty, isIndicatorVisible);
		}
	}
}