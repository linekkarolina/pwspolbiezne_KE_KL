using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PW.Data
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

        public async Task LogBallsCollisionAsync(Ball ball1, Ball ball2)
        {
            // Serializuję obiekt kuli do formatu JSON.
            string serializedBall1 = JsonConvert.SerializeObject(ball1);
            string serializedBall2 = JsonConvert.SerializeObject(ball2);

            // Dodaję znacznik czasu do zalogowanych danych.
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {serializedBall1} {serializedBall2}";

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