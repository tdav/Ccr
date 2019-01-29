﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
  public class HighContrastDescriptorToBrushConverter
	  : XamlConverter<
	    Swatch,
	    AbstractMaterialDescriptor,
	    bool,
	    SolidColorBrush,
	    double,
	    NullParam,
	    SolidColorBrush>
  {
    public override SolidColorBrush Convert(
      Swatch materialSet,
      AbstractMaterialDescriptor descriptor,
      bool isHighConstrast,
      SolidColorBrush overlayedBackground,
      double highContrastBindingThreshold,
      NullParam param)
    {
      //TODO dont return red. use transparent MaterialSet as default 
      if (materialSet == null || descriptor == null)
        return Brushes.Red;

      var originalBrush = descriptor.GetMaterial(materialSet);

      if (!isHighConstrast)
        return originalBrush;

      var invertedBrush = originalBrush.Invert();

      //var originalBrushDelta = originalBrush.Differential(overlayedBackground);
      //var invertedBrushDelta = invertedBrush.Differential(overlayedBackground);

      var originalHSL = originalBrush.Color.ToHslColor();
      var invertedHSL = invertedBrush.Color.ToHslColor();
      var overlayedHSL = overlayedBackground.Color.ToHslColor();

      var lightnessDifferenceToOriginal = Math.Abs(originalHSL.L - overlayedHSL.L);
      var lightnessDifferenceToInverted = Math.Abs(invertedHSL.L - overlayedHSL.L);

      //if (lightnessDifferenceToInverted < lightnessDifferenceToOriginal)
      if (lightnessDifferenceToOriginal > highContrastBindingThreshold)
      {
        return originalBrush;
      }
      return invertedBrush;
    }
  }
}
