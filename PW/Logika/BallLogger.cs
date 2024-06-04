using PW.Data;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PW.Logic
{
    public class BallLogger
    {
        private readonly string logFilePath;

        public BallLogger(string logFilePath)
        {
            this.logFilePath = logFilePath;
            ClearFile();
        }

        public void ClearFile()
        {
            File.WriteAllText(logFilePath, string.Empty);
        }

        public async Task LogBallBehaviorAsync(Ball ball)
        {
            // Serializuję obiekt kuli do formatu JSON.
            string serializedBall = JsonConvert.SerializeObject(ball);

            // Dodaję znacznik czasu do zalogowanych danych.
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {serializedBall}";

            // Asynchronicznie zapisuję dane do pliku logów.
            await AppendLogAsync(logEntry);
        }

        private async Task AppendLogAsync(string logEntry)
        {
            // Tworzę lub otwieram plik logów w trybie dopisywania.
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                // Zapisuję wpis logu.
                await writer.WriteLineAsync(logEntry);
            }
        }
    }
}
