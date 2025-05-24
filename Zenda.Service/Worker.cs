using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zenda.Engine;

namespace Zenda.Service
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private bool _flagStopped;

		// MyEngine _engine;

		public Worker(ILogger<Worker> logger)
		{
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var log = new Zenda.Loging.Logger { Level = Loging.Level.All };
			using var _engine = new MyEngine();
			_engine.Stopped += (sender, e) =>
			{
				Console.WriteLine("inside service worker, stopped!");
				// since engine already stopped, we need to terminate here!
				_flagStopped = true;
			};

			await _engine.Init();
			await _engine.Start();

			while (!stoppingToken.IsCancellationRequested && !_flagStopped)
			{
				// _logger.LogInformation("zenda service running at: {time}, dir: {dir}", DateTimeOffset.Now, System.IO.Directory.GetCurrentDirectory());
				// Console.WriteLine($"zenda service running at: {DateTimeOffset.Now}, dir: {System.IO.Directory.GetCurrentDirectory()}");
				await Task.Delay(1000, stoppingToken);
			}

			// if (!_flagStopped)
			// {
			_engine.Stop();
			_engine.Dispose();
			_flagStopped = true;
			// }

			Console.WriteLine("zedna service terminated!");
		}

		// public override Task StartAsync(CancellationToken cancellationToken)
		// {
		// 	// await base.StartAsync(cancellationToken);
		// 	// return Task.CompletedTask;
		// }

		public override Task StopAsync(CancellationToken cancellationToken)
		{
			_flagStopped = true;
			return base.StopAsync(cancellationToken);
		}

		public override void Dispose()
		{
			GC.SuppressFinalize(this);

			Console.WriteLine("disposing...");
			// _engine.Stop();
			// _engine.Dispose();
			// _flagStopped = true;
			Console.WriteLine("disposed!");
		}
	}
}
