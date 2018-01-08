using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GreetLambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a sns message and sends a new sns message
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(SNSEvent input, ILambdaContext context)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient();
            var configProvider = new ConfigProvider(context);
            var snsTopic = configProvider.GetSnsTopic();

            foreach (var record in input.Records)
            {
                var name = record.Sns.Message;
                var publishRequest = new PublishRequest
                {
                    TopicArn = snsTopic,
                    Message = $"Hello {name}, how are you?"
                };
                await snsClient.PublishAsync(publishRequest);
            }
        }
    }
}
