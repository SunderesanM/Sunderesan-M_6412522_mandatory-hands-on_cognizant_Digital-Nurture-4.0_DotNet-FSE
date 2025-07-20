using System;
using Confluent.Kafka;

namespace KafkaChat.Producer
{
    class Program
    {
        static void Main()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                Acks = Acks.All
            };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("Producer started. Type messages; blank line to exit.");

                while (true)
                {
                    Console.Write("> ");
                    string message = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(message))
                        break;

                    producer.Produce("chat-topic", new Message<Null, string> { Value = message },
                        deliveryReport =>
                        {
                            if (deliveryReport.Error.IsError)
                                Console.WriteLine($"Delivery error: {deliveryReport.Error.Reason}");
                            else
                                Console.WriteLine($"Delivered to {deliveryReport.TopicPartitionOffset}");
                        });
                }
                producer.Flush(TimeSpan.FromSeconds(5));
            }
        }
    }
}

