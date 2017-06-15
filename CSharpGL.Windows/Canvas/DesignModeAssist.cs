﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class DesignModeAssist
    {
        private Scene scene;
        private string fullname;

        public DesignModeAssist(int width, int height, string fullname)
        {
            var camera = new Camera(new vec3(0, 0, 2.5f), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, width, height);
            RendererGroup group;
            {
                const float factor = 2.0f;
                var box = new LegacyBoundingBoxRenderer() { Scale = new vec3(factor, factor, factor) };
                var clock = new ClockRenderer(new vec3(1, 0.8f, 0));
                group = new RendererGroup(box, clock);
            }
            var scene = new Scene()
            {
                Camera = camera,
                ClearColor = Color.Black,
                RootElement = group,
            };
            this.scene = scene;
            this.fullname = fullname;
        }

        public void Render(bool drawText, int height, double fps)
        {
            this.scene.Render();

            FontBitmaps.DrawText(10,
                10, Color.White, "Courier New",// "Courier New",
                25.0f, this.fullname);
            if (drawText)
            {
                FontBitmaps.DrawText(10,
                    height - 20 - 1, Color.Red, "Courier New",// "Courier New",
                    20.0f, string.Format("FPS: {0}", fps.ToShortString()));
            }
        }

        public void Resize(float width, float height)
        {
            this.scene.Camera.AspectRatio = width / height;
        }
    }
}
