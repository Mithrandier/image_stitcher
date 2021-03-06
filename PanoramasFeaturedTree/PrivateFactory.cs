﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Processors;

namespace Panoramas.FeaturedTrees {
  public class PrivateFactory : Panoramas.Defaults.DefaultsFactory {
    public override ITransformation Transformation() {
      return new Panoramas.HomographyTransformer.Transformation();
    }

    public override IAnalyzer Analyzer() {
      return new Panoramas.FeaturesAnalyzer.Analyzer(this);
    }

    public override IBuilder Builder() {
      return new Panoramas.TreeBuilder.Builder(this);
    }

    public override IPresenter Presenter() {
      return new Panoramas.BoundsPresenter.Presenter(this);
    }
  }
}
