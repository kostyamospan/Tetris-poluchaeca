﻿using System;

namespace Tetris
{
    class ConsoleContainer
    {
        public Frame RenderedFrame { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Position Position { get; private set; }

        private ConsoleRenderer _renderer;
        //private ConsoleWindowRefreshEventProvider _eventProvider;

        public ConsoleContainer(int width, int heigth, Position position = null)
        {

            Position = position ?? new Position(0, 0);

            Width = width;
            Height = heigth;

            RenderedFrame = GenerateEmptyFrame();

            _renderer = new ConsoleRenderer();
            //_eventProvider = ConsoleWindowRefreshEventProvider.GetInstance();
           

        }

        public void SetRenderFrame(Frame frame)
        {
            RenderedFrame = frame;
        }
        
        /*public void StartRender()
        {
            _eventProvider.RefreshEvent += _eventProvider_RefreshEvent;
        }*/

        public void RenderFrame()
        {
            _renderer.RenderContainer(this);
        }
        public Frame GenerateEmptyFrame()
        {
            Pixel[,] pixels = new Pixel[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    pixels[i, j] = new Pixel(ConsoleColor.Green, PixelTypes.Empty);
                }
            }

            return new Frame(pixels);
        }


        //private void _eventProvider_RefreshEvent(object sender, EventArgs e) => _renderer.RenderContainer(this);
        private class ConsoleRenderer
        {
            private Frame lastFrame;

            public void RenderContainer(ConsoleContainer container)
            {
                int containerPosX = container.Position.X;
                int containerPosY = container.Position.Y;

                Pixel[,] mas = container.RenderedFrame.Pixels;

                for (int i = 0; i < container.Height; i++)
                {
                    for (int j = 0; j < container.Width; j++)
                    {
                        if (lastFrame != null && mas[i, j].Equals(lastFrame.Pixels[i, j]))
                            continue;

                        Console.SetCursorPosition(j + containerPosX, i + containerPosY);
                        mas[i, j].WriteToConsole();
                    }
                }

                lastFrame = (Frame)container.RenderedFrame.Clone();  
            }
        }

       
    }
}
