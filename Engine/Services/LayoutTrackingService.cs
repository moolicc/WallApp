﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallApp.Engine.Services
{
    public delegate void LayerAdded(LayerSettings layerSettings);
    public delegate void LayerResized(LayerSettings layerSettings);
    public delegate void LayerRemoved(int layerId);

    [Service]
    class LayoutTrackingService : InitializableService
    {
        public event LayerAdded LayerAdded;
        public event LayerRemoved LayerRemoved;
        public event LayerResized LayerResized;


        public Layout Layout { get; private set; }

        public void Init(Layout layout)
        {
            Layout = layout;
        }

        protected override void Initialize()
        {
            var proxyservice = ServiceProvider.GetService<BridgeMessageProxy>();

            proxyservice.LayerCreated += OnCreateLayer;

            base.Initialize();
        }

        private void OnCreateLayer(string module, BridgeService bridgeService)
        {
            var settings = Layout.AddLayer(module);
            settings.DimensionsChanged += LayerDimensionsChanged;
            bridgeService.WriteCreateLayerResponse(settings.LayerId);
            LayerAdded?.Invoke(settings);
        }

        private void LayerDimensionsChanged(object sender)
        {
            LayerResized?.Invoke((LayerSettings)sender);
        }
    }
}