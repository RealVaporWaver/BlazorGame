@*﻿using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions;
using Microsoft.JSInterop;

namespace Weed.Pages
{
    public class IndexComponent
    {
        BECanvasComponent _canvasReference = null;
        Canvas2DContext _outputCanvasContext;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;
            _outputCanvasContext = await _canvasReference.CreateCanvas2DAsync();

            await JsRuntime.InvokeAsync<object>("initGame", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public async ValueTask GameLoop(float timeStamp)
        {
            await _outputCanvasContext.ClearRectAsync(0, 0, 300, 400);

            await _outputCanvasContext.SetFillStyleAsync("green");
            await _outputCanvasContext.FillRectAsync(10, 50, 300, 100);

            await _outputCanvasContext.SetFontAsync("24px verdana");
            await _outputCanvasContext.StrokeTextAsync($"time: {timeStamp}", 20, 80);
        }
    }
}*@
