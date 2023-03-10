using System;
using Microsoft.AspNetCore.Components;

namespace Examensarbete.Client.Components
{
	public partial class Timer
	{
        public int Minutes;
        public TimeSpan TimeLeft;
        public TimeSpan StartTime;
        public bool pause;
        public bool StartBtn;
        public bool SetMinutes;

        [Parameter]
        public bool Finish { get; set; } = true;

        [Parameter]
        public EventCallback<bool> FinishChanged { get; set; }

        async Task UpdateFinishValue()
        {
            await FinishChanged.InvokeAsync(Finish);
            StateHasChanged();
        }

        public async Task StartTimer()
        {
            StartBtn = true;
            TimeLeft = new TimeSpan(0, Minutes, 0);
            StartTime = TimeLeft;
            StateHasChanged();

            while (TimeLeft > new TimeSpan() && pause == false)
            {
                await Task.Delay(1000);
                TimeLeft = TimeLeft.Subtract(new TimeSpan(0, 0, 1));
                StateHasChanged();
            }
        }

        public async Task PauseTimer()
        {
            pause = !pause;
            if (pause == false)
            {
                ContinueTimer();
            }
        }

        public async Task ContinueTimer()
        {
            while (TimeLeft > new TimeSpan() && pause == false)
            {
                await Task.Delay(1000);
                TimeLeft = TimeLeft.Subtract(new TimeSpan(0, 0, 1));
                if (TimeLeft == new TimeSpan(0, 0, 1))
                {
                    Finish = true;
                }
                StateHasChanged();
            }
        }

        public void StopTimer()
        {
            StartBtn = false;
            SetMinutes = false;
            pause = false;
            TimeLeft = new TimeSpan(0, 0, 1);
            Minutes = 0;
            StateHasChanged();
        }
    }
}

