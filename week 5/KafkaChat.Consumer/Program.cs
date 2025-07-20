using System;
using Confluent.Kafka;

namespace KafkaChat.Consumer
{
    class Program
    {
        static void Main()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            try
            {
                consumer.Subscribe("chat-topic");

                Console.WriteLine("Consumer started. Listening for messages...");
                while (true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine($"👂 Received: {cr.Message.Value}");
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                consumer.Close();
                consumer.Dispose();
            }
        }
    }
}

