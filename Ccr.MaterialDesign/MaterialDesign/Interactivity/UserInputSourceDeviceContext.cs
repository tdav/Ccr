﻿namespace Ccr.MaterialDesign.Interactivity
{
	public enum SourceDeviceKind
	{
		MouseClick,
		TouchScreenTap,
		TouchScreenPenManipulation,
		PhysicalKeyboard,
		OnScreenKeyboard
	}


	public class UserInputSourceDeviceContext
	{
		private SourceDeviceKind? _sourceDeviceKind;

		public SourceDeviceKind SourceDeviceKind
		{
			get => _sourceDeviceKind ??
				(_sourceDeviceKind = _determineDeviceKind()).Value;
		}


		private SourceDeviceKind _determineDeviceKind()
		{
			return SourceDeviceKind.MouseClick;
		}
	}
}
